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
        public EquipmentDetailPage()
        {
            InitializeComponent();

            var equipment = new Equipment
            {
                //Name = ""
            };

                viewModel = new EquipmentDetailViewModel(equipment);
            BindingContext = viewModel;
        }
    }
}