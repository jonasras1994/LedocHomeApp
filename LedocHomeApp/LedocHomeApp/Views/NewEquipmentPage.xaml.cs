using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedocHomeApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LedocHomeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewEquipmentPage : ContentPage
	{
        public Equipment Equipment { get; set; }
		public NewEquipmentPage ()
		{
			InitializeComponent ();

		    Equipment = new Equipment
		    {
		        Name = "Navn på Udstyr",
                Make = "Producent af udstyr",
                DateExpiration = DateTime.Now,
                Responsible = "Ansvar",
                DateOfPurchase = DateTime.Now
		    };
		    BindingContext = this;
		}

	    async void Save_Equipment_Clicked(object sender, EventArgs e)
	    {
            MessagingCenter.Send(this, "AddEquipment", Equipment);
	        await Navigation.PopModalAsync();
	    }
	}
}