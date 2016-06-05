using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.ENTITY.Entities
{
    [Table("KatTurleri")]
    public class KatTur
    {
        public KatTur()
        {
            Konutlar = new List<Konut>();
        }

        [Key]
        public int ID { get; set; }
        [StringLength(15)]
        [Required]
        public string Tur { get; set; }

        public virtual List<Konut> Konutlar { get; set; }


    }
}
