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
    public class AllCrewAssignmentsViewModel : AllViewModel<CrewAssignment>
    {
        #region Constructor
        public AllCrewAssignmentsViewModel()
            : base("Crew assignments")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<CrewAssignment>
                (
                    pdabEntities.CrewAssignments.Include(ca => ca.CrewMember).Include(ca=> ca.ShipRoute).ToList()
                );
        }
        #endregion
    }
}
