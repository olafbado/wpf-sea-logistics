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
    public class NewShipViewModel:OneViewModel<Ship>
    {
        #region Konstruktor
        public NewShipViewModel()
            : base("New Ship")
        {
            item = new Ship();
        }
        #endregion
        #region Properties
        //dla każdego pola na interface tworzymy properties
        public string Name
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
        public int ShipTypeId
        {
            get
            {
                return item.ShipTypeId;
            }
            set
            {
                item.ShipTypeId = value;
                OnPropertyChanged(() => ShipTypeId);
            }
        }
        public string Flag
        {
            get
            {
                return item.Flag;
            }
            set
            {
                item.Flag = value;
                OnPropertyChanged(() => Flag);
            }
        }

        public int BuildYear
        {
            get
            {
                return item.BuildYear;
            }
            set
            {
                item.BuildYear = value;
                OnPropertyChanged(() => BuildYear);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.Ships.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        public IQueryable<KeyAndValue> ShipTypesItems
        {
            get
            {
                return new ShipTypesLogic(pdabEntities).GetShipTypesKeyAndValueItems();
            }

        }
        #endregion

    }
}
