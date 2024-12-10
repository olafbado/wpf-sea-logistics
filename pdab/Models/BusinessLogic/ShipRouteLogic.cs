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
    public class ShipRouteLogic : DatabaseClass
    {
        #region Konstruktor
        public ShipRouteLogic(PdabDbContext db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetShipRoutesKeyAndValueItems()
        {
            return
                (
                    from route in db.ShipRoutes
                    select new KeyAndValue
                    {
                        Key = route.Id,
                        Value = route.Name
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
