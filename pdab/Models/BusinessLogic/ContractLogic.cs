using pdab.Models.Entities;
using pdab.Models.EntitiesForView;

namespace pdab.Models.BusinessLogic
{
    public class ContractLogic : DatabaseClass
    {
        #region Konstruktor
        public ContractLogic(PdabDbContext db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetContractsKeyAndValueItems()
        {
            return
                (
                    from contract in db.Contracts
                    select new KeyAndValue
                    {
                        Key = contract.Id,
                        Value = contract.CustomerName + " - " + contract.Cargo.Description
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
