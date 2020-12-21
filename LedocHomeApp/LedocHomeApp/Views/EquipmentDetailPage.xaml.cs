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
	public partial class EquipmentDetailPage : ContentPage
	{
	    EquipmentDetailViewModel viewModel;
		public EquipmentDetailPage (EquipmentDetailViewModel viewModel)
		{
			InitializeComponent();

		    BindingContext = this.viewModel = viewModel;
        }

	    //async void OnEquipmentSelected(object sender, SelectedItemChangedEventArgs args)
	    //{
	    //    var equipment = args.SelectedItem as Equipment;
	    //    if (equipment == null)
	    //        return;

	    //    await Navigation.PushAsync(new EditEquipmentPage(new EditEquipmentViewModel(equipment)));

	    //    EquipmentListView.SelectedItem = null;
	    //}

        public EquipmentDetailPage()
        {
            InitializeComponent();

            var equipment = new Equipment
            {
            };

                viewModel = new EquipmentDetailViewModel(equipment);
            BindingContext = viewModel;
        }

	    public async void EditEquipment_Clicked(object sender, EventArgs e)
	    {
	        Equipment equipment = null;
	        await this.Navigation.PushAsync(new EditEquipmentPage(new EditEquipmentViewModel(viewModel.Equipment)));
	    }  
    }
}