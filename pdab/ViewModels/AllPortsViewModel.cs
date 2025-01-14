using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using System.Windows.Documents;

namespace pdab.ViewModels
{
    public class AllPortsViewModel : AllViewModel<Port>
    {
        #region Constructor
        public AllPortsViewModel()
            : base("Ports")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie towary z bazy danych 
        public override void Load()
        {
            List = new ObservableCollection<Port>
                (
                    pdabEntities.Ports.ToList()
                //z bazy danych, pobieram Towar i wszystkie rekordy zamieniam na listę
                );
        }
        #endregion
        #region sort ant find
        //metoda zwraca listę pól po których można sortować
        public override List<string> GetSortList()
        {
            return new List<string> { "Name", "Country" };
        }

        //metoda sortująca towary po wybranym polu

        public override void Sort()
        {
            if (SortField == "Name")
            {
                List = new ObservableCollection<Port>(List.OrderBy(c => c.Name));
            }
            if (SortField == "Country")
            {
                List = new ObservableCollection<Port>(List.OrderBy(c => c.Country));
            }
        }

        //metoda zwraca listę pól po których można wyszukiwać

        public override List<string> GetFindList()
        {
            return new List<string> { "Name", "Country" };
        }

        //metoda wyszukująca towary po wybranym polu

        public override void Find()
        {
            Load();
            if (FindField == "Name")
            {
                List = new ObservableCollection<Port>(List.Where(c => c.Name.ToLower().Contains(FindText.ToLower())));
            }
            if (FindField == "Country")
            {
                List = new ObservableCollection<Port>(List.Where(c => c.Country.ToLower().Contains(FindText.ToLower())));
            }
        }

        #endregion
    }
}
