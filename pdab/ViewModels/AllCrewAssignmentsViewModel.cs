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
        #region sort ant find
        public override List<string> GetSortList()
        {
            return new List<string> { "CrewMemberFirstName", "CrewMemberLastName", "ShipRoute" };

        }

        public override void Sort()
        {
            if (SortField == "CrewMemberFirstName")
            {
                List = new ObservableCollection<CrewAssignment>(List.OrderBy(ca => ca.CrewMember.FirstName));
            }
            if (SortField == "ShipRoute")
            {
                List = new ObservableCollection<CrewAssignment>(List.OrderBy(ca => ca.ShipRoute.Name));
            }
            if (SortField == "CrewMemberLastName")
            {
                List = new ObservableCollection<CrewAssignment>(List.OrderBy(ca => ca.CrewMember.LastName));
            }
        }

        public override List<string> GetFindList()
        {
            return new List<string> { "CrewMemberFirstName", "ShipRoute", "CrewMemberLastName" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "CrewMemberFirstName")
            {
                List = new ObservableCollection<CrewAssignment>(List.Where(ca => ca.CrewMember.FirstName != null && ca.CrewMember.FirstName.Contains(FindText, StringComparison.OrdinalIgnoreCase)).ToList());
            }
            if (FindField == "ShipRoute")
            {
                List = new ObservableCollection<CrewAssignment>(List.Where(ca => ca.ShipRoute.Name != null && ca.ShipRoute.Name.Contains(FindText, StringComparison.OrdinalIgnoreCase)).ToList());
            }
            if (FindField == "CrewMemberLastName")
            {
                List = new ObservableCollection<CrewAssignment>(List.Where(ca => ca.CrewMember.LastName != null && ca.CrewMember.LastName.Contains(FindText, StringComparison.OrdinalIgnoreCase)).ToList());
            }
        }

        #endregion
    }
}
