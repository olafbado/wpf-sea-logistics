using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;

namespace pdab.ViewModels
{
    public class NewContractViewModel:OneViewModel<Contract>
    {

        #region Konstruktor
        public NewContractViewModel()
            : base("New Contract")
        {
            item = new Contract();
        }
        #endregion
        #region Properties
        //dla każdego pola na interface tworzymy properties
        public int CargoId
        {
            get
            {
                return item.CargoId;
            }
            set
            {
                item.CargoId = value;
                OnPropertyChanged(() => CargoId);
            }
        }
       
        public string CustomerName
        {
            get
            {
                return item.CustomerName;
            }
            set
            {
                item.CustomerName = value;
                OnPropertyChanged(() => CustomerName);
            }
        }
        public DateTime ContractDate
        {
            get
            {
                return item.ContractDate;
            }
            set
            {
                item.ContractDate = value;
                OnPropertyChanged(() => ContractDate);
            }
        }
        public DateTime DeliveryDeadline
        {
            get
            {
                return item.DeliveryDeadline;
            }
            set
            {
                item.DeliveryDeadline = value;
                OnPropertyChanged(() => DeliveryDeadline);
            }
        }
        #endregion

        #region Helpers
        public override void Save()
        {
            pdabEntities.Contracts.Add(item); //dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion

    }
}
