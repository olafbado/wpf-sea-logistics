using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;

namespace pdab.ViewModels
{
    public class NewCargoTypeViewModel:OneViewModel<CargoType>
    {
        #region Konstruktor
        public NewCargoTypeViewModel()
            : base("New Cargo type")
        {
            item = new CargoType();
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
        }
    }
   
    #endregion

    #region Helpers
    public override void Save()
    {
        pdabEntities.CargoTypes.Add(item); //dodaje towar do lokalnej kolekcji 
        pdabEntities.SaveChanges();//zapisuje zmiany do bazy danych
    }
    #endregion

}
}
