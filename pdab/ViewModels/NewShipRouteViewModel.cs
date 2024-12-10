using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using pdab.Models.EntitiesForView;
using pdab.Models.BusinessLogic;

namespace pdab.ViewModels
{
    public class NewShipRouteViewModel:OneViewModel<ShipRoute>
    {
        #region Konstruktor
        public NewShipRouteViewModel()
            : base("New Ship route")
        {
            item = new ShipRoute();
        }
        #endregion
        #region Properties
        //dla każdego pola na interface tworzymy properties
        public int ShipId
        {
            get
            {
                return item.ShipId;
            }
            set
            {
                item.ShipId = value;
                OnPropertyChanged(() => ShipId);
            }
        }

        public string? Name
        {
            get
            {
                return item.Name;
            }
            set
            {
                item.Name = value;
                OnPropertyChanged(() => Name);
            }
        }

        public int ContractId
        {
            get
            {
                return item.ContractId;
            }
            set
            {
                item.ContractId = value;
                OnPropertyChanged(() => ContractId);
            }
        }
        public int DeparturePortId
        {
            get
            {
                return item.DeparturePortId;
            }
            set
            {
                item.DeparturePortId = value;
                OnPropertyChanged(() => DeparturePortId);
            }
        }
        public int ArrivalPortId
        {
            get
            {
                return item.ArrivalPortId;
            }
            set
            {
                item.ArrivalPortId = value;
                OnPropertyChanged(() => ArrivalPortId);
            }
        }

        public DateTime DepartureDate
        {
            get
            {
                return item.DepartureDate;
            }
            set
            {
                item.DepartureDate = value;
                OnPropertyChanged(() => DepartureDate);
            }
        }
        public DateTime ArrivalDate
        {
            get
            {
                return item.ArrivalDate;
            }
            set
            {
                item.ArrivalDate = value;
                OnPropertyChanged(() => ArrivalDate);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.ShipRoutes.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }

        public IQueryable<KeyAndValue> PortItems
        {
            get
            {
                return new PortLogic(pdabEntities).GetPortsKeyAndValueItems();

            }
        }

        public IQueryable<KeyAndValue> ShipItems
        {
            get
            {
                return new ShipLogic(pdabEntities).GetShipsKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> ContractItems
        {
            get
            {
                return new ContractLogic(pdabEntities).GetContractsKeyAndValueItems();
            }
        }
        #endregion

    }
}
