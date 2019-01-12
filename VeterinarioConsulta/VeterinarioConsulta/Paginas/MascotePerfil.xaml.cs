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
using XLabs.Forms.Behaviors;
using XLabs.Forms.Controls;

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
            var imgUrls = new List<string>()
            {
                "https://tse1.mm.bing.net/th?id=OIP.9yocuO41upqAIOlDzhhTNAHaFj&pid=Api&w=4608&h=3456&rs=1&p=0",
                "https://tse4.mm.bing.net/th?id=OIP.fDLMQup89hGLeC31AHJaNgHaE7&pid=Api&w=1920&h=1277&rs=1&p=0",
                "https://www.caonosso.pt/uploads/racas_galeria/image%5B379%5D.jpg",
                "https://www.caonosso.pt/uploads/racas_galeria/image[320].jpg",
                "http://www.casamalana.com/wp-content/uploads/2017/07/20170321152046_IMG_2446.jpg",
                "https://www.mascotarios.org/wp-content/gallery/perro-de-montana-de-estrela/perro-de-montana-de-estrela92.jpg",
                "http://1.bp.blogspot.com/-zSkh5w1jpDI/VWfbX5pjYbI/AAAAAAAAAn8/Hfgr9NGQfBk/s1600/Cane-Corso-3.jpg",
                "https://www.caonosso.pt/uploads/racas_galeria/image%5B378%5D.jpg"

            };

            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += AbriImagem;
            

            imgUrls.ForEach(i =>
                {
                    var img = new Image()
                    {
                        Source = ImageSource.FromUri(new Uri(i)),
                        Aspect = Aspect.AspectFit,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HeightRequest = 60,
                        WidthRequest = 60,
                        Margin = new Thickness(4, 1)
                    };
                    img.GestureRecognizers.Add(gestureRecognizer);
                    var frame = new Frame() { HeightRequest = 60, WidthRequest = 60, Padding = 1, Content = img };
                    flexFotos.Children.Add(frame);
                }
            );

        }


        private async void AbriImagem(object sender, EventArgs args)
        {
            var img = (sender as Image);
            var Modal = new TratarModal();
            var source = img.Source as FileImageSource;

            //await Modal.AbrirModal(new VisualizarImagens() { imagemSource = source.File });
            await Modal.AbrirModal(new VisualizarImagens() { imagemSourceUri = img.Source });
        }

        protected void GesturesContentView_GestureRecognized(object sender, GestureResult e)
        {
            switch (e.GestureType)
            {
                case GestureType.LongPress:
                    //Add code here
                    break;
                case GestureType.SingleTap:
                    // Add code here                    
                    break;
                case GestureType.DoubleTap:
                    // Add code here
                    break;
                default:
                    break;
            }

        }

    }
}