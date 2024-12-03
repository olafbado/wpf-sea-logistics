using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;

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
        public decimal Weight
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
        public string Type
        {
            get
            {
                return item.Type;
            }
            set
            {
                item.Type = value;
                OnPropertyChanged(() => Type);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.Cargos.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion

    }
}
