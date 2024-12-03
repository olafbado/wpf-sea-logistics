using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;

namespace pdab.ViewModels
{
    public class NewPortViewModel:OneViewModel<Port>
    {
        #region Konstruktor
        public NewPortViewModel()
            : base("New Port")
        {
            item = new Port();
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
        public string Country
        {
            get
            {
                return item.Country;
            }
            set
            {
                item.Country = value;
                OnPropertyChanged(() => Country);
            }
        }
        public int Capacity
        {
            get
            {
                return item.Capacity;
            }
            set
            {
                item.Capacity = value;
                OnPropertyChanged(() => Capacity);
            }
        }

        

        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.Ports.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion

    }
}
