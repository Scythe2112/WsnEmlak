using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Emlak.BLL.Account;
using Emlak.ENTITY.IdentyModels;
using Emlak.ENTITY.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Emlak.BLL.Repositories;
using PagedList;
using System.Web.UI.WebControls;
using System.IO;

namespace Emlak.MVC.Controllers
{
    public class AccountController : Controller
    {
        KonutRepository konutR = new KonutRepository();
        IlanTuruRepository ilanTurleriR = new IlanTuruRepository();
        FotografRepository forografR = new FotografRepository();
        KatTuruRepository katTurleriR = new KatTuruRepository();
        IsitmaSistemiRepository isitmaSisR = new IsitmaSistemiRepository();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userManager = MemberShipTools.NewUserManager();

            var user = await userManager.FindAsync(model.UserName, model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Böyle bir kullanıcı bulunamadı!");
                return View(model);
            }
            else
            {
                //kullanıcıyı bulduysa giris yap cıkıs yap (sign in, sign out islemleri için hazır metodların bulunduğu AuthenticationManager nesnesine ihtiyac vardır.
                var authManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);


                authManager.SignIn(new AuthenticationProperties()
                {
                    IsPersistent = model.RememberMe
                }, userIdentity);

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            //eğer view tarafında form kurallı bir bicimde doldurulmadıysa direk modeli viewe geri döner. aşağıdaki islemleri yapmaz.
            if (!ModelState.IsValid)
                return View(model);

            //Kullanıcı kayıt islemleri yapılacak.
            //var userStore = new UserStore<ApplicationUser>(new BlogContext())
            var userManager = MemberShipTools.NewUserManager();
            var checkuser = userManager.FindByName(model.UserName);
            if (checkuser != null)
            {
                ModelState.AddModelError(string.Empty, "Bu kullanıcı zaten kayıtlıdır!");
                return View(model);
            }

            var user = new ApplicationUser
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName,
                Email = model.Email,
            };

            var sonuc = await userManager.CreateAsync(user, model.Password);

            if (sonuc.Succeeded)
            {
                //eğer basarılı ise kullanıcı kaydedilmistir. Kullanıcıya role atayabiliriz.
                await userManager.AddToRoleAsync(user.Id, "User");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı kayıt isleminde hata oluştu");
                return View(model);
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            var userManager = MemberShipTools.NewUserManager();
            var id = HttpContext.User.Identity.GetUserId();
            var user = userManager.FindById(id);

            ProfileViewModel usermodel = new ProfileViewModel()
            {
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Avatar = user.AvatarPath,
                UserID = user.Id
            };

            return View(usermodel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Mevcut şifre yanlış...");
                return RedirectToAction("MyProfile");
            }

            var userStore = MemberShipTools.NewUserStore();
            var userManager = new UserManager<ApplicationUser>(userStore);

            var userName = userManager.FindById(HttpContext.User.Identity.GetUserId()).UserName;

            var user = userManager.Find(userName, model.OldPassword);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Mevcut şifre yanlış...");
                return RedirectToAction("MyProfile");
            }

            //yeni passwordu sifrele ve güncelle:
            await userStore.SetPasswordHashAsync(user, userManager.PasswordHasher.HashPassword(model.Password));

            await userStore.UpdateAsync(user);
            await userStore.Context.SaveChangesAsync();

            return RedirectToAction("Logout");

        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> EditProfile(ProfileEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View("MyProfile",model);

            var userStore = MemberShipTools.NewUserStore();
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = userManager.FindByName(model.UserName);

            if (Request.Files.Count>0)
            {
                HttpPostedFileBase fu = Request.Files[0];

                string resimYolu = fu.FileName;

                string uzanti = Path.GetExtension(resimYolu); //.jpg

                if (fu!=null && fu.ContentType.Contains("image") && fu.ContentLength < 1000000)
                {
                    System.IO.File.Delete(Server.MapPath(user.AvatarPath));
                    //yeni resim yolunu olustur:
                    resimYolu = "/images/Users/" + model.UserName + uzanti;
                    fu.SaveAs(Server.MapPath(resimYolu));
                    user.AvatarPath = resimYolu;
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Email = model.Email;
                    await userStore.UpdateAsync(user);
                    await userStore.Context.SaveChangesAsync();
                }
            }

            return RedirectToAction("MyProfile");
        }
    }
}