using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using pdab.Models.EntitiesForView;
using pdab.Models.BusinessLogic;
using GalaSoft.MvvmLight.Messaging;
using pdab.Helper;
using System.Windows.Input;

namespace pdab.ViewModels
{
    public class NewShipRouteViewModel:OneViewModel<ShipRoute>


    {
        public class PortMessage
        {
            public Port Port { get; set; }
            public string Context { get; set; } // "Arrival" or "Departure"

            public PortMessage(Port port, string context)
            {
                Port = port;
                Context = context;
            }
        }
        #region Konstruktor
        public NewShipRouteViewModel()
            : base("New Ship route")
        {
            item = new ShipRoute();
            Messenger.Default.Register<PortMessage>(this, HandlePortMessage);
        }

        private void HandlePortMessage(PortMessage message)
        {
            if (message.Context == "Arrival")
            {
                ArrivalPortId = message.Port.Id;
                ArrivalPortName = message.Port.Name;
            }
            else if (message.Context == "Departure")
            {
                DeparturePortId = message.Port.Id;
                DeparturePortName = message.Port.Name;
            }
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

        public string ArrivalPortName { get; set; }
        public string DeparturePortName { get; set; }

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
        #region Command
        private BaseCommand _ShowArrivalPorts;
        public ICommand ShowArrivalPorts
        {
            get
            {
                if (_ShowArrivalPorts == null)
                    _ShowArrivalPorts = new BaseCommand(() => showPorts("Arrival"));
                return _ShowArrivalPorts;
            }
        }

        private BaseCommand _ShowDeparturePorts;
        public ICommand ShowDeparturePorts
        {
            get
            {
                if (_ShowDeparturePorts == null)
                    _ShowDeparturePorts = new BaseCommand(() => showPorts("Departure"));
                return _ShowDeparturePorts;
            }
        }

        private void showPorts(string context)
        {
        }
        #endregion

    }
}
