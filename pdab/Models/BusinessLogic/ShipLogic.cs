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
    public class ShipLogic : DatabaseClass
    {
        #region Konstruktor
        public ShipLogic(PdabDbContext db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetShipsKeyAndValueItems()
        {
            return
                (
                    from ship in db.Ships
                    select new KeyAndValue
                    {
                        Key = ship.Id,
                        Value = ship.Name
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
