using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;

namespace pdab.ViewModels
{
    public class AllCrewMembersViewModel : AllViewModel<CrewMember>
    {
        #region Constructor
        public AllCrewMembersViewModel()
            : base("Crew members")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie towary z bazy danych 
        public override void Load()
        {
            List = new ObservableCollection<CrewMember>
                (
                    pdabEntities.CrewMembers.Include(c=>c.Rank).ToList()
                //z bazy danych, pobieram Towar i wszystkie rekordy zamieniam na listę
                );
        }
        #endregion
    }
}
