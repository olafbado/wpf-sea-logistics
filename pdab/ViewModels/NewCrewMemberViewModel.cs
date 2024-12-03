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
        public int RankId
        {
            get
            {
                return item.RankId;
            }
            set
            {
                item.RankId = value;
                OnPropertyChanged(() => RankId);
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
