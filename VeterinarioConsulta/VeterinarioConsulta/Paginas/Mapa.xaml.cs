using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeterinarioConsulta.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mapa : ContentPage
	{
        private Map mapa = null;

		public Mapa ()
		{
			InitializeComponent ();
            IniciarMapa();
        }

        private void IniciarMapa()
        {
            mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-23.6581925, -46.7829961),
                Distance.FromKilometers(2)));
            mapa.MapType = MapType.Street;
            StackMapa.Children.Add(mapa);
            
            //mapa.MoveToRegion[];
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            mapa.IsShowingUser = true;
        }
    }
}