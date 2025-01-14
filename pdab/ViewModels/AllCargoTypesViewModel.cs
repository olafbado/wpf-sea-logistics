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
    public class AllCargoTypesViewModel : AllViewModel<CargoType>
    {
        #region Constructor
        public AllCargoTypesViewModel()
            : base("Cargo types")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<CargoType>
                (
                    pdabEntities.CargoTypes.ToList()
                );
        }
        #endregion
        #region sort ant find
        public override List<string> GetSortList()
        {
            return new List<string> { "Name" };
        }

        public override void Sort()
        {
            if (SortField == "Name")
            {
                List = new ObservableCollection<CargoType>(List.OrderBy(c => c.Name));
            }
        }

        public override List<string> GetFindList()
        {
            return new List<string> { "Name" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Name")
            {
                List = new ObservableCollection<CargoType>(List.Where(c => c.Name.ToLower().Contains(FindText.ToLower())).ToList());
            }
        }

        #endregion
    }
}
