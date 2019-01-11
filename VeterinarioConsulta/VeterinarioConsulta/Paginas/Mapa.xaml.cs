using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VeterinarioConsulta.Servicos;
using VeterinarioConsulta.Controles.Mapa;
using Xamarin.Forms.GoogleMaps;

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
            mapa = new MapaCustomizado();
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-23.6581925, -46.7829961),
                Distance.FromKilometers(1)));
            mapa.UiSettings.MyLocationButtonEnabled = true;

            mapa.MapType = MapType.Street;
            stackMapa.Children.Add(mapa);
            MostrarEstabelecimentos();

           
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            mapa.MyLocationEnabled = true;
            stackInfo.IsVisible = false;
        }

        private void MostrarEstabelecimentos()
        {
            if (mapa == null)
                return;

            var enderecoServico = new EnderecosServico();
            var enderecos = enderecoServico.ObterTodos();

            string img = "";

            enderecos.Select(e =>
            {
                if (e.TipoDeEstabelecimento == Utils.TiposPins.Patrocinador)
                    img = "carrinnhoDeCompras.png";
                else
                    img = "hospital.png";

                var pin = new Pin()
                {
                    Icon = BitmapDescriptorFactory.FromBundle(img),
                    Position = new Position(e.Latitude, e.Longitude),
                    Label = e.Titulo,
                    Address = e.Endereco + ", " + e.Numero
                };
                
                mapa.Pins.Add(pin);
                return pin;
            });

            
            mapa.PinClicked += OnPinClicado;
            mapa.MapClicked += CloseImageButton_Clicked;
        }
        
        protected void OnPinClicado(object sender, EventArgs args)
        {
            MostrarInformacoes();
        }

        private void CloseImageButton_Clicked(object sender, EventArgs e)
        {
            EsconderInformacoes();
        }

        private void MostrarInformacoes()
        {
            stackInfo.IsVisible = true;
        }

        private void EsconderInformacoes()
        {
            stackInfo.IsVisible = false;
        }

        private void BtnVer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultorioPerfil() { Title="Consultorio 1"});
        }
        
    }
}