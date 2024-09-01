using System.ComponentModel.DataAnnotations;

namespace HrProject.Presentation.ViewModels;

public class UserUpdateViewModel
{
    public string Id { get; set; }
    public int PersonelNumber { get; set; }
    [Required(ErrorMessage = "İsim Zorunludur")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Soyisim Zorunludur")]
    public string SurName { get; set; }
    public string? Color { get; set; }
    public string MailSifresi { get; set; }
    public string MailAdresi { get; set; }
    public string ProfilPhoto { get; set; }
    public string? Hakkinda { get; set; }
    public string? Adres { get; set; }
    public string? Tel { get; set; }
    public IFormFile Photo { get; set; }

}
