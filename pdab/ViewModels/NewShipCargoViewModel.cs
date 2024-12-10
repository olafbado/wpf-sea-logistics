using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using pdab.Models.BusinessLogic;
using pdab.Models.EntitiesForView;

namespace pdab.ViewModels
{
    public class NewShipCargoViewModel:OneViewModel<ShipCargo>
    {
        #region Konstruktor
        public NewShipCargoViewModel()
            : base("New Ship cargo")
        {
            item = new ShipCargo();
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
