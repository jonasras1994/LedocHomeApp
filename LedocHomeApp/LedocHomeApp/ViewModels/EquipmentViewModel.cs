using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LedocHomeApp.Models;
using LedocHomeApp.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LedocHomeApp.ViewModels
{
    class EquipmentViewModel : BaseViewModel
    {
        public ObservableCollection<Equipment> Equipments { get; set; }
        public Command LoadEquipmentsCommand { get; set; }

        public EquipmentViewModel()
        {
            Equipments = new ObservableCollection<Equipment>();
            LoadEquipmentsCommand = new Command(async () => await ExecuteLoadEquipmentsCommand());

            MessagingCenter.Subscribe<NewEquipmentPage, Equipment>(this, "AddEquipment", async (obj, equipment) =>
            {
                var newEquipment = equipment as Equipment;
                Equipments.Add(newEquipment);
                await DataStore.AddItemAsync(newEquipment);
            });
        }

        private async void PostEquipment()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://restserviceledochome.azurewebsites.net/api/equipments/add");

            //https://forums.xamarin.com/discussion/94945/how-to-post-data-to-rest-api-json 
            string jsonData = @"{""name"" : ""make"" : ""DateExpiration"}"
        }

        async Task ExecuteLoadEquipmentsCommand()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync("https://restserviceledochome.azurewebsites.net/api/equipments");
                ObservableCollection<Equipment> eList = JsonConvert.DeserializeObject<ObservableCollection<Equipment>>(content);

                foreach (var e in eList)
                {
                    Equipments.Add(e);
                }
                }
            }
    }
}
