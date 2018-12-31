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
            App.Current.MainPage = new Home();
        }

        private void IniciarBotoesDeLogin()
        {
            var tapRecognizerGoogle = new TapGestureRecognizer();
            tapRecognizerGoogle.Tapped += (s, ar) => BtnLoginComGoogle_Clicado();
            BtnLoginComGoogle.GestureRecognizers.Add(tapRecognizerGoogle);
        }

        private void BtnLoginComGoogle_Clicado()
        {
            DisplayAlert("teste","google clicado", "cancelar");
        }
    }
}