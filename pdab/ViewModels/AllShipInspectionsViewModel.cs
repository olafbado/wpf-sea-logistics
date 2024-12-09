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
    }
}