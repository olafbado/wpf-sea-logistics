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
    public class AllShipsViewModel : AllViewModel<Ship>
    {
        #region Constructor
        public AllShipsViewModel()
            : base("Ships")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Ship>
                (
                    pdabEntities.Ships.Include(s => s.ShipType).ToList()
                );
        }
        #endregion
    }
}
