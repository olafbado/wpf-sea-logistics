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
    public class PortLogic : DatabaseClass
    {
        #region Konstruktor
        public PortLogic(PdabDbContext db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetPortsKeyAndValueItems()
        {
            return
                (
                    from port in db.Ports
                    select new KeyAndValue
                    {
                        Key = port.Id,
                        Value = port.Name
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
