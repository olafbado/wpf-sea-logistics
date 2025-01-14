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
    public class AllFuelLogsViewModel : AllViewModel<FuelLog>
    {
        #region Constructor
        public AllFuelLogsViewModel()
            : base("Fuel logs")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie towary z bazy danych 
        public override void Load()
        {
            List = new ObservableCollection<FuelLog>
                (
                    pdabEntities.FuelLogs.Include(fl => fl.Ship).ToList()
                //z bazy danych, pobieram Towar i wszystkie rekordy zamieniam na listę
                );
        }
        #endregion
        #region sort ant find

        public override List<string> GetSortList()
        {
            return new List<string> { "Ship", "FuelType", "Quantity", "Cost", "Date" };
        }

        //metoda sortująca towary po wybranym polu

        public override void Sort()
        {
            if (SortField == "Ship")
            {
                List = new ObservableCollection<FuelLog>(List.OrderBy(fl => fl.Ship.Name));
            }
            if (SortField == "FuelType")
            {
                List = new ObservableCollection<FuelLog>(List.OrderBy(fl => fl.FuelType));
            }
            if (SortField == "Quantity")
            {
                List = new ObservableCollection<FuelLog>(List.OrderBy(fl => fl.Quantity));
            }
            if (SortField == "Cost")
            {
                List = new ObservableCollection<FuelLog>(List.OrderBy(fl => fl.Cost));
            }
            if (SortField == "Date")
            {
                List = new ObservableCollection<FuelLog>(List.OrderBy(fl => fl.Date));
            }
        }

        //metoda zwraca listę pól po których można wyszukiwać

        public override List<string> GetFindList()
        {
            return new List<string> { "Ship", "FuelType", "Quantity", "Cost", "Date" };
        }

        //metoda wyszukująca towary po wybranym polu

        public override void Find()
        {
            Load();
            if (FindField == "Ship")
            {
                List = new ObservableCollection<FuelLog>(List.Where(fl => fl.Ship.Name.Contains(FindText)));
            }
            if (FindField == "FuelType")
            {
                List = new ObservableCollection<FuelLog>(List.Where(fl => fl.FuelType.Contains(FindText)));
            }
            if (FindField == "Quantity")
            {
                List = new ObservableCollection<FuelLog>(List.Where(fl => fl.Quantity.ToString().Contains(FindText)));
            }
            if (FindField == "Cost")
            {
                List = new ObservableCollection<FuelLog>(List.Where(fl => fl.Cost.ToString().Contains(FindText)));
            }
            if (FindField == "Date")
            {
                List = new ObservableCollection<FuelLog>(List.Where(fl => fl.Date.ToString().Contains(FindText)));
            }
        }

        #endregion
    }
}
