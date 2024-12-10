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
    public class CrewMemberLogic : DatabaseClass
    {
        #region Konstruktor
        public CrewMemberLogic(PdabDbContext db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetCrewMembersKeyAndValueItems()
        {
            return
                (
                    from member in db.CrewMembers
                    select new KeyAndValue
                    {
                        Key = member.Id,
                        Value = member.FirstName + " " + member.LastName
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
