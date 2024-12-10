using pdab.Models.Entities;
using pdab.Models.EntitiesForView;
using pdab.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdab.Models.BusinessLogic
{
    public class RankLogic : DatabaseClass
    {
        #region Konstruktor
        public RankLogic(PdabDbContext db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetRanksKeyAndValueItems()
        {
            return
                (
                    from rank in db.Ranks
                    select new KeyAndValue
                    {
                        Key = rank.Id,
                        Value = rank.Name
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
