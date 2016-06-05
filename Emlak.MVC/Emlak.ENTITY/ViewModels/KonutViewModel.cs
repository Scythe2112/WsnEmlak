﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Emlak.ENTITY.ViewModels
{
    public class KonutViewModel
    {
        public KonutViewModel()
        {
            this.FotografYollari = new List<string>();
            this.Dosyalar = new List<HttpPostedFileBase>();
        }

        public int ID { get; set; }

        [Display(Name = "Oda Sayısı")]
        public short OdaSayisi { get; set; }

        public string Adres { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        [Display(Name = "Bina Yaşı")]
        public short BinaYasi { get; set; }

        public decimal Fiyat { get; set; }

        [Display(Name = "m²")]
        public double Metrekare { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        public double Enlem { get; set; }

        public double Boylam { get; set; }

        public string KullaniciID { get; set; }

        [Display(Name = "Kat Türü")]
        public int KatTuruID { get; set; }

        [Display(Name = "Isıtma Türü")]
        public int IsitmaTuruID { get; set; }

        [Display(Name = "İlan Türü")]
        public int IlanTuruID { get; set; }

        public bool YayindaMi { get; set; }

        [StringLength(66)]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }

        [Display(Name = "İlan Tarihi")]
        public DateTime OnaylanmaTarihi { get; set; }

        public List<string> FotografYollari { get; set; }

        public List<HttpPostedFileBase> Dosyalar { get; set; }

    }
}
