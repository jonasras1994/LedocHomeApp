using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LedocHomeApp.Models;
using Xamarin.Forms;

namespace LedocHomeApp.ViewModels
{
    class NewEquipmentViewModel
    {
        EquipmentViewModel _equipmentViewModel = new EquipmentViewModel();
        public string Name { get; set; }
        public string Make { get; set; }
        public bool Mobile { get; set; }
        public DateTime DateExpiration { get; set; }
        public string Responsible { get; set; }
        public DateTime DateOfPurchase { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var equipment = new Equipment
                    {

                        Name = Name,
                        Make = Make,
                        Mobile = Mobile,
                        DateExpiration = DateExpiration,
                        Responsible = Responsible,
                        DateOfPurchase = DateOfPurchase
                    };
                    await _equipmentViewModel.PostEquipmentTask(equipment);
                });
            }
        }
    }
}
