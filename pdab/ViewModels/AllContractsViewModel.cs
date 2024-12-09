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
    public class AllContractsViewModel : AllViewModel<Contract>
    {
        #region Constructor
        public AllContractsViewModel()
            : base("Contracts")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Contract>
                (
                    pdabEntities.Contracts.Include(c => c.Cargo).ToList()
                );
        }
        #endregion
    }
}
