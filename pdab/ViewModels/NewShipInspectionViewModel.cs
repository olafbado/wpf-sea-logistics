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
    public class NewShipInspectionViewModel : OneViewModel<ShipInspection>
    {
        #region Konstruktor
        public NewShipInspectionViewModel()
            : base("New Ship inspection")
        {
            item = new ShipInspection();
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

        public string InspectorName
        {
            get
            {
                return item.InspectorName;
            }
            set
            {
                item.InspectorName = value;
                OnPropertyChanged(() => InspectorName);
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

        public string Notes
        {
            get
            {
                return item.Notes;
            }
            set
            {
                item.Notes = value;
                OnPropertyChanged(() => Notes);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.ShipInspections.Add(item); //dodaje towar do lokalnej kolekcji 
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
