using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            if(lblInvalido.IsVisible == true)
                App.Current.MainPage = new Home();

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
            tapRecognizerCriarConta.Tapped += (s, ar) => { };
            lblCriarConta.GestureRecognizers.Add(tapRecognizerCriarConta);
        }

        private void BtnEntrarCom_Clicado()
        {
            DisplayAlert("teste","google clicado", "cancelar");
        }
    }
}