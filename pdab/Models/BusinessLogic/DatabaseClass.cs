using pdab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdab.Models.BusinessLogic
{
    public class DatabaseClass
    {
        #region Context
        public PdabDbContext db { get; set; }
        #endregion
        #region Konstruktor
        public DatabaseClass(PdabDbContext db)
        {
            this.db = db;
        }
        #endregion
    }
}
