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
    public class AllShipRoutesViewModel : AllViewModel<ShipRoute>
    {
        #region Constructor
        public AllShipRoutesViewModel()
            : base("Ship routes")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ShipRoute>
                (
                    pdabEntities.ShipRoutes.Include(sr=> sr.DeparturePort).Include(sr=> sr.ArrivalPort).Include(sr=>sr.Ship).ToList()
                );
        }
        #endregion
    }
}
