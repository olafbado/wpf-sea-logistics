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
    public class AllPortFeesViewModel : AllViewModel<PortFee>
    {
        #region Constructor
        public AllPortFeesViewModel()
            : base("Port fees")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PortFee>
                (
                    pdabEntities.PortFees.Include(pf=> pf.Ship).Include(pf => pf.Port).ToList()
                );
        }
        #endregion
    }
}
