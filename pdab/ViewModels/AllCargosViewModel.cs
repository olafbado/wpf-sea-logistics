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
    public class AllCargosViewModel : AllViewModel<Cargo>
    {
        #region Constructor
        public AllCargosViewModel()
            : base("Cargos")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Cargo>
                (
                    pdabEntities.Cargos.Include(c => c.CargoType).ToList()
                );
        }
        #endregion
    }
}
