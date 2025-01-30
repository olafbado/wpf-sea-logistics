using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using pdab.Models.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using pdab.Helper;
using System.Windows.Input;

namespace pdab.ViewModels
{
    public class AllShipsViewModel : AllViewModel<Ship>
    {
        #region Constructor
        public AllShipsViewModel()
            : base("Ships")
        {
        }
        #endregion
        #region Helpers
        private Ship _SelectedShip;
        public Ship SelectedShip
        {
            get
            {
                return _SelectedShip;
            }
            set
            {
                _SelectedShip = value;
                Messenger.Default.Send(_SelectedShip);
                OnRequestClose();
            }
        }
        public override void Load()
        {
            List = new ObservableCollection<Ship>
                (
                    pdabEntities.Ships.Include(s => s.ShipType).ToList()
                );
        }

        public override void AddRecord()
        {
            Messenger.Default.Send("Add" + DisplayName);
        }

        public override void RefreshRecords()
        {
            Messenger.Default.Send("Refresh" + DisplayName);
        }
        #endregion
  
        #region sort and find

        public override List<string> GetSortList()
        {
            return new List<string> { "Name", "ShipType", "Flag", "BuildYear" };
        }

        public override void Sort()
        {
            if (SortField == "Name")
            {
                List = new ObservableCollection<Ship>(List.OrderBy(s => s.Name));
            }
            if (SortField == "ShipType")
            {
                List = new ObservableCollection<Ship>(List.OrderBy(s => s.ShipType.Name));
            }
            if (SortField == "Flag")
            {
                List = new ObservableCollection<Ship>(List.OrderBy(s => s.Flag));
            }
            if (SortField == "BuildYear")
            {
                List = new ObservableCollection<Ship>(List.OrderBy(s => s.BuildYear));
            }
        }

        public override List<string> GetFindList()
        {
            return new List<string> { "Name", "ShipType", "Flag", "BuildYear" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Name")
            {
                List = new ObservableCollection<Ship>(List.Where(s => s.Name != null && s.Name.Contains(FindText)));
            }
            if (FindField == "ShipType")
            {
                List = new ObservableCollection<Ship>(List.Where(s => s.ShipType.Name != null && s.ShipType.Name.Contains(FindText)));
            }
            if (FindField == "Flag")
            {
                List = new ObservableCollection<Ship>(List.Where(s => s.Flag != null && s.Flag.Contains(FindText)));
            }
            if (FindField == "BuildYear")
            {
                if (int.TryParse(FindText, out int buildYear))
                {
                    List = new ObservableCollection<Ship>(List.Where(s => s.BuildYear == buildYear));
                }
            }
        }

        #endregion
    }
}
