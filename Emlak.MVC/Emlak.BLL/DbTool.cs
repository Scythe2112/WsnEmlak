using Emlak.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.BLL
{
    public class DbTool
    {
        private static EmlakContext _dbInstance;
        public static EmlakContext DBInstance
        {
            get
            {
                if (_dbInstance == null)
                    _dbInstance = new EmlakContext();
                return _dbInstance;
            }


        }
    }
}
