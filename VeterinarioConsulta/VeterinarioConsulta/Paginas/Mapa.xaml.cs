using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VeterinarioConsulta.Servicos;

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
            MostrarEstabelecimentos();
            //mapa.MoveToRegion[];
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            mapa.IsShowingUser = true;
        }

        private void MostrarEstabelecimentos()
        {
            if (mapa == null)
                return;

            var enderecoServico = new EnderecosServico();
            var enderecos = enderecoServico.ObterTodos();

            enderecos.Select(e =>
                {
                    var pin = new Pin();
                    mapa.Pins.Add(new Pin()
                    {
                        Position = new Position(e.Latitude, e.Longitude),
                        Label = "Consultorio 1",
                        Address = e.Endereco + " " + e.Numero
                    });
                    return pin;
                }
            ).ToList();

            
        }
    }
}