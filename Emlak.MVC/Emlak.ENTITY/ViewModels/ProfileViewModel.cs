using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.ENTITY.ViewModels
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage ="Bu alan boş bırakılamaz !")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz !")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz !")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Avatar Resmi")]
        public string Avatar { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor..")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Eski Şifre")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır")]
        public string OldPassword { get; set; }


        [Display(Name = "Rol")]
        public string RoleName { get; set; }

        public string RolID { get; set; }

        public string UserID { get; set; }
    }

    public class ProfileEditViewModel
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz !")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz !")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz !")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz !")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Avatar Resmi")]
        public string Avatar { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Eski Şifre")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır")]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor..")]
        public string ConfirmPassword { get; set; }



    }
}
