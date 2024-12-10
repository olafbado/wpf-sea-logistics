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
    public class NewPortFeeViewModel : OneViewModel<PortFee>
    {
        #region Konstruktor
        public NewPortFeeViewModel()
            : base("New Port fee")
        {
            item = new PortFee();
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
            #endregion
        }

        public IQueryable<KeyAndValue> PortItems
        {
            get
            {
                return new PortLogic(pdabEntities).GetPortsKeyAndValueItems();
            }
        }
    }
}
