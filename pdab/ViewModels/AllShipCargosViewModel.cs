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
    internal class AllShipCargosViewModel : AllViewModel<ShipCargo>
    {
        #region Constructor
        public AllShipCargosViewModel()
            : base("Ship cargos")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ShipCargo>
                (
                    pdabEntities.ShipCargos.Include(sc=>sc.Ship).Include(sc=> sc.Cargo).ToList()
                );
        }
        #endregion
        #region sort ant find

        public override List<string> GetSortList()
        {
            return new List<string> { "Ship", "Cargo", "Quantity" };
        }

        public override void Sort()
        {
            if (SortField == "Ship")
            {
                List = new ObservableCollection<ShipCargo>(List.OrderBy(sc => sc.Ship.Name));
            }
            if (SortField == "Cargo")
            {
                List = new ObservableCollection<ShipCargo>(List.OrderBy(sc => sc.Cargo.Description));
            }
            if (SortField == "Quantity")
            {
                List = new ObservableCollection<ShipCargo>(List.OrderBy(sc => sc.Quantity));
            }
        }

        public override List<string> GetFindList()
        {
            return new List<string> { "Ship", "Cargo", "Quantity" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Ship")
            {
                List = new ObservableCollection<ShipCargo>(List.Where(sc => sc.Ship.Name.ToLower().Contains(FindText.ToLower())).ToList());
            }
            if (FindField == "Cargo")
            {
                List = new ObservableCollection<ShipCargo>(List.Where(sc => sc.Cargo.Description.ToLower().Contains(FindText.ToLower())).ToList());
            }
            if (FindField == "Quantity")
            {
                List = new ObservableCollection<ShipCargo>(List.Where(sc => sc.Quantity.ToString().Contains(FindText)).ToList());
            }
        }

        #endregion
    }
}
