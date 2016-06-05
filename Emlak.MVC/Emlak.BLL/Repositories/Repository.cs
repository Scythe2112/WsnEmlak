using Emlak.DAL;
using Emlak.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.BLL.Repositories
{

    public class KonutRepository:RepositoryBase<Konut,int>
    {
    }

    public class FotografRepository : RepositoryBase<Fotograf, int>
    {
    }


    public class IlanTuruRepository : RepositoryBase<IlanTuru, int>
    {
    }


    public class KatTuruRepository : RepositoryBase<KatTur, int>
    {
    }


    public class IsitmaSistemiRepository : RepositoryBase<IsitmaSistemi, int>
    {
    }

}
