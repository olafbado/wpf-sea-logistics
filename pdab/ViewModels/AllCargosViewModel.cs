using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using GalaSoft.MvvmLight.Messaging;

namespace pdab.ViewModels
{
    public class AllCargosViewModel : AllViewModel<Cargo>
    {
        #region Constructor
        public AllCargosViewModel()
            : base("Cargos")
        {
        }
        #endregion
        #region Helpers
        private Cargo _SelectedCargo;
        public Cargo SelectedCargo
        {
            get
            {
                return _SelectedCargo;
            }
            set
            {
                _SelectedCargo = value;
                Messenger.Default.Send(_SelectedCargo);
                OnRequestClose();
            }
        }
        public override void Load()
        {
            List = new ObservableCollection<Cargo>
                (
                    pdabEntities.Cargos.Include(c => c.CargoType).ToList()
                );
        }
        #endregion
        #region sort ant find
        public override List<string> GetSortList()
        {
            return new List<string> { "Description", "Weight", "CargoType" };
        }

        public override void Sort()
        {
            if (SortField == "Description")
            {
                List = new ObservableCollection<Cargo>(List.OrderBy(c => c.Description));
            }
            if (SortField == "Weight")
            {
                List = new ObservableCollection<Cargo>(List.OrderBy(c => c.Weight));
            }
            if (SortField == "CargoType")
            {
                List = new ObservableCollection<Cargo>(List.OrderBy(c => c.CargoType.Name));
            }

        }

        public override List<string> GetFindList()
        {
            return new List<string> { "Description", "Weight", "CargoType" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Description")
            {
                List = new ObservableCollection<Cargo>(List.Where(c => c.Description != null && c.Description.Contains(FindText)));
            }
            if (FindField == "Weight")
            {
                List = new ObservableCollection<Cargo>(List.Where(c => c.Weight.ToString().Contains(FindText)));
            }
            if (FindField == "CargoType")
            {
                List = new ObservableCollection<Cargo>(List.Where(c => c.CargoType.Name.Contains(FindText)));
            }
        }
            #endregion
        }
}
