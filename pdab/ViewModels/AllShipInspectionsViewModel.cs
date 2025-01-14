using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;

namespace pdab.ViewModels
{
    public class AllShipInspectionsViewModel : AllViewModel<ShipInspection>
    {
        #region Constructor
        public AllShipInspectionsViewModel()
            : base("Ship inspections")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ShipInspection>
                (
                    pdabEntities.ShipInspections.Include(si=>si.Ship).ToList()
                );
        }
        #endregion
        #region sort and find
        public override List<string> GetSortList()
        {
            return new List<string> { "Ship", "Date", "InspectorName", "Notes" };
        }

        public override void Sort()
        {
            if (SortField == "Ship")
            {
                List = new ObservableCollection<ShipInspection>(List.OrderBy(si => si.Ship.Name));
            }
            if (SortField == "Date")
            {
                List = new ObservableCollection<ShipInspection>(List.OrderBy(si => si.Date));
            }
            if (SortField == "InspectorName")
            {
                List = new ObservableCollection<ShipInspection>(List.OrderBy(si => si.InspectorName));
            }
            if (SortField == "Notes")
            {
                List = new ObservableCollection<ShipInspection>(List.OrderBy(si => si.Notes));
            }
        }

        public override List<string> GetFindList()
        {
            return new List<string> { "Ship", "Date", "InspectorName", "Notes" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Ship")
            {
                List = new ObservableCollection<ShipInspection>(List.Where(si => si.Ship.Name.Contains(FindText)));
            }
            if (FindField == "Date")
            {
                List = new ObservableCollection<ShipInspection>(List.Where(si => si.Date.ToString().Contains(FindText)));
            }
            if (FindField == "InspectorName")
            {
                List = new ObservableCollection<ShipInspection>(List.Where(si => si.InspectorName.Contains(FindText)));
            }
            if (FindField == "Notes")
            {
                List = new ObservableCollection<ShipInspection>(List.Where(si => si.Notes != null && si.Notes.Contains(FindText)));
            }
        }

        #endregion

    }
}