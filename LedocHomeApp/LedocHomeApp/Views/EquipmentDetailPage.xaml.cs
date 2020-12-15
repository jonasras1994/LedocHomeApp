﻿using System;
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
        public EquipmentDetailPage()
        {
            InitializeComponent();

            var equipment = new Equipment
            {
            };

                viewModel = new EquipmentDetailViewModel(equipment);
            BindingContext = viewModel;
        }

	    async void EditEquipment_Clicked(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new EditEquipmentPage(new EditEquipmentViewModel()));
	    }

	    async void OnEquipmentSelected(object sender, SelectedItemChangedEventArgs args)
	    {
	        var equipment = args.SelectedItem as Equipment;
	        if (equipment == null)
	            return;

	        await Navigation.PushAsync(new EquipmentDetailPage(new EquipmentDetailViewModel(equipment)));

	        //EquipmentListView.SelectedItem = null;
	    }
    }
}