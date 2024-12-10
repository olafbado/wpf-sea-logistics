using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.BusinessLogic;
using pdab.Models.Entities;
using pdab.Models.EntitiesForView;

namespace pdab.ViewModels
{
    public class NewFuelLogViewModel:OneViewModel<FuelLog>
    {

        #region Konstruktor
        public NewFuelLogViewModel()
            : base("New Fuel log")
        {
            item = new FuelLog();
        }
    #endregion
    #region Properties
    //dla każdego pola na interface tworzymy properties
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
        public int Cost
        {
            get
            {
                return item.Cost;
            }
            set
            {
                item.Cost = value;
                OnPropertyChanged(() => Cost);

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
    public string FuelType
    {
        get
        {
            return item.FuelType;
        }
        set
        {
            item.FuelType = value;
            OnPropertyChanged(() => FuelType);
        }
    }
    #endregion

    #region Helpers
    public override void Save()
    {
        pdabEntities.FuelLogs.Add(item); //dodaje towar do lokalnej kolekcji 
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

}
}
