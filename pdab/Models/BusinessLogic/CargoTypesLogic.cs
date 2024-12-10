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
    public class CargoTypesLogic : DatabaseClass
    {
        #region Konstruktor
        public CargoTypesLogic(PdabDbContext db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetCargoTypesKeyAndValueItems()
        {
            return
                (
                    from cargoType in db.CargoTypes
                    select new KeyAndValue
                    {
                        Key = cargoType.Id,
                        Value = cargoType.Name
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
