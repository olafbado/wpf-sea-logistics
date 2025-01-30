using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using pdab.Models.EntitiesForView;
using pdab.Models.BusinessLogic;
using GalaSoft.MvvmLight.Messaging;
using static pdab.ViewModels.NewShipRouteViewModel;
using pdab.Helper;
using System.Windows.Input;



namespace pdab.ViewModels
{
    public class NewCrewAssignmentViewModel : OneViewModel<CrewAssignment>
    {
        #region Konstruktor
        public NewCrewAssignmentViewModel()
            : base("New Crew assignment")
        {
            item = new CrewAssignment();
            Messenger.Default.Register<ShipRoute>(this, getSelectedShipRoute);
            Messenger.Default.Register<CrewMember>(this, getSelectedCrewMember);
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

        public string ShipRouteName {
            get;
            set;
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

        public string CrewMemberName
        {
            get;
            set;
        }

        #endregion


        #region Helpers
        private BaseCommand _ShowShipRoutes;
        public ICommand ShowShipRoutes
        {
            get
            {
                if (_ShowShipRoutes == null)
                    _ShowShipRoutes = new BaseCommand(() => showShipRoutes());
                return _ShowShipRoutes;
            }
        }

        private void showShipRoutes()
        {
            Messenger.Default.Send("AllShipRoutes");
        }

        private BaseCommand _ShowCrewMembers;
        public ICommand ShowCrewMembers
        {
            get
            {
                if (_ShowCrewMembers == null)
                    _ShowCrewMembers = new BaseCommand(() => showCrewMembers());
                return _ShowCrewMembers;
            }
        }

        private void showCrewMembers()
        {
            Messenger.Default.Send("AllCrewMembers");
        }


        private void getSelectedShipRoute(ShipRoute shipRoute) { 
            ShipRouteName = shipRoute.Name;
            ShipRouteId = shipRoute.Id;
        }

        private void getSelectedCrewMember(CrewMember crewMember)
        {
            CrewMemberId = crewMember.Id;
            CrewMemberName = crewMember.FirstName + " " + crewMember.LastName;
        }

        public override void Save()
        {
            pdabEntities.CrewAssignments.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }

        public IQueryable<KeyAndValue> ShipRouteItems
        {
            get
            {
                return new ShipRouteLogic(pdabEntities).GetShipRoutesKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> CrewMemberItems
        {
            get
            {
                return new CrewMemberLogic(pdabEntities).GetCrewMembersKeyAndValueItems();
            }
        }
        #endregion

    }
}
