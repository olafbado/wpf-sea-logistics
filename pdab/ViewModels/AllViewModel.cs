using pdab.Helper;
using pdab.Models.Entities;
using pdab.Helper;
using pdab.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pdab.ViewModels
{
    public abstract class AllViewModel<T> : WorkspaceViewModel//pod T bedą podstawiane konkretne typy elementow listy
    {
        #region DB
        protected readonly PdabDbContext pdabEntities;//to jest pole, które reprezentuje bazę danych
        #endregion
        #region LoadCommand
        private BaseCommand _LoadCommand;//to jest komenda, która będzie wywolywala funkcje Load pobierającą z bazy danych towary
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }
        #endregion
        #region List
        private ObservableCollection<T> _List;//tu bedą przechowywane towary borane z BD
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);//to jest "zlecenie odswiezenia listy na interfejsie
            }
        }
        #endregion
        #region Constructor
        public AllViewModel(String displayName)
        {
            pdabEntities = new PdabDbContext();
            base.DisplayName = displayName;
        }
        #endregion
        #region Helpers
        public abstract void Load();
        #endregion
    }
}
