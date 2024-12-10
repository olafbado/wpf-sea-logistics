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
    public class NewCargoViewModel:OneViewModel<Cargo>
    {
        #region Konstruktor
        public NewCargoViewModel()
            : base("New cargo")
        {
            item = new Cargo();
        }
        #endregion
        #region Properties
        //dla każdego pola na interface tworzymy properties
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
        public int Weight
        {
            get
            {
                return item.Weight;
            }
            set
            {
                item.Weight = value;
                OnPropertyChanged(() => Weight);
            }
        }
        public int CargoTypeId
        {
            get
            {
                return item.CargoTypeId;
            }
            set
            {
                item.CargoTypeId = value;
                OnPropertyChanged(() => CargoTypeId);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.Cargos.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }

        public IQueryable<KeyAndValue> CargoTypesItems
        {
            get
            {
                return new CargoTypesLogic(pdabEntities).GetCargoTypesKeyAndValueItems();
            }
        }
        #endregion

    }
}
