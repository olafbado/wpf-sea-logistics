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
    public class AllShipTypesCargoTypesViewModel : AllViewModel<ShipTypeCargoType>
    {
        #region Constructor
        public AllShipTypesCargoTypesViewModel()
            : base("Ship types Cargo types")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ShipTypeCargoType>
                (
                    pdabEntities.ShipTypeCargoTypes.Include(stct=>stct.ShipType).Include(stct=>stct.CargoType).ToList()
                );
        }
        #endregion
    }
}
