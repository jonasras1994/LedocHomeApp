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
	    EditEquipmentViewModel viewModel;
		public EditOrDeleteEquipmentPage (EditEquipmentViewModel viewModel)
		{
			InitializeComponent ();

		    //var editEquipmentViewModel = new EditEquipmentViewModel();

		    //editEquipmentViewModel.Equipment = equipment;

		    BindingContext = this.viewModel = viewModel;
		}

	    public EditOrDeleteEquipmentPage()
	    {
            InitializeComponent();

	        var equipment = new Equipment
	        {

	        };

            viewModel = new EditEquipmentViewModel(equipment);
	        BindingContext = viewModel;
	    }


	    //async void OnEquipmentSelected(object sender, SelectedItemChangedEventArgs args)
	    //{
	    //    var equipment = args.SelectedItem as Equipment;
	    //    if (equipment == null)
	    //        return;

	    //    await Navigation.PushAsync(new EquipmentDetailPage(new EquipmentDetailViewModel(equipment)));

	    //    EquipmentListView.SelectedItem = null;
	    //}
    }
}