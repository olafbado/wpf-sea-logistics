using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using pdab.Models.BusinessLogic;
using pdab.Models.Entities;
using pdab.Models.EntitiesForView;
using pdab.Models.Validators;

namespace pdab.ViewModels
{
    public class NewFuelLogViewModel:OneViewModel<FuelLog>, INotifyDataErrorInfo
    {

        #region Konstruktor
        public NewFuelLogViewModel()
            : base("New Fuel log")
        {
            item = new FuelLog();
        }
    #endregion
    #region Properties
    //dla każdego pola na interface tworzymy properties
    public int Quantity
    {
        get
        {
            return item.Quantity;
        }
        set
        {
            item.Quantity = value;
            OnPropertyChanged(() => Quantity);
            ValidateProperty(nameof(Quantity), value);

            }
        }
        public int Cost
        {
            get
            {
                return item.Cost;
            }
            set
            {
                item.Cost = value;
                OnPropertyChanged(() => Cost);
                ValidateProperty(nameof(Cost), value);


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
    public DateTime Date
    {
        get
        {
            return item.Date;
        }
        set
        {
            item.Date = value;
            OnPropertyChanged(() => Date);
        }
    }
    public string FuelType
    {
        get
        {
            return item.FuelType;
        }
        set
        {
            item.FuelType = value;
            OnPropertyChanged(() => FuelType);
            ValidateProperty(nameof(FuelType), value);

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
                case nameof(FuelType):
                    var fuelError = StringValidator.CheckIfStartsWithCapitalLetter(value as string);
                    if (!string.IsNullOrEmpty(fuelError))
                    {
                        errors.Add(fuelError);
                    }
                    break;
                case nameof(Quantity):
                    var quantityError = NumberValidator.CheckIfPositive((int)value);
                    if (!string.IsNullOrEmpty(quantityError))
                    {
                        errors.Add(quantityError);
                    }
                    break;
                case nameof(Cost):
                    var costError = NumberValidator.CheckIfPositive((int)value);
                    if (!string.IsNullOrEmpty(costError))
                    {
                        errors.Add(costError);
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
            var properties = new[] { nameof(FuelType), nameof(Quantity), nameof(Cost) };
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

        public string GetValidationErrors()
        {
            var errors = new StringBuilder();
            foreach (var error in _errors)
            {
                errors.AppendLine($"{error.Key}: {string.Join(", ", error.Value)}");
            }
            return errors.ToString();
        }
        #endregion

        #region Helpers
        public override void Save()
    {
        pdabEntities.FuelLogs.Add(item); //dodaje towar do lokalnej kolekcji 
        pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
    }



        public IQueryable<KeyAndValue> ShipItems
        {
            get
            {
                return new ShipLogic(pdabEntities).GetShipsKeyAndValueItems();
            }
        }
    #endregion

}
}
