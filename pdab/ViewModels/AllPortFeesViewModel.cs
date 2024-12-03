using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using System.Windows.Documents;

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
        //metoda load pobiera wszystkie towary z bazy danych 
        public override void Load()
        {
            List = new ObservableCollection<PortFee>
                (
                    pdabEntities.PortFees.ToList()
                //z bazy danych, pobieram Towar i wszystkie rekordy zamieniam na listę
                );
        }
        #endregion
    }
}
