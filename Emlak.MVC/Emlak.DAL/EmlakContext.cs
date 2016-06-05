using Emlak.ENTITY.Entities;
using Emlak.ENTITY.IdentyModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.DAL
{
    public class EmlakContext: IdentityDbContext<ApplicationUser>
    {
        public EmlakContext(): base("name=EmlakCon")
        {

        }

        //tablolar

        public DbSet<Konut> Konut { get; set; }
        public DbSet<Fotograf> Fotograf { get; set; }
        public DbSet<IlanTuru> IlanTuru { get; set; }
        public DbSet<IsitmaSistemi> IsitmaSistemi { get; set; }
        public DbSet<KatTur> KatTur { get; set; }

    }
}
