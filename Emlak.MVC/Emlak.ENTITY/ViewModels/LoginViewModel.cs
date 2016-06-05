using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.ENTITY.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Bırakılamaz !")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola Alanı Boş Bırakılamaz !")]
        [Display(Name = "Parola")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
