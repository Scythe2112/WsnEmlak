using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.ENTITY.Entities
{
    [Table("IlanTurleri")]

    public class IlanTuru
    {
        public IlanTuru()
        {
            Konutlar = new List<Konut>();
        }

        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Ad { get; set; }

        //Mapping

        public virtual List<Konut> Konutlar { get; set; }

    }
}
