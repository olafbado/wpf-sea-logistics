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
    public class AllShipMaintenancesViewModel : AllViewModel<ShipMaintenance>
    {
        #region Constructor
        public AllShipMaintenancesViewModel()
            : base("Ship maintenances")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ShipMaintenance>
                (
                    pdabEntities.ShipMaintenances.Include(sm=>sm.Ship).ToList()
                );
        }
        #endregion
        #region sort and find

        public override List<string> GetSortList()
        {
            return new List<string> { "Ship", "Date", "Description", "Cost" };
        }


        public override void Sort()
        {
            if (SortField == "Ship")
            {
                List = new ObservableCollection<ShipMaintenance>(List.OrderBy(sm => sm.Ship.Name));
            }
            if (SortField == "Date")
            {
                List = new ObservableCollection<ShipMaintenance>(List.OrderBy(sm => sm.Date));
            }
            if (SortField == "Description")
            {
                List = new ObservableCollection<ShipMaintenance>(List.OrderBy(sm => sm.Description));
            }
            if (SortField == "Cost")
            {
                List = new ObservableCollection<ShipMaintenance>(List.OrderBy(sm => sm.Cost));
            }
        }

        public override List<string> GetFindList()
        {
            return new List<string> { "Ship", "Date", "Description", "Cost" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Ship")
            {
                List = new ObservableCollection<ShipMaintenance>(List.Where(sm => sm.Ship.Name != null && sm.Ship.Name.Contains(FindText)));
            }
            if (FindField == "Date")
            {
                if (DateTime.TryParse(FindText, out DateTime date))
                {
                    List = new ObservableCollection<ShipMaintenance>(List.Where(sm => sm.Date.Date == date.Date));
                }
            }
            if (FindField == "Description")
            {
                List = new ObservableCollection<ShipMaintenance>(List.Where(sm => sm.Description != null && sm.Description.Contains(FindText)));
            }
            if (FindField == "Cost")
            {
                if (int.TryParse(FindText, out int cost))
                {
                    List = new ObservableCollection<ShipMaintenance>(List.Where(sm => sm.Cost == cost));
                }
            }
        }

        #endregion
    }
}
