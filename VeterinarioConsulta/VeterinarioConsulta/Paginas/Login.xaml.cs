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
        }

        private void BtnEntrarCom_Clicado()
        {
            DisplayAlert("teste","google clicado", "cancelar");
        }
    }
}