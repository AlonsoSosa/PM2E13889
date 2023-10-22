using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace PM2ExamenC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMap : ContentPage
    {
        public PageMap()
        {
            InitializeComponent();
        }

        protected override async void ChangeVisualState()
        {
                base.OnAppearing();

            var conexion = Connectivity.NetworkAccess;
            var locl = CrossGeolocator.Current;

            if(conexion == NetworkAccess.Internet)
            {
                if(locl != null)
                {
                    locl.PositionChanged += Locl_PositionChanged;

                    if(!locl.IsListening)
                    {
                        await locl.StartListeningAsync(TimeSpan.FromSeconds(10), 100);

                    }

                    var posicion = await locl.GetPositionAsync();
                    var mapcenter = new Xamarin.Forms.Maps.Position(posicion.Latitude, posicion.Longitude);

                    var pin = new Pin { Type = PinType.Place, Position = mapcenter, Label ="Mi Ubicacion", Address = "Mi Ubicacion" };
                    mapa.Pins.Add(pin);
                    mapa.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(mapcenter , 0.5, 0.5));

                }

                else
                {
                    var posicion = await locl.GetLastKnownLocationAsync();
                    var mapcenter = new Xamarin.Forms.Maps.Position(posicion.Latitude, posicion.Longitude);
                    var pin = new Pin { Type = PinType.Place, Position = mapcenter, Label = "Mi Ultima Ubicacion", Address = "Mi Ultima Ubicacion" };

                    mapa.Pins.Add(pin);
                    mapa.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(mapcenter, 0.5, 0.5));

                }
            }
            
        }

        private void Locl_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var mapcenter = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            mapa.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(mapcenter, 1, 1));
        }
    }
}