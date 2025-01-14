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
    public class AllShipTypesViewModel : AllViewModel<ShipType>
    {
        #region Constructor
        public AllShipTypesViewModel()
            : base("Ship types")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie towary z bazy danych 
        public override void Load()
        {
            List = new ObservableCollection<ShipType>
                (
                    pdabEntities.ShipTypes.ToList()
                //z bazy danych, pobieram Towar i wszystkie rekordy zamieniam na listę
                );
        }
        #endregion

        #region sort ant find
        //metoda zwraca listę pól po których można sortować
        public override List<string> GetSortList()
        {
            return new List<string> { "Name" };
        }

        //metoda sortująca towary po wybranym polu
        public override void Sort()
        {
            if (SortField == "Name")
            {
                List = new ObservableCollection<ShipType>(List.OrderBy(c => c.Name));
            }
        }

        //metoda zwraca listę pól po których można wyszukiwać
        public override List<string> GetFindList()
        {
            return new List<string> { "Name" };
        }

        //metoda wyszukująca towary po wybranym polu
        public override void Find()
        {
            Load();
            if (FindField == "Name")
            {
                List = new ObservableCollection<ShipType>(List.Where(c => c.Name.ToLower().Contains(FindText.ToLower())));
            }
        }

        #endregion
    }
}
