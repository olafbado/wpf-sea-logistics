using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;

namespace pdab.ViewModels
{
    public class NewShipMaintenanceViewModel:OneViewModel<ShipMaintenance>
    {
        #region Konstruktor
        public NewShipMaintenanceViewModel()
            : base("New Ship maintenance")
        {
            item = new ShipMaintenance();
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
        public string Description
        {
            get
            {
                return item.Description;
            }
            set
            {
                item.Description = value;
                OnPropertyChanged(() => Description);
            }
        }

        public decimal Cost
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

        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.ShipMaintenances.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion

    }
}
