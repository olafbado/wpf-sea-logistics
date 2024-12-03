using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;

namespace pdab.ViewModels
{
    public class NewCrewMemberViewModel:OneViewModel<CrewMember>
    {
        #region Konstruktor
        public NewCrewMemberViewModel()
            : base("New Crew member")
        {
            item = new CrewMember();
        }
        #endregion
        #region Properties
        //dla każdego pola na interface tworzymy properties
        public string FirstName
        {
            get
            {
                return item.FirstName;
            }
            set
            {
                item.FirstName = value;
                OnPropertyChanged(() => FirstName);
            }
        }
        public string LastName
        {
            get
            {
                return item.LastName;
            }
            set
            {
                item.LastName = value;
                OnPropertyChanged(() => LastName);
            }
        }
        public string Rank
        {
            get
            {
                return item.Rank;
            }
            set
            {
                item.Rank = value;
                OnPropertyChanged(() => Rank);
            }
        }

        public int ShipId
        {
            get
            {
                return item.ShipId;
            }
            set
            {
                item.ShipId = value;
                OnPropertyChanged(() => ShipId);
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.CrewMembers.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion

    }
}
