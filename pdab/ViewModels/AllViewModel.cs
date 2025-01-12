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
using GalaSoft.MvvmLight.Messaging;

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

        private BaseCommand _AddCommand;//to jest komenda, która będzie wywolywala funkcje add wywolujaca okno do dodawania i zostanie podpieta pod przycisk dodaj
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => AddRecord());
                return _AddCommand;
            }
        }

        private BaseCommand _RefreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_RefreshCommand == null)
                    _RefreshCommand = new BaseCommand(() => RefreshRecords());
                return _RefreshCommand;
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
        public virtual void AddRecord()
        {
            Messenger.Default.Send("Add" + DisplayName);
        }
        public virtual void RefreshRecords()
        {

            Load();

        }

        public string SortField { get; set; }
        public List<string> SortItems
        {
            get
            {
                return GetSortList();
            }
        }

        public virtual List<string> GetSortList() { return new List<string>(); }

        private BaseCommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());
                return _SortCommand;

            }
        }

        public virtual void Sort() { }
        public string FindField { get; set; }
        public List<string> FindItems
        {
            get
            {
                return GetFindList();
            }

            #endregion
        }
        public virtual List<string> GetFindList() { return new List<string>(); }
        public string FindText { get; set; }
        private BaseCommand _FindCommand;
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());
                return _FindCommand;
            }
        }

        public virtual void Find()
        {
        }
    }
}
