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
	public partial class EquipmentPage : ContentPage
	{
	    EquipmentViewModel viewModel;
		public EquipmentPage ()
		{
			InitializeComponent ();

		    BindingContext = viewModel = new EquipmentViewModel();
		}

	    async void OnEquipmentSelected(object sender, SelectedItemChangedEventArgs args)
	    {
	        var equipment = args.SelectedItem as Equipment;
	        if (equipment == null)
	        return;
	        
	        await Navigation.PushAsync(new EquipmentDetailPage(new EquipmentDetailViewModel(equipment)));

	        EquipmentListView.SelectedItem = null;
	    }

	    async void AddEquipment_Clicked(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new NavigationPage(new NewEquipmentPage()));
	    }


	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        if (viewModel.Equipments.Count == 0)
	        viewModel.LoadEquipmentsCommand.Execute(null);
	    }
	}
}