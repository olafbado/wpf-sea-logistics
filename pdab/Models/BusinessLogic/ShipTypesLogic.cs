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
    public class ShipTypesLogic : DatabaseClass
    {
        #region Konstruktor
        public ShipTypesLogic(PdabDbContext db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        //dodamy funkcje, która będzie zwracała id towarów oraz ich nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetShipTypesKeyAndValueItems()
        {
            return
                (
                    from shipType in db.ShipTypes
                    select new KeyAndValue
                    {
                        Key = shipType.Id,
                        Value = shipType.Name
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
