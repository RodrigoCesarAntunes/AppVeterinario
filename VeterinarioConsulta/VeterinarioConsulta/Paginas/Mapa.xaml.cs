using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VeterinarioConsulta.Servicos;
using VeterinarioConsulta.Controles.Mapa;

namespace VeterinarioConsulta.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        private MapaCustomizado mapa = null;

        public Mapa()
        {
            InitializeComponent();
            IniciarMapa();
        }

        private void IniciarMapa()
        {
            mapa = new MapaCustomizado(MapSpan.FromCenterAndRadius(new Position(-23.6581925, -46.7829961),
                Distance.FromKilometers(1)));
            mapa.MapType = MapType.Street;
            stackMapa.Children.Add(mapa);
            MostrarEstabelecimentos();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            mapa.IsShowingUser = true;
            stackInfo.IsVisible = false;
        }

        private void MostrarEstabelecimentos()
        {
            if (mapa == null)
                return;

            var enderecoServico = new EnderecosServico();
            var enderecos = enderecoServico.ObterTodos();

            enderecos.Select(e =>
            {
                var pin = new Pin()
                {
                    Position = new Position(e.Latitude, e.Longitude),
                    Label = "Clique Aqui para mais informações",
                    Address = e.Endereco + ", " + e.Numero
                };
                
                pin.Clicked += OnPinClicado;
                mapa.Pins.Add(pin);
                return pin;
            }).ToList();
            
        }
        
        protected void OnPinClicado(object sender, EventArgs args)
        {
            stackInfo.IsVisible = true;
        }

        private void CloseImageButton_Clicked(object sender, EventArgs e)
        {
            stackInfo.IsVisible = false;
        }
    }
}