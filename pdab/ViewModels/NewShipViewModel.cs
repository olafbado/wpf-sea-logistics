using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Helper;
using System.Windows.Input;
using pdab.Models.BusinessLogic;
using pdab.Models.Entities;
using pdab.Models.EntitiesForView;
using pdab.Models.Validators;
using GalaSoft.MvvmLight.Messaging;


namespace pdab.ViewModels
{
    public class NewShipViewModel:OneViewModel<Ship>, INotifyDataErrorInfo
    {
        #region Konstruktor
        public NewShipViewModel()
            : base("New Ship")
        {
            item = new Ship();
        }
        #endregion
        #region Properties
        //dla każdego pola na interface tworzymy properties
        public string Name
        {
            get
            {
                return item.Name;
            }
            set
            {
                item.Name = value;
                OnPropertyChanged(() => Name);
                ValidateProperty(nameof(Name), value);

            }
        }
        public int ShipTypeId
        {
            get
            {
                return item.ShipTypeId;
            }
            set
            {
                item.ShipTypeId = value;
                OnPropertyChanged(() => ShipTypeId);
            }
        }
        public string Flag
        {
            get
            {
                return item.Flag;
            }
            set
            {
                item.Flag = value;
                OnPropertyChanged(() => Flag);
                ValidateProperty(nameof(Flag), value);

            }
        }

        public int BuildYear
        {
            get
            {
                return item.BuildYear;
            }
            set
            {
                item.BuildYear = value;
                OnPropertyChanged(() => BuildYear);
                ValidateProperty(nameof(BuildYear), value);

            }
        }

        #endregion

        #region validations
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return propertyName != null && _errors.ContainsKey(propertyName) ? _errors[propertyName] : Enumerable.Empty<string>();
        }

        private void ValidateProperty(string propertyName, object value)
        {
            var errors = new List<string>();

            switch (propertyName)
            {
                case nameof(Name):
                    var nameError = StringValidator.CheckIfStartsWithCapitalLetter(value as string);
                    if (!string.IsNullOrEmpty(nameError))
                    {
                        errors.Add(nameError);
                    }
                    break;
                case nameof(Flag):
                    var flagError = StringValidator.CheckIfStartsWithCapitalLetter(value as string);
                    if (!string.IsNullOrEmpty(flagError))
                    {
                        errors.Add(flagError);
                    }
                    break;
                case nameof(BuildYear):
                    var buildYearError = NumberValidator.CheckIfPositive((int)value);
                    if (!string.IsNullOrEmpty(buildYearError))
                    {
                        errors.Add(buildYearError);
                    }
                    break;
            }

            if (errors.Any())
            {
                _errors[propertyName] = errors;
            }
            else
            {
                _errors.Remove(propertyName);
            }

            OnErrorsChanged(propertyName);
        }

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public override bool IsValid()
        {
            var properties = new[] { nameof(Name), nameof(Flag), nameof(BuildYear) };
            var isValid = true;

            foreach (var property in properties)
            {
                ValidateProperty(property, GetType().GetProperty(property)?.GetValue(this));
                if (_errors.ContainsKey(property))
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.Ships.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        public IQueryable<KeyAndValue> ShipTypesItems
        {
            get
            {
                return new ShipTypesLogic(pdabEntities).GetShipTypesKeyAndValueItems();
            }

        }
        #endregion
       

    }
}
