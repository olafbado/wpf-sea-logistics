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
    public class NewPortFeeViewModel : OneViewModel<PortFee>
    {
        #region Konstruktor
        public NewPortFeeViewModel()
            : base("New Port fee")
        {
            item = new PortFee();
            Messenger.Default.Register<Port>(this, getSelectedPort);
            Messenger.Default.Register<Ship>(this, getSelectedShip);
        }
        #endregion
        #region Properties
        //dla każdego pola na interface tworzymy properties
        public int PortId
        {
            get
            {
                return item.PortId;
            }
            set
            {
                item.PortId = value;
                OnPropertyChanged(() => PortId);
            }
        }
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

        public string PortName
        {
            get;
            set;
        }

        public string ShipName
        {
            get;
            set;
        }
        public DateTime Date
        {
            get
            {
                return item.Date;
            }
            set
            {
                item.Date = value;
                OnPropertyChanged(() => Date);
            }
        }

        public int Amount
        {
            get
            {
                return item.Amount;
            }
            set
            {
                item.Amount = value;
                OnPropertyChanged(() => Amount);
            }
        }

        #endregion

        #region Helpers
        private BaseCommand _ShowShips;
        public ICommand ShowShips
        {
            get
            {
                if (_ShowShips == null)
                    _ShowShips = new BaseCommand(() => showShips());
                return _ShowShips;
            }
        }

        private void showShips()
        {
            Messenger.Default.Send("AllShips");
        }

        private BaseCommand _ShowPorts;
        public ICommand ShowPorts
        {
            get
            {
                if (_ShowPorts == null)
                    _ShowPorts = new BaseCommand(() => showPorts());
                return _ShowPorts;
            }
        }

        private void showPorts()
        {
            Messenger.Default.Send("AllPorts");
        }
        public void getSelectedPort(Port port)
        {
            PortId = port.Id;
            PortName = port.Name;
        }

        public void getSelectedShip(Ship ship)
        {
            ShipId = ship.Id;
            ShipName = ship.Name;
        }
        public override void Save()
        {
            pdabEntities.PortFees.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }

        public IQueryable<KeyAndValue> ShipItems
        {
            get
            {
                return new ShipLogic(pdabEntities).GetShipsKeyAndValueItems();
            }
            
        }
        #endregion

        public IQueryable<KeyAndValue> PortItems
        {
            get
            {
                return new PortLogic(pdabEntities).GetPortsKeyAndValueItems();
            }
        }
    }
}
