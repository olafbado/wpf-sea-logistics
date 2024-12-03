using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.Entities;
using pdab.Models.EntitiesForView;

namespace pdab.ViewModels
{
    public class NewShipTypeViewModel:OneViewModel<ShipType>
    {
        #region Konstruktor
        public NewShipTypeViewModel()
            : base("New Ship type")
        {
            item = new ShipType();
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
            pdabEntities.ShipTypes.Add(item); // dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges(); // zapisuje zmiany do bazy danych
        }
        
        #endregion

    }
}
