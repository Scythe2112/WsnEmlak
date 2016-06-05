using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.ENTITY.Entities
{
    [Table("Fotograflar")]
    public class Fotograf
    {
        public int ID { get; set; }

        public string Yol { get; set; }

        public int KonutID { get; set; }

        [ForeignKey("KonutID")]
        public virtual Konut Konutu { get; set; }
    }
}
