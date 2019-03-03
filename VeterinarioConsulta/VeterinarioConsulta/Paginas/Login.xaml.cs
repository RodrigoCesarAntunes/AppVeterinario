using System;
using VeterinarioConsulta.Controles.Carregamento;
using VeterinarioConsulta.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace VeterinarioConsulta.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            IniciarBotoesDeLogin();
        }

        private async void btnEntrar_Clicked(object sender, EventArgs e)
        {
            if(lblInvalido.IsVisible == true)
            {
                var Modal = new TratarModal();
                await Modal.AbrirModal(new ModalDeCarregamento() { Texto = "Entrando..."});
                
                await App.Current.MainPage.Navigation.PushModalAsync(new Home());
                //App.Current.MainPage = new NavigationPage(new Home()) { BarBackgroundColor = Color.DimGray, BarTextColor = Color.White };
                await Modal.FecharModal();
            }

            lblInvalido.IsVisible = true;
            
        }

        private void IniciarBotoesDeLogin()
        {
            var tapRecognizerGoogle = new TapGestureRecognizer();
            tapRecognizerGoogle.Tapped += (s, ar) => BtnEntrarCom_Clicado();
            if(BtnLoginComGoogle.GestureRecognizers.Count == 0)
                BtnLoginComGoogle.GestureRecognizers.Add(tapRecognizerGoogle);

            BoxUnderline.WidthRequest = (lblCriarConta.Width * 1.1);
            

            var tapRecognizerCriarConta = new TapGestureRecognizer();
            tapRecognizerCriarConta.Tapped += (s, ar) => 
            {
                Navigation.PushAsync( new Cadastro.CriarConta() { Title = "Criar Conta"});
            };
            if(lblCriarConta.GestureRecognizers.Count == 0)
                lblCriarConta.GestureRecognizers.Add(tapRecognizerCriarConta);
        }

        private void BtnEntrarCom_Clicado()
        {
            DisplayAlert("teste","google clicado", "cancelar");
        }

      
    }
}