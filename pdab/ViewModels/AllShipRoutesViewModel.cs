using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using GalaSoft.MvvmLight.Messaging;

namespace pdab.ViewModels
{
    public class AllShipRoutesViewModel : AllViewModel<ShipRoute>
    {
        #region Constructor
        public AllShipRoutesViewModel()
            : base("Ship routes")
        {
        }
        #endregion
        #region Properties
        private ShipRoute _SelectedShipRoute;
        public ShipRoute SelectedShipRoute
        {
            get { return _SelectedShipRoute; }
            set
            {
                _SelectedShipRoute = value;
                Messenger.Default.Send(_SelectedShipRoute);
                OnRequestClose();
            }
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ShipRoute>
                (
                    pdabEntities.ShipRoutes.Include(sr=> sr.DeparturePort).Include(sr=> sr.ArrivalPort).Include(sr=>sr.Ship).ToList()
                );
        }
        #endregion
        #region sort and find

        public override List<string> GetSortList()
        {
            return new List<string> { "Ship", "DeparturePort", "ArrivalPort", "DepartureDate", "ArrivalDate", "Name" };
        }


        public override void Sort()
        {
            if (SortField == "Ship")
            {
                List = new ObservableCollection<ShipRoute>(List.OrderBy(sr => sr.Ship.Name));
            }
            if (SortField == "DeparturePort")
            {
                List = new ObservableCollection<ShipRoute>(List.OrderBy(sr => sr.DeparturePort.Name));
            }
            if (SortField == "ArrivalPort")
            {
                List = new ObservableCollection<ShipRoute>(List.OrderBy(sr => sr.ArrivalPort.Name));
            }
            if (SortField == "DepartureDate")
            {
                List = new ObservableCollection<ShipRoute>(List.OrderBy(sr => sr.DepartureDate));
            }
            if (SortField == "ArrivalDate")
            {
                List = new ObservableCollection<ShipRoute>(List.OrderBy(sr => sr.ArrivalDate));
            }
            if (SortField == "Name")
            {
                List = new ObservableCollection<ShipRoute>(List.OrderBy(sr => sr.Name));
            }

        }

        public override List<string> GetFindList()
        {
            return new List<string> { "Ship", "DeparturePort", "ArrivalPort", "DepartureDate", "ArrivalDate", "Name" };

        }

        public override void Find()
        {
            Load();
            if (FindField == "Ship")
            {
                List = new ObservableCollection<ShipRoute>(List.Where(sr => sr.Ship.Name.ToLower().Contains(FindText.ToLower())).ToList());
            }
            if (FindField == "DeparturePort")
            {
                List = new ObservableCollection<ShipRoute>(List.Where(sr => sr.DeparturePort.Name.ToLower().Contains(FindText.ToLower())).ToList());
            }
            if (FindField == "ArrivalPort")
            {
                List = new ObservableCollection<ShipRoute>(List.Where(sr => sr.ArrivalPort.Name.ToLower().Contains(FindText.ToLower())).ToList());
            }
            if (FindField == "DepartureDate")
            {
                List = new ObservableCollection<ShipRoute>(List.Where(sr => sr.DepartureDate.ToString().Contains(FindText)).ToList());
            }
            if (FindField == "ArrivalDate")
            {
                List = new ObservableCollection<ShipRoute>(List.Where(sr => sr.ArrivalDate.ToString().Contains(FindText)).ToList());
            }
            if (FindField == "Name")
            {
                List = new ObservableCollection<ShipRoute>(List.Where(sr => sr.Name != null && sr.Name.ToLower().Contains(FindText.ToLower())).ToList());
            }
        }

        #endregion
    }

}