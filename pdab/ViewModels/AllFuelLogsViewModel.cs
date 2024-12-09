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
    public class AllFuelLogsViewModel : AllViewModel<FuelLog>
    {
        #region Constructor
        public AllFuelLogsViewModel()
            : base("Fuel logs")
        {
        }
        #endregion
        #region Helpers
        //metoda load pobiera wszystkie towary z bazy danych 
        public override void Load()
        {
            List = new ObservableCollection<FuelLog>
                (
                    pdabEntities.FuelLogs.Include(fl => fl.Ship).ToList()
                //z bazy danych, pobieram Towar i wszystkie rekordy zamieniam na listę
                );
        }
        #endregion
    }
}
