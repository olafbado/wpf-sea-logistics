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
    public class AllShipTypesCargoTypesViewModel : AllViewModel<ShipTypeCargoType>
    {
        #region Constructor
        public AllShipTypesCargoTypesViewModel()
            : base("Ship types Cargo types")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ShipTypeCargoType>
                (
                    pdabEntities.ShipTypeCargoTypes.Include(stct=>stct.ShipType).Include(stct=>stct.CargoType).ToList()
                );
        }
        #endregion

        #region sort and find

        public override List<string> GetSortList()
        {
            return new List<string> { "ShipType", "CargoType" };
        }

        public override void Sort()
        {
            if (SortField == "ShipType")
            {
                List = new ObservableCollection<ShipTypeCargoType>(List.OrderBy(stct => stct.ShipType.Name));
            }
            if (SortField == "CargoType")
            {
                List = new ObservableCollection<ShipTypeCargoType>(List.OrderBy(stct => stct.CargoType.Name));
            }
        }

        public override List<string> GetFindList()
        {
            return new List<string> { "ShipType", "CargoType" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "ShipType")
            {
                List = new ObservableCollection<ShipTypeCargoType>(List.Where(stct => stct.ShipType.Name.ToLower().Contains(FindText.ToLower())).ToList());
            }
            if (FindField == "CargoType")
            {
                List = new ObservableCollection<ShipTypeCargoType>(List.Where(stct => stct.CargoType.Name.ToLower().Contains(FindText.ToLower())).ToList());
            }
        }

        #endregion

    }

}
