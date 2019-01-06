using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarioConsulta.Servicos;
using VeterinarioConsulta.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeterinarioConsulta.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MascotePerfil : ContentPage
    {

        private bool isEditar;

        public MascotePerfil()
        {
            InitializeComponent();
            PreencherPerfil();
            CarregarFotos();
        }



        public void PreencherPerfil()
        {
            var animal = AnimaisServico.AnimalAtual;

            editDescricao.Text = animal.Descricao;
            txtEspecie.Text = animal.Especie;
            txtIdade.Text = animal.Idade;
            txtNome.Text = animal.Nome;
            txtPeso.Text = animal.Peso + "KG";
            txtRaca.Text = animal.Raca;
            txtTamanho.Text = animal.Tamanho;

        }

        private void ToolbarEditar_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Cadastro.AdicionarMascote() {Title = "Editar"});

            if (isEditar)
                Confirmar();
            else
                Editar();

            isEditar = !isEditar;
        }

        private void Editar()
        {
            editDescricao.IsEnabled = true;
            txtEspecie.IsEnabled = true;
            txtIdade.IsEnabled = true;
            txtNome.IsEnabled = true;
            txtPeso.IsEnabled = true;
            txtRaca.IsEnabled = true;
            txtTamanho.IsEnabled = true;

            txtNome.Focus();

            btnToolbar.Text = "Confirmar";
        }

        private void Confirmar()
        {
            editDescricao.IsEnabled = false;
            txtEspecie.IsEnabled = false;
            txtIdade.IsEnabled = false;
            txtNome.IsEnabled = false;
            txtPeso.IsEnabled = false;
            txtRaca.IsEnabled = false;
            txtTamanho.IsEnabled = false;

            btnToolbar.Text = "Editar";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            isEditar = false;
        }

        private void CarregarFotos()
        {
            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += AbriImagem;
            //var Frame = new Frame() { HeightRequest= 20, WidthRequest = 20};
            var img = new Image() { Source = "womenWithDog.png", HeightRequest = 60, WidthRequest = 65};
            var img2 = new Image() { Source = "cachorrinho.png", HeightRequest = 60, WidthRequest = 65};
            var img3 = new Image() { Source = "womenWithDog.png", HeightRequest = 60, WidthRequest = 65 };
            var img4 = new Image() { Source = "cachorrinho.png", HeightRequest = 60, WidthRequest = 65};
            var img5 = new Image() { Source = "womenWithDog.png", HeightRequest = 60, WidthRequest = 65 };
            var img6 = new Image() { Source = "cachorrinho.png", HeightRequest = 60, WidthRequest = 65};
            var img7 = new Image() { Source = "womenWithDog.png", HeightRequest = 60, WidthRequest = 65 };
            var img8 = new Image() { Source = "cachorrinho.png", HeightRequest = 60, WidthRequest = 65};

            img.GestureRecognizers.Add(gestureRecognizer);
            img2.GestureRecognizers.Add(gestureRecognizer);
            img3.GestureRecognizers.Add(gestureRecognizer);
            img4.GestureRecognizers.Add(gestureRecognizer);
            img5.GestureRecognizers.Add(gestureRecognizer);
            img6.GestureRecognizers.Add(gestureRecognizer);
            img7.GestureRecognizers.Add(gestureRecognizer);
            img8.GestureRecognizers.Add(gestureRecognizer);
            
            flexFotos.Children.Add(img);
            flexFotos.Children.Add(img2);
            flexFotos.Children.Add(img3);
            flexFotos.Children.Add(img4);
            flexFotos.Children.Add(img5);
            flexFotos.Children.Add(img6);
            flexFotos.Children.Add(img7);
            flexFotos.Children.Add(img8);
            //flexFotos.Children.Add(new Frame() { Content = img, HeightRequest=60, WidthRequest=60});
            //flexFotos.Children.Add(new Frame() { Content = img2, HeightRequest = 60, WidthRequest = 60 });
            
        }


        private async void AbriImagem(object sender, EventArgs args)
        {
            var img = (sender as Image);
            var Modal = new TratarModal();
            var source = img.Source as FileImageSource;

            await Modal.AbrirModal(new VisualizarImagens() { imagemSource = source.File });
        }

    }
}