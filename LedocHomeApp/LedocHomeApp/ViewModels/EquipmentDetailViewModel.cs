using System;
using System.Collections.Generic;
using System.Text;
using LedocHomeApp.Models;
using LedocHomeApp.ViewModels;

namespace LedocHomeApp.ViewModels
{
public class EquipmentDetailViewModel : BaseViewModel
    {
        public Equipment Equipment { get; set; }

        public EquipmentDetailViewModel(Equipment equipment = null)
        {
            Title = equipment?.Name;
            Equipment = equipment;
        }
    }
}
