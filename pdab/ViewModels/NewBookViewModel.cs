using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using pdab.Helper;


namespace pdab.ViewModels
{
    public class NewBookViewModel : OneViewModel<Book>
    {
        #region Konstruktor
        public NewBookViewModel()
            : base("Book")
        {
            item = new Book();
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
        public int? TypeId
        {
            get
            {
                return item.TypeId;
            }
            set
            {
                item.TypeId = value;
                OnPropertyChanged(() => TypeId);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.Books.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion

    }
}
