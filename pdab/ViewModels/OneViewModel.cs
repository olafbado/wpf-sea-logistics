using pdab.Helper;
using pdab.Models.Entities;
using pdab.Helper;
using pdab.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pdab.ViewModels
{
    public abstract class OneViewModel<T> : WorkspaceViewModel
    {
        #region DB
        protected PdabDbContext pdabEntities;
        #endregion
        #region Item
        protected T item;
        #endregion
        #region Command
        //to jest komenda, która zostanie podpieta pod przycisk zapisz i zamknij i ona wyowla funkcje SaveAndClose
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }
        #endregion
        #region Konstruktor
        public OneViewModel(string displayName)
        {
            base.DisplayName = displayName;
            pdabEntities = new PdabDbContext();
        }
        #endregion
        #region Helpers
        public abstract void Save();
        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose();//zamkniecie zakładki 
        }
       
        #endregion

    }
}
