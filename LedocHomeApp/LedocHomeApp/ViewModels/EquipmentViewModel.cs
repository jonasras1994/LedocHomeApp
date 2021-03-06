﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LedocHomeApp.Models;
using LedocHomeApp.ViewModels;
using LedocHomeApp.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LedocHomeApp.ViewModels
{
    class EquipmentViewModel : BaseViewModel
    {
        public ObservableCollection<Equipment> Equipments { get; set; }
        public Command LoadEquipmentsCommand { get; set; }
        private static readonly HttpClient client = new HttpClient();

        public EquipmentViewModel()
        {
            Equipments = new ObservableCollection<Equipment>();
            LoadEquipmentsCommand = new Command(async () => await ExecuteLoadEquipmentsCommand());

            //MessagingCenter.Subscribe<NewEquipmentPage, Equipment>(this, "AddEquipment", async (obj, equipment) =>
            //{
            //    var newEquipment = equipment as Equipment;
            //    Equipments.Add(newEquipment);
            //    await DataStore.AddItemAsync(newEquipment);
            //});
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



        public async Task PostEquipmentTask(Equipment equipment)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(equipment);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://restserviceledochome.azurewebsites.net/api/equipments/",
                content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Data saved successfully" + response.RequestMessage);
            }
            else
            {
                Debug.WriteLine("An error occured while posting data " + response.StatusCode);
            }
        }

        public async Task PutEquipmentTask(Equipment equipment)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(equipment);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync("https://restserviceledochome.azurewebsites.net/api/equipments/" + equipment.EquipmentId,
                content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Data edited successfully " + response.RequestMessage);
            }
            else
            {
                Debug.WriteLine("An error occured while updating data " + response.StatusCode);
            }
        }

        public async Task DeleteEquipmentTask(Equipment equipment)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(equipment);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.DeleteAsync("https://restserviceledochome.azurewebsites.net/api/equipments/" + equipment.EquipmentId);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Data deleted successfully " + response.RequestMessage + response.StatusCode);
            }
            else
            {
                Debug.WriteLine("An error occured while deleting data " + response.StatusCode);
            }
        }
      
    }
}
