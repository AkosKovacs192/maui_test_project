
using Microsoft.Maui.Maps;

namespace MauiApp1.Pages.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public Microsoft.Maui.Controls.Maps.Map map { get; set; }


        public string MapType
        {
            get => _mapType;
            set
            {
                _mapType = value; OnPropertyChanged(nameof(MapType));
                switch(value)
                {
                    case "Street":
                        map.MapType = Microsoft.Maui.Maps.MapType.Street;
                        break;
                    case "Satellite":
                        map.MapType = Microsoft.Maui.Maps.MapType.Satellite;
                        break; 
                    case "Hybrid":
                        map.MapType = Microsoft.Maui.Maps.MapType.Hybrid;
                        break;
                        
                }
              
            }
        }

        private string _mapType;



        public bool Street
        {
            get => _street;
            set
            {
                _street = value; OnPropertyChanged(nameof(Street));
                if(value)
                MapType = "Street";
            }
        }
        public bool _street = true;
        public bool Satellite
        {
            get => _satellite;
            set
            {
                _satellite = value; OnPropertyChanged(nameof(Satellite));
                if (value)
                    MapType = "Satellite";
            }
        }

        public bool _satellite;
        public bool Hybrid
        {
            get => _hybrid;
            set
            {
                _hybrid = value; OnPropertyChanged(nameof(Hybrid));
                if (value)
                    MapType = "Hybrid";
            }
        }
        public bool _hybrid;

        public WelcomeViewModel()
        {




        }




        public Command ReloadLocationCommand => new Command(async () =>
        {
            {


                try
                {
                    await SetLocation();
                }
                catch
                {
                    await App.Current.MainPage.DisplayAlert("Error.", "", "Ok");
                }


            }
        });


        public async Task<int> SetLocation()
        {

            Location location = await GetLocation();
            if (location is null)
                return 0;

            MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);

            map.MoveToRegion(mapSpan);
            return 1;
        }


        private async Task<Location> GetLocation()
        {

            try
            {
                var r = await Geolocation.Default.GetLocationAsync();
                if (r.IsFromMockProvider)
                {
                    await App.Current.MainPage.DisplayAlert("Mock Location.", "", "Ok");
                }
                return r;

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception

                await App.Current.MainPage.DisplayAlert("Location Feature Not Supported", "", "Ok");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await App.Current.MainPage.DisplayAlert("Location Feature Not Enabled.", "", "Ok");
            }
            catch (PermissionException pEx)
            {
                await App.Current.MainPage.DisplayAlert("Location Permission disabled.", "", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error.", "", "Ok");
            }

            return null;

        }

    }



}
