﻿using System;
using VeterinarioConsulta.Controles.Carregamento;
using VeterinarioConsulta.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeterinarioConsulta.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            IniciarBotoesDeLogin();
            NavigationPage.SetHasNavigationBar(this, false);
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
            BtnLoginComGoogle.GestureRecognizers.Add(tapRecognizerGoogle);

            // Essa logica é para que o tamanho da borda a baixo do 
            // label Criar Conta seja igual a do label
            BoxUnderline.WidthRequest = (lblCriarConta.Width * 1.3);
            

            var tapRecognizerCriarConta = new TapGestureRecognizer();
            tapRecognizerCriarConta.Tapped += (s, ar) => 
            {
                App.Current.MainPage.Navigation.PushAsync( new Cadastro.CriarConta() { Title = "Criar Conta"});
            };
            lblCriarConta.GestureRecognizers.Add(tapRecognizerCriarConta);
        }

        private void BtnEntrarCom_Clicado()
        {
            DisplayAlert("teste","google clicado", "cancelar");
        }
    }
}