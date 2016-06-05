using Emlak.ENTITY.IdentyModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.ENTITY.Entities
{

    [Table("Konutlar")]
    public class Konut
    {

        public int ID { get; set; }
        public short OdaSayisi { get; set; }
        public string Adres { get; set; }

        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        public short BinaYasi { get; set; }

        public decimal Fiyat { get; set; }

        public double Metrekare { get; set; }

        public string Aciklama { get; set; }

        public double Enlem { get; set; }

        public double Boylam { get; set; }

        public string KullaniciID { get; set; }

        public int KatTuruID { get; set; }

        public int IsitmaTuruID { get; set; }

        public int IlanTuruID { get; set; }

        public bool YayindaMi { get; set; }

        public string Baslik { get; set; }

        public bool? OnaylanmaTarihi { get; set; }

        [ForeignKey("IlanTuruID")]
        public virtual IlanTuru IlanTuru { get; set; }

        [ForeignKey("KatTuruID")]
        public virtual KatTur KatTuru { get; set; }

        [ForeignKey("IsitmaTuruID")]
        public virtual KatTur IsinmaSistemi { get; set; }

        public virtual List<Fotograf> Fotograflar { get; set; }

        [ForeignKey("KullaniciID")]
        public virtual ApplicationUser Sahibi { get; set; }

    }
}
