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
        #region sort ant find
        public override List<string> GetSortList()
        {
            return new List<string> { "CustomerName", "Cargo", "ContractDate", "DeliveryDeadline" };
        }

        public override void Sort()
        {
            if (SortField == "CustomerName")
            {
                List = new ObservableCollection<Contract>(List.OrderBy(c => c.CustomerName));
            }
            if (SortField == "Cargo")
            {
                List = new ObservableCollection<Contract>(List.OrderBy(c => c.Cargo.Description));
            }
            if (SortField == "ContractDate")
            {
                List = new ObservableCollection<Contract>(List.OrderBy(c => c.ContractDate));
            }

            if (SortField == "DeliveryDeadline")
            {
                List = new ObservableCollection<Contract>(List.OrderBy(c => c.DeliveryDeadline));
            }
        }

        public override List<string> GetFindList()
        {
            return new List<string> { "CustomerName", "Cargo", "ContractDate", "DeliveryDeadline" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "CustomerName")
            {
                List = new ObservableCollection<Contract>(List.Where(c => c.CustomerName.ToLower().Contains(FindText.ToLower())).ToList());
            }
            if (FindField == "Cargo")
            {
                List = new ObservableCollection<Contract>(List.Where(c => c.Cargo.Description.ToLower().Contains(FindText.ToLower())).ToList());
            }
            if (FindField == "ContractDate")
            {
                List = new ObservableCollection<Contract>(List.Where(c => c.ContractDate.ToString().Contains(FindText)).ToList());
            }
            if (FindField == "DeliveryDeadline")
            {
                List = new ObservableCollection<Contract>(List.Where(c => c.DeliveryDeadline.ToString().Contains(FindText)).ToList());
            }
        }

        #endregion
    }
}
