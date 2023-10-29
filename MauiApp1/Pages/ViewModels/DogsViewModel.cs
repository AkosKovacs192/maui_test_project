using MauiApp1.Models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiApp1.Pages.ViewModels
{
    public class DogsViewModel :BaseViewModel
    {

        private readonly MyHttpClient _httpClient;


        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value; OnPropertyChanged(nameof(IsLoading));
            }
        }
        private bool _isLoading = false;

        public string ImageUri
        {
            get => _imageUri;
            set
            {
                _imageUri = value; OnPropertyChanged(nameof(ImageUri));
            }
        }
        private string _imageUri;

        public Command LoadNewImageCommandAsync => (new Command(async() =>
        {

            IsLoading = true;
            try
            {

                ImageUri = await GetNewImageUri();
               

            }
            catch 
            {
                IsLoading = false;//hide load on error 
                await App.Current.MainPage.DisplayAlert("Error","","Ok");
            }

        }));
        public DogsViewModel(MyHttpClient httpClient)
        {
           // IsLoading = true; //on page load we start the load
            _httpClient = httpClient;

            /*
            GetNewImageUri().ContinueWith((r) =>
            {

                ImageUri = r.Result; // .Resulst if fine as the task already completed

            });*/
            
        }


        private async Task<string> GetNewImageUri()
        {
             

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("No Internet connection!", "This function require internet connection.", "Ok");
                IsLoading = false;
                return ImageUri;
            }

            string resultJson = await _httpClient.GetDataAsync("/api/breeds/image/random");
            IsLoading = false;
            return  JsonSerializer.Deserialize<DogAPIResult>(resultJson).message;

        }

        public  void LoadImageOnAppear()
        {
            LoadNewImageCommandAsync.Execute(this);
        }

    }
}
