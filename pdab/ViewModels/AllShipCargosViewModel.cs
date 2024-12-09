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
    internal class AllShipCargosViewModel : AllViewModel<ShipCargo>
    {
        #region Constructor
        public AllShipCargosViewModel()
            : base("Ship cargos")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ShipCargo>
                (
                    pdabEntities.ShipCargos.Include(sc=>sc.Ship).Include(sc=> sc.Cargo).ToList()
                );
        }
        #endregion
    }
}
