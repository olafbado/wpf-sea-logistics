using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using pdab.Models.BusinessLogic;
using pdab.Models.EntitiesForView;
using pdab.Helper;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace pdab.ViewModels
{
    public class NewShipCargoViewModel:OneViewModel<ShipCargo>
    {
        #region Konstruktor
        public NewShipCargoViewModel()
            : base("New Ship cargo")
        {
            item = new ShipCargo();
            Messenger.Default.Register<Ship>(this, getSelectedShip);
            Messenger.Default.Register<Cargo>(this, getSelectedCargo);
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
        public int CargoId
        {
            get
            {
                return item.CargoId;
            }
            set
            {
                item.CargoId = value;
                OnPropertyChanged(() => CargoId);
            }
        }

        public string ShipName
        {
            get;
            set;
        }

        public string CargoName
        {
            get;
            set;
        }
        public int Quantity
        {
            get
            {
                return item.Quantity;
            }
            set
            {
                item.Quantity = value;
                OnPropertyChanged(() => Quantity);
            }
        }



        #endregion

        #region Helpers
        private void getSelectedShip(Ship ship)
        {
            ShipId = ship.Id;
            ShipName = ship.Name;
        }

        private void getSelectedCargo(Cargo cargo)
        {
            CargoId = cargo.Id;
            CargoName = cargo.Description;
        }

        private BaseCommand _ShowShips;
        public ICommand ShowShips
        {
            get
            {
                if (_ShowShips == null)
                {
                    _ShowShips = new BaseCommand(() => showShips());
                }
                return _ShowShips;
            }
        }

        private void showShips()
        {
            Messenger.Default.Send("AllShips");
        }

        private BaseCommand _ShowCargos;
        public ICommand ShowCargos
        {
            get
            {
                if (_ShowCargos == null)
                {
                    _ShowCargos = new BaseCommand(() => showCargos());
                }
                return _ShowCargos;
            }
        }


        private void showCargos()
        {
            Messenger.Default.Send("AllCargos");
        }

        public override void Save()
        {
            pdabEntities.ShipCargos.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }

        public IQueryable<KeyAndValue> ShipItems
        {
            get
            {
                return new ShipLogic(pdabEntities).GetShipsKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> CargoItems
        {
            get
            {
                return new CargoLogic(pdabEntities).GetCargosKeyAndValueItems();
            }
        }
        #endregion

    }
}
