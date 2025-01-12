using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using pdab.Helper;
using pdab.Models.Entities;

namespace pdab.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields

        private ReadOnlyCollection<CommandViewModel> _commands;
        private ObservableCollection<WorkspaceViewModel> _workspaces;

        private readonly Dictionary<string, (Func<WorkspaceViewModel> All, Func<WorkspaceViewModel> New)> _workspaceFactories;

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            Messenger.Default.Register<string>(this, Open);
            //Messenger.Default.Register<string>(this, Refresh);
            // Define both "All" and "New" workspace factories
            _workspaceFactories = new Dictionary<string, (Func<WorkspaceViewModel>, Func<WorkspaceViewModel>)>
            {
                 { "Ranks", (() => new AllRanksViewModel(), () => new NewRankViewModel()) },
                 { "Ship types", (() => new AllShipTypesViewModel(), () => new NewShipTypeViewModel()) },
                  { "Cargo types", (() => new AllCargoTypesViewModel(), () => new NewCargoTypeViewModel()) },
                  { "Fuel logs", (() => new AllFuelLogsViewModel(), () => new NewFuelLogViewModel()) },
                   { "Contracts", (() => new AllContractsViewModel(), () => new NewContractViewModel()) },
                   { "Cargos", (() => new AllCargosViewModel(), () => new NewCargoViewModel()) },
                   { "Ship inspections", (() => new AllShipInspectionsViewModel(), () => new NewShipInspectionViewModel()) },
                   { "Ships", (() => new AllShipsViewModel(), () => new NewShipViewModel()) },
                   { "Ship maintenances", (() => new AllShipMaintenancesViewModel(), () => new NewShipMaintenanceViewModel()) },
                   { "Ship cargos", (() => new AllShipCargosViewModel(), () => new NewShipCargoViewModel()) },
                  { "Port fees", (() => new AllPortFeesViewModel(), () => new NewPortFeeViewModel()) },
                  { "Ship routes", (() => new AllShipRoutesViewModel(), () => new NewShipRouteViewModel()) },
                   { "Crew members", (() => new AllCrewMembersViewModel(), () => new NewCrewMemberViewModel()) },

            { "Crew assignments", (() => new AllCrewAssignmentsViewModel(), () => new NewCrewAssignmentViewModel()) },
            { "Ports", (() => new AllPortsViewModel(), () => new NewPortViewModel()) },
             { "Ship types Cargo types", (() => new AllShipTypesCargoTypesViewModel(), () => new NewShipTypeCargoTypeViewModel()) }
        };
        }

        #endregion

        #region Commands

        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_commands == null)
                {
                    // Create both "All" and "New" commands for each factory
                    var cmds = _workspaceFactories.SelectMany(kvp => new[]
                    {
                        new CommandViewModel($"All {kvp.Key}", new BaseCommand(() => ShowWorkspace(kvp.Key, true))),
                        new CommandViewModel($"New {kvp.Key.TrimEnd('s')}", new BaseCommand(() => ShowWorkspace(kvp.Key, false)))
                    }).ToList();

                    _commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _commands;
            }
        }

        #endregion

        #region Workspaces

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += OnWorkspacesChanged;
                }
                return _workspaces;
            }
        }

        private void OnWorkspacesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += OnWorkspaceRequestClose;
            }

            if (e.OldItems != null)
            {
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= OnWorkspaceRequestClose;
            }
        }

        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            if (sender is WorkspaceViewModel workspace)
                Workspaces.Remove(workspace);
        }

        #endregion

        #region Private Helpers

        private void ShowWorkspace(string workspaceKey, bool showAll)
        {
            // Select the appropriate factory based on "All" or "New"
            var workspaceFactory = showAll
                ? _workspaceFactories[workspaceKey].All
                : _workspaceFactories[workspaceKey].New;

            var workspace = Workspaces.FirstOrDefault(vm => vm.GetType() == workspaceFactory().GetType());
            if (workspace == null)
            {
                workspace = workspaceFactory();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            collectionView?.MoveCurrentTo(workspace);
        }


        private void Open(string message)
        {
            if (message.StartsWith("Add"))
            {
                var newView = _workspaceFactories[message.Substring(3)].New();
                this.Workspaces.Add(newView);
                this.SetActiveWorkspace(newView);
            }
        }

        private void Refresh(string message)
        {
            if (message.StartsWith("Refresh"))
            {
                var workspaceKey = message.Substring(7).Trim();
                var workspace = Workspaces.FirstOrDefault(vm => vm.GetType() == _workspaceFactories[workspaceKey].All().GetType());
                if (workspace != null)
                {
                    if (workspace is AllViewModel<Ship> allViewModel)
                    {
                        allViewModel.Load();
                    }
                }
            }
        } 
        


        #endregion
    }
}
