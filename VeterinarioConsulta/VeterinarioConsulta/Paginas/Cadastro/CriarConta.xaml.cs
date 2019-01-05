using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeterinarioConsulta.Paginas.Cadastro
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CriarConta : ContentPage
	{
		public CriarConta ()
		{
			InitializeComponent ();
            DefinirFoco();
        }

        private void DefinirFoco()
        {
            txtNome.TextBoxPadrao.Completed += (s, ar) => txtSobrenome.TextBoxPadrao.Focus();
            txtSobrenome.TextBoxPadrao.Completed += (s, ar) => txtEmail.TextBoxPadrao.Focus();
            txtEmail.TextBoxPadrao.Completed += (s, ar) => txtNascimento.TextBoxPadrao.Focus();
            txtNascimento.TextBoxPadrao.Completed += (s, ar) => txtSenha.TextBoxPadrao.Focus();
            txtSenha.TextBoxPadrao.Completed += (s, ar) => txtConfirmarSenha.TextBoxPadrao.Focus();
            txtConfirmarSenha.TextBoxPadrao.Completed += (s, ar) => ExecutarCriarConta();
        }

        private void btnCriarConta_Clicked(object sender, EventArgs e)
        {
            var isValido = VerificarTxts();
            ExecutarCriarConta();

        }

        private void ExecutarCriarConta()
        {
           
        }

        private bool VerificarTxts()
        {
            txtNome.TextBoxPadrao.Focus();
            txtSobrenome.TextBoxPadrao.Focus();
            txtEmail.TextBoxPadrao.Focus();
            txtNascimento.TextBoxPadrao.Focus();
            txtSenha.TextBoxPadrao.Focus();
            txtConfirmarSenha.TextBoxPadrao.Focus();
            txtConfirmarSenha.Unfocus();

            return !(txtNome.IsInvalido && txtSobrenome.IsInvalido && txtEmail.IsInvalido && txtNascimento.IsInvalido && txtSenha.IsInvalido);
        }

        
    }
}