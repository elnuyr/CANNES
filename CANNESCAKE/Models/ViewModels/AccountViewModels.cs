using System.ComponentModel.DataAnnotations;

namespace CANNESCAKE.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad və soyad daxil edilməlidir")]
        [Display(Name = "Ad və Soyad")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "İstifadəçi adı daxil edilməlidir")]
        [Display(Name = "İstifadəçi Adı")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-poçt daxil edilməlidir")]
        [EmailAddress(ErrorMessage = "Düzgün e-poçt daxil edin")]
        [Display(Name = "E-poçt")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifrə daxil edilməlidir")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifrə")]
        [MinLength(8, ErrorMessage = "Şifrə ən azı 8 simvol olmalıdır")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifrənin təkrarını daxil edin")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifrənin təkrarı")]
        [Compare("Password", ErrorMessage = "Şifrələr eyni deyil")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "İstifadəçi adı daxil edilməlidir")]
        [Display(Name = "İstifadəçi Adı")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifrə daxil edilməlidir")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifrə")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Məni xatırla")]
        public bool RememberMe { get; set; }
    }
}
