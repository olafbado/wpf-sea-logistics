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
        #region sort ant find
        public override List<string> GetSortList()
        {
            return new List<string> { "Ship", "Port", "Date", "Amount" };
        }

        public override void Sort()
        {
            if (SortField == "Ship")
            {
                List = new ObservableCollection<PortFee>(List.OrderBy(pf => pf.Ship.Name));
            }
            if (SortField == "Port")
            {
                List = new ObservableCollection<PortFee>(List.OrderBy(pf => pf.Port.Name));
            }
            if (SortField == "Date")
            {
                List = new ObservableCollection<PortFee>(List.OrderBy(pf => pf.Date));
            }
            if (SortField == "Amount")
            {
                List = new ObservableCollection<PortFee>(List.OrderBy(pf => pf.Amount));
            }
        }

        public override List<string> GetFindList()
        {
            return new List<string> { "Ship", "Port", "Date", "Amount" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Ship")
            {
                List = new ObservableCollection<PortFee>(List.Where(pf => pf.Ship.Name.ToLower().Contains(FindText.ToLower())).ToList());
            }
            if (FindField == "Port")
            {
                List = new ObservableCollection<PortFee>(List.Where(pf => pf.Port.Name.ToLower().Contains(FindText.ToLower())).ToList());
            }
            if (FindField == "Date")
            {
                List = new ObservableCollection<PortFee>(List.Where(pf => pf.Date.ToString().Contains(FindText)).ToList());
            }
            if (FindField == "Amount")
            {
                List = new ObservableCollection<PortFee>(List.Where(pf => pf.Amount.ToString().Contains(FindText)).ToList());
            }
        }

        #endregion
    }
}
