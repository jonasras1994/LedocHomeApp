using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LedocHomeApp.Models;
using Xamarin.Forms;

namespace LedocHomeApp.ViewModels
{
    public class EditEquipmentViewModel
    {
        EquipmentViewModel _equipmentViewModel = new EquipmentViewModel();
        
        public Equipment Equipment { get; set; }

        public ICommand PutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _equipmentViewModel.PutEquipmentTask(Equipment);
                });
            }
        }
    }
}
