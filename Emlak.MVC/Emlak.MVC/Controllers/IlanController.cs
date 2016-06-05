using Emlak.BLL.Account;
using Emlak.BLL.Repositories;
using Emlak.ENTITY.Entities;
using Emlak.ENTITY.IdentyModels;
using Emlak.ENTITY.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Emlak.MVC.Controllers
{
    public class IlanController : Controller
    {

        KonutRepository konutR = new KonutRepository();
        IlanTuruRepository ilanTuruR = new IlanTuruRepository();
        KatTuruRepository katTuruR = new KatTuruRepository();
        IsitmaSistemiRepository isitmaTuruR = new IsitmaSistemiRepository();
        FotografRepository forografR = new FotografRepository();

        [Authorize]
        public ActionResult IlanEkle()
        {
            ViewBag.IlanTurler = ilanTuruR.GetAll().Select(i => new SelectListItem
            {
                Selected = false,
                Text = i.Ad,
                Value = i.ID.ToString()
            }).ToList();

            ViewBag.IsitmaTurleri = isitmaTuruR.GetAll().Select(i => new SelectListItem
            {
                Selected = false,
                Text = i.Ad,
                Value = i.ID.ToString()
            }).ToList();

            ViewBag.KatTurleri = katTuruR.GetAll().Select(i => new SelectListItem
            {
                Selected = false,
                Text = i.Tur,
                Value = i.ID.ToString()
            }).ToList();

            ViewBag.KullaniciID = HttpContext.User.Identity.GetUserId();
            return View();
        }

        [HttpPost]
        public ActionResult IlanEkle(KonutViewModel ilan)
        {
            if (!ModelState.IsValid)
            {
                return View(ilan);
            }

            Konut konut = new Konut
            {
                Aciklama=ilan.Aciklama,
                Adres=ilan.Adres,
                Baslik=ilan.Baslik,
                BinaYasi=ilan.BinaYasi,
                Boylam=ilan.Boylam,
                Enlem=ilan.Enlem,
                EklenmeTarihi=DateTime.Now,
                Fiyat=ilan.Fiyat,
                IlanTuruID=ilan.IlanTuruID,
                IsitmaTuruID=ilan.IsitmaTuruID,
                KatTuruID=ilan.KatTuruID,
                KullaniciID=ilan.KullaniciID,
                Metrekare=ilan.Metrekare,
                OdaSayisi=ilan.OdaSayisi,
                YayindaMi = false,

            };

            konutR.Insert(konut);

            if (Request.Files.Count > 0)
            {
                try
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase fu = Request.Files[i];

                        string dosyayolu = string.Empty;

                        string fileName = Path.GetFileNameWithoutExtension(fu.FileName);
                        string extentionName = Path.GetExtension(fu.FileName);

                        if (fu != null && fu.ContentType.Contains("image") && fu.ContentLength < 1000000)
                        {

                            string folderName = Server.MapPath("~/images/ilanlar");
                            string pathString = System.IO.Path.Combine(folderName, konut.ID.ToString());
                            System.IO.Directory.CreateDirectory(pathString);

                            fileName = fileName.Replace(" ", "");
                            fileName += Guid.NewGuid().ToString().Replace("-", "");

                            dosyayolu = Server.MapPath("~/images/ilanlar/"+ konut.ID.ToString()+"/") + fileName + extentionName;

                            fu.SaveAs(dosyayolu);

                            WebImage img = new WebImage(dosyayolu);
                            img.Resize(150, 150);
                            img.Save(dosyayolu);

                            Fotograf fotograf = new Fotograf()
                            {
                                KonutID = konut.ID,
                                Yol = konut.ID.ToString() + "/" + fileName + extentionName
                        };
                            forografR.Insert(fotograf);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("IlanEkle");
                }
            }

            return RedirectToAction("Ilanlarim");
        }

        [Authorize]
        public ActionResult Ilanlarim()
        {
            var ilanlarim = konutR.GetAll().Where(i => i.KullaniciID == HttpContext.User.Identity.GetUserId()).ToList();
            return View(ilanlarim);
        }

    }
}