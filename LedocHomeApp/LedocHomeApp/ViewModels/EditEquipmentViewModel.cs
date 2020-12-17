using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LedocHomeApp.Models;
using Xamarin.Forms;

namespace LedocHomeApp.ViewModels
{
    public class EditEquipmentViewModel : BaseViewModel
    {
        EquipmentViewModel _equipmentViewModel = new EquipmentViewModel();

        public Equipment Equipment { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _equipmentViewModel.PutEquipmentTask(Equipment);
                });
            }
        }

        public EditEquipmentViewModel(Equipment equipment = null)
        {
            Title = equipment?.Name;
            Equipment = equipment;
        }
    }
}
