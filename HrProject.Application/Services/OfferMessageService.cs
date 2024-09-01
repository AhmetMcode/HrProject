using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services;

public class OfferMessageService : BaseRepository<OfferMessages>, IOfferMessageService
{
    public OfferMessageService(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public void AddMessageDetail(int messageId, string content, string userId)
    {
        OfferMessagesDetail detail = new OfferMessagesDetail();
        detail.SenderUserId = userId;
        detail.MessageDate = DateTime.Now;
        detail.Message = content;
        detail.OfferMessagesId = messageId;
        _context.OfferMessagesDetails.Add(detail);
        _context.SaveChanges();
    }

    public OfferMessages GetByAddId(int offerId)
    {
        OfferMessages offerMessages = _context.OfferMessages.Where(x => x.OfferId == offerId).Include(x => x.Offer).Include(x => x.OfferMessagesDetail).ThenInclude(x => x.SenderUser).FirstOrDefault();
        if (offerMessages == null)
        {
            OfferMessages offerMessages1 = new OfferMessages();
            offerMessages1.OfferId = offerId;
            _context.OfferMessages.Add(offerMessages1);
            _context.SaveChanges();
            return offerMessages1 = _context.OfferMessages.Where(x => x.OfferId == offerMessages1.Id).Include(x => x.Offer).Include(x => x.OfferMessagesDetail).ThenInclude(x => x.SenderUser).FirstOrDefault();
        }
        return offerMessages;
    }
}
