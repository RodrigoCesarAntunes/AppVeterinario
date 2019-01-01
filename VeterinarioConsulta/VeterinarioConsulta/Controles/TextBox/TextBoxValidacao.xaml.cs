using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeterinarioConsulta.Controles.TextBox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextBoxValidacao : ContentView
    {
        #region Construtor 
        public TextBoxValidacao()
        {
            InitializeComponent();
            txtPadrao.Unfocused += (s, ar) => VerificarTxtVazio();
            txtPadrao.TextChanged += (s, ar) => VerificarTxtVazio();
        }
        #endregion

        #region Propriedades

        public bool IsInvalido
        {
            get { return txtPadrao.IsInvalido; }
            set
            {
                txtPadrao.IsInvalido = value;
                lblInvalido.IsVisible = value;
            }
        }

        public Keyboard Keyboard
        {
            get { return txtPadrao.Keyboard; }
            set { txtPadrao.Keyboard = value; }
        }

        public string Placeholder
        {
            get { return txtPadrao.Placeholder; }
            set { txtPadrao.Placeholder = value; }
        }

        public string Text
        {
            get { return txtPadrao.Text; }
            set { txtPadrao.Text = value; }
        }

        public string TextoAviso
        {
            get { return lblInvalido.Text; }
            set { lblInvalido.Text = value; }
        }

        public bool AutoValidacao {get; set;}

        #endregion

        #region Metodos

        private void VerificarTxtVazio()
        {
            if (!AutoValidacao)
                return;

            if(string.IsNullOrWhiteSpace(txtPadrao.Text))
            {
                TextoAviso = "Preenchimento Obrigatório!";
                IsInvalido = true;
            }
            else if(IsInvalido)
            {
                IsInvalido = false;
            }
        }

        #endregion

    }
}