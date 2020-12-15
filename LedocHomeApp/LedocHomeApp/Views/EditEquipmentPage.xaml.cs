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
	public partial class EditEquipmentPage : ContentPage
	{

	    EditEquipmentViewModel viewModel;
        public EditEquipmentPage(EditEquipmentViewModel viewModel)
		{
			InitializeComponent ();


		    //var editEquipmentViewModel = new EditEquipmentViewModel();

		    //editEquipmentViewModel.Equipment = equipment;

		    BindingContext = this.viewModel = viewModel;
        }
	    public EditEquipmentPage()
	    {
	        InitializeComponent();

	        var equipment = new Equipment();
	        {

	        }
	        viewModel = new EditEquipmentViewModel(equipment);
	        BindingContext = viewModel;
	    }
    }
}