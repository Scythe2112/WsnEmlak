using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.ENTITY.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz !")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Alanı Boş Bırakılamaz !")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Bırakılamaz !")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email Alanı Boş Bırakılamaz !")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Alanı Boş Bırakılamaz !")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Tekrar Alanı Boş Bırakılamaz !")]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor...")]
        public string ConfirmPassword { get; set; }

    }
}
