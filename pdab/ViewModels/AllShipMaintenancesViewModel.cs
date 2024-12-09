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
    public class AllShipMaintenancesViewModel : AllViewModel<ShipMaintenance>
    {
        #region Constructor
        public AllShipMaintenancesViewModel()
            : base("Ship maintenances")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ShipMaintenance>
                (
                    pdabEntities.ShipMaintenances.Include(sm=>sm.Ship).ToList()
                );
        }
        #endregion
    }
}
