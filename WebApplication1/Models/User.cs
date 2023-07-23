using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        public string? Name { get; set; }
        [Display(Name = "Soyad")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "{0} Alanı Gereklidir!")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} Alanı Gereklidir!")] // {0} yazan yeri property adından al
        public string Password { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }
    }
}
