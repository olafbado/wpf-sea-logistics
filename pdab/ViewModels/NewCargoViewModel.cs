using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.BusinessLogic;
using pdab.Models.Entities;
using pdab.Models.EntitiesForView;
using pdab.Models.Validators;


namespace pdab.ViewModels
{
    public class NewCargoViewModel:OneViewModel<Cargo>, INotifyDataErrorInfo
    {
        #region Konstruktor
        public NewCargoViewModel()
            : base("New cargo")
        {
            item = new Cargo();
        }
        #endregion
        #region Properties
        public string Description
        {
            get
            {
                return item.Description;
            }
            set
            {
                item.Description = value;
                OnPropertyChanged(() => Description);
                ValidateProperty(nameof(Description), value);
            }
        }

        public int Weight
        {
            get
            {
                return item.Weight;
            }
            set
            {
                item.Weight = value;
                OnPropertyChanged(() => Weight);
                ValidateProperty(nameof(Weight), value);
            }
        }

        public int CargoTypeId
        {
            get
            {
                return item.CargoTypeId;
            }
            set
            {
                item.CargoTypeId = value;
                OnPropertyChanged(() => CargoTypeId);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.Cargos.Add(item);
            pdabEntities.SaveChanges();
        }

        #region validations
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        private void ValidateProperty(string propertyName, object value)
        {
            var errors = new List<string>();

            switch (propertyName)
            {
                case nameof(Description):
                    var descriptionError = StringValidator.CheckIfStartsWithCapitalLetter(value as string);
                    if (!string.IsNullOrEmpty(descriptionError))
                    {
                        errors.Add(descriptionError);
                    }
                    break;
                case nameof(Weight):
                    var weightError = NumberValidator.CheckIfPositive((int)value);
                    if (!string.IsNullOrEmpty(weightError))
                    {
                        errors.Add(weightError);
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
            return !HasErrors;
        }

        #endregion 
        public IQueryable<KeyAndValue> CargoTypesItems
        {
            get
            {
                return new CargoTypesLogic(pdabEntities).GetCargoTypesKeyAndValueItems();
            }
        }
        #endregion

    }
}
