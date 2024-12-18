﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pdab.Models.BusinessLogic;
using pdab.Models.Entities;
using pdab.Models.EntitiesForView;


namespace pdab.ViewModels
{
    public class NewShipTypeCargoTypeViewModel:OneViewModel<ShipTypeCargoType>
    {
        #region Konstruktor
        public NewShipTypeCargoTypeViewModel()
            : base("New Ship type Cargo type")
        {
            item = new ShipTypeCargoType();
        }
        #endregion
        #region Properties
        //dla każdego pola na interface tworzymy properties
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
            pdabEntities.ShipTypeCargoTypes.Add(item); // dodaje towar do lokalnej kolekcji 
            pdabEntities.SaveChanges(); // zapisuje zmiany do bazy danych
        }

        public IQueryable<KeyAndValue> ShipTypeItems
        {
            get
            {
                return new ShipTypesLogic(pdabEntities).GetShipTypesKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> CargoTypeItems
        {
            get
            {
                return new CargoTypesLogic(pdabEntities).GetCargoTypesKeyAndValueItems();
            }
        }
        #endregion

    }
}
