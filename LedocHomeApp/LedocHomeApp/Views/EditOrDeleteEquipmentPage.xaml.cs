using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedocHomeApp.Models;
using LedocHomeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LedocHomeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditOrDeleteEquipmentPage : ContentPage
	{
		public EditOrDeleteEquipmentPage (Equipment equipment)
		{
			InitializeComponent ();

		    var editEquipmentViewModel = new EditEquipmentViewModel();

		    editEquipmentViewModel.Equipment = equipment;

		    BindingContext = editEquipmentViewModel;
		}
	}
}