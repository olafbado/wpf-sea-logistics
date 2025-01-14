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
        #region sort ant find
        //metoda zwraca listę pól po których można sortować
        public override List<string> GetSortList()
        {
            return new List<string> { "FirstName", "LastName", "Rank" };
        }

        //metoda sortująca towary po wybranym polu

        public override void Sort()
        {
            if (SortField == "FirstName")
            {
                List = new ObservableCollection<CrewMember>(List.OrderBy(c => c.FirstName));
            }
            if (SortField == "LastName")
            {
                List = new ObservableCollection<CrewMember>(List.OrderBy(c => c.LastName));
            }
            if (SortField == "Rank")
            {
                List = new ObservableCollection<CrewMember>(List.OrderBy(c => c.Rank.Name));
            }
        }

        //metoda zwraca listę pól po których można wyszukiwać

        public override List<string> GetFindList()
        {
            return new List<string> { "FirstName", "LastName", "Rank" };
        }

        //metoda wyszukująca towary po wybranym polu

        public override void Find()
        {
            Load();
            if (FindField == "FirstName")
            {
                List = new ObservableCollection<CrewMember>(List.Where(c => c.FirstName.Contains(FindText)));
            }
            if (FindField == "LastName")
            {
                List = new ObservableCollection<CrewMember>(List.Where(c => c.LastName.Contains(FindText)));
            }
            if (FindField == "Rank")
            {
                List = new ObservableCollection<CrewMember>(List.Where(c => c.Rank.Name.Contains(FindText)));
            }
        }

        #endregion
    }
}
