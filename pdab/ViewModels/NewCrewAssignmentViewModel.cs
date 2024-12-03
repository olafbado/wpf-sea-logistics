using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;

namespace pdab.ViewModels
{
    public class NewCrewAssignmentViewModel:OneViewModel<CrewAssignment>
    {
        #region Konstruktor
        public NewCrewAssignmentViewModel()
            : base("New Crew assignment")
        {
            item = new CrewAssignment();
        }
        #endregion
        #region Properties
        //dla każdego pola na interface tworzymy properties
        public int ShipRouteId
        {
            get
            {
                return item.ShipRouteId;
            }
            set
            {
                item.ShipRouteId = value;
                OnPropertyChanged(() => ShipRouteId);
            }
        }
        public int CrewMemberId
        {
            get
            {
                return item.CrewMemberId;
            }
            set
            {
                item.CrewMemberId = value;
                OnPropertyChanged(() => CrewMemberId);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.CrewAssignments.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion

    }
}
