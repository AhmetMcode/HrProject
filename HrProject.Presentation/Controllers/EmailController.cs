using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using HrProject.ApplicaitonContracts.Interfaces;
using System.Security.Claims;

public class MailViewModel
{
    public string From { get; set; }
    public string To { get; set; }
    public string Cc { get; set; }
    public string Bcc { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<string> Attachments { get; set; }
    public DateTime Date { get; set; }
    public bool IsRead { get; set; } // Yeni eklenen özellik
}
[Authorize] // Yetkilendirme eklemesi

public class EmailController : Controller
{
    private readonly IUserService userService;
    private readonly IUserEmailService userEmailService;

    public EmailController(IUserService userService, IUserEmailService userEmailService)
    {
        this.userService = userService;
        this.userEmailService = userEmailService;
    }
    public async Task<IActionResult> Index()
    {
        List<MailViewModel> mailList = new List<MailViewModel>();
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await userService.GetById(userId);
        var mailSet = userEmailService.Where(x => x.ApplicationUserId == userId).FirstOrDefault();
        using (var client = new ImapClient())
        {
            client.Connect(mailSet.host, mailSet.almaport, true);
            client.Authenticate(user.MailAdresi, user.MailSifresi);

            var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadOnly);

            int totalMessages = inbox.Count;

            var uids = inbox.Search(SearchQuery.All).OrderByDescending(x => x).Take(10);
            foreach (var uid in uids)
            {
                var message = inbox.GetMessage(uid);
                var mailViewModel = ParseEmail(client, message);
                mailViewModel.IsRead = IsEmailRead(client, uid);
                mailList.Add(mailViewModel);
            }

            client.Disconnect(true);
        }

        return View(mailList);
    }
    public async Task<IActionResult> NewEmail()
    {
        return View();
    }
    public async Task<IActionResult> WasSend()
    {
        List<MailViewModel> mailList = new List<MailViewModel>();
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await userService.GetById(userId);
        var mailSet = userEmailService.Where(x => x.ApplicationUserId == userId).FirstOrDefault();

        using (var client = new ImapClient())
        {
            client.Connect(mailSet.host, mailSet.almaport, true);
            client.Authenticate(user.MailAdresi, user.MailSifresi);

            // Open the "Sent" folder
            var sentFolder = client.GetFolder(SpecialFolder.Sent);
            sentFolder.Open(FolderAccess.ReadOnly);

            // Toplam mesaj sayısını al
            int totalMessages = sentFolder.Count;

            // Son 10 mesajı al
            var uids = sentFolder.Search(SearchQuery.All).OrderBy(x => x).Take(300);
            foreach (var uid in uids)
            {
                var message = sentFolder.GetMessage(uid);
                var mailViewModel = ParseEmail(client, message);
                mailViewModel.IsRead = true;
                mailList.Add(mailViewModel);
            }

            client.Disconnect(true);
        }
        mailList.Reverse();
        return View(mailList);
    }

    [HttpPost]
    public async Task<IActionResult> NewEmail(NewEmailViewModel model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var mailSet = userEmailService.Where(x => x.ApplicationUserId == userId).FirstOrDefault();
        var user = await userService.GetById(userId);
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Admin", user.MailAdresi));
        message.To.Add(new MailboxAddress("Alıcı Adı", model.To));
        message.Subject = model.Subject;

        // E-posta içeriğini oluştur
        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = model.Body;

        // Eğer ek varsa ekleri ekle
        if (model.Attachments != null && model.Attachments.Count > 0)
        {
            foreach (var attachment in model.Attachments)
            {
                var memoryStream = new MemoryStream();
                await attachment.CopyToAsync(memoryStream);

                bodyBuilder.Attachments.Add(attachment.FileName, memoryStream.ToArray());
            }
        }

        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.Connect(mailSet.host, mailSet.gondermeport, true);
            client.Authenticate(user.MailAdresi, user.MailSifresi);

            await client.SendAsync(message);
            client.Disconnect(true);
        }
        return RedirectToAction("Index", "Email");
    }
    private MailViewModel ParseEmail(ImapClient client, MimeMessage message)
    {
        var mailViewModel = new MailViewModel
        {
            From = GetMailboxAddresses(message.From),
            To = GetMailboxAddresses(message.To),
            Cc = GetMailboxAddresses(message.Cc),
            Bcc = GetMailboxAddresses(message.Bcc),
            Subject = message.Subject,
            Body = GetMessageBody(message),
            Attachments = GetAttachments(message),
            Date = message.Date.DateTime
        };

        return mailViewModel;
    }

    private string GetMailboxAddresses(InternetAddressList addresses)
    {
        return addresses?.Select(a => a.ToString()).FirstOrDefault();
    }

    private string GetMessageBody(MimeMessage message)
    {
        var textPart = message.TextBody ?? message.HtmlBody;
        return textPart;
    }

    private List<string> GetAttachments(MimeMessage message)
    {
        var attachments = new List<string>();

        foreach (var attachment in message.Attachments)
        {
            var fileName = attachment.ContentDisposition?.FileName ?? "Attachment";
            attachments.Add(fileName);
        }

        return attachments;
    }


    private bool IsEmailRead(ImapClient client, UniqueId uid)
    {
        // UID üzerinden mesajın flags'lerini al
        var summary = client.Inbox.Fetch(new[] { uid }, MessageSummaryItems.Flags).FirstOrDefault();

        // "Seen" flag'i mesajın okunduğunu gösterir
        return summary?.Flags?.HasFlag(MessageFlags.Seen) ?? false;
    }
    public class NewEmailViewModel
    {
        // E-posta konusu
        public string Subject { get; set; }

        // E-posta alıcıları (Birden fazla alıcı için dizi veya liste kullanabilirsiniz)
        public string To { get; set; }

        // E-posta içeriği
        public string Body { get; set; }

        // E-posta ekleri (Birden fazla ek için dizi veya liste kullanabilirsiniz)
        public List<IFormFile> Attachments { get; set; }
    }

}
