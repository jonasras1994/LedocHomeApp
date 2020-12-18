using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LedocHomeApp.Models;
using LedocHomeApp.ViewModels;
using Xamarin.Forms;

namespace LedocHomeApp.ViewModels
{
public class EquipmentDetailViewModel : BaseViewModel
    {
        //Sørger for at valgt equipment vises i EquipmentDetailView
        EquipmentViewModel _equipmentViewModel = new EquipmentViewModel();

        public Equipment Equipment { get; set; }

        public int EquipmentId { get; set; }

        public EquipmentDetailViewModel(Equipment equipment = null)
        {
            Title = equipment?.Name;
            Equipment = equipment;
        }

        public EquipmentDetailViewModel()
        {
            
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var equipment = new Equipment
                    {
                        EquipmentId = EquipmentId

                    };
                    await _equipmentViewModel.DeleteEquipmentTask(equipment);
                });
            }
        }
    }
}
