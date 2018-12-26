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
		public Mapa ()
		{
			InitializeComponent ();
            IniciarMapa();
        }

        private void IniciarMapa()
        {
            var mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-23.6581925, -46.7829961),
                Distance.FromKilometers(2)));
            StackMapa.Children.Add(mapa);
            //mapa.MoveToRegion[];
        }
    }
}