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
    public class CargoLogic : DatabaseClass
    {
        #region Konstruktor
        public CargoLogic(PdabDbContext db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetCargosKeyAndValueItems()
        {
            return
                (
                    from cargo in db.Cargos
                    select new KeyAndValue
                    {
                        Key = cargo.Id,
                        Value = cargo.Description
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
