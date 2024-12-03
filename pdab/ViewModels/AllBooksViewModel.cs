using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using pdab.Models.Entities;

namespace pdab.ViewModels
{
    public class AllBooksViewModel : AllViewModel<Book>
    {
        #region Constructor
        public AllBooksViewModel()
            : base("Books")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie towary z bazy danych 
        public override void Load()
        {
            List = new ObservableCollection<Book>
                (
                    pdabEntities.Books.ToList()
                //z bazy danych, pobieram Towar i wszystkie rekordy zamieniam na listę
                );
        }
        #endregion
    }
}
