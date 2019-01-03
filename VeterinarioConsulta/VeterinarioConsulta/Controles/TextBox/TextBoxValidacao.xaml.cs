using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VeterinarioConsulta.Utils;

namespace VeterinarioConsulta.Controles.TextBox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextBoxValidacao : ContentView
    {
        #region Construtor 
        public TextBoxValidacao()
        {
            InitializeComponent();
            txtPadrao.Unfocused += (s, ar) => VerificarTxt();
            txtPadrao.TextChanged += (s, ar) => VerificarTxt();
        }
        #endregion

        #region Propriedades

        public TextBoxPadrao TextBoxPadrao
        {
            get { return txtPadrao; }
        }

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

        public double Largura
        {
            get { return txtPadrao.Width; }
            set
            {
                txtPadrao.WidthRequest = value;
                txtPadrao.MinimumWidthRequest = value;
            }
        }

        public double Altura
        {
            get { return txtPadrao.Height; }
            set
            {
                txtPadrao.HeightRequest = value;
                txtPadrao.MinimumHeightRequest = value;
            }
        }

        public double FontSize
        {
            get { return txtPadrao.FontSize; }
            set { txtPadrao.FontSize = value; }
        }

        public string Text
        {
            get { return txtPadrao.Text; }
            set { txtPadrao.Text = value; }
        }

        public bool ReadOnly
        {
            get { return txtPadrao.InputTransparent; }
            set { txtPadrao.InputTransparent = value; }
        }

        public string TextoAviso
        {
            get { return lblInvalido.Text; }
            set { lblInvalido.Text = value; }
        }

        public bool IsPassword
        {
            get { return txtPadrao.IsPassword; }
            set { txtPadrao.IsPassword = value; }
        }

        public bool Titulo
        {
            get { return lblTitulo.IsVisible; }
            set { lblTitulo.IsVisible = value; }
        }

        public string TituloTexto
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }

        public bool AutoValidacao { get; set; } = false;
        public bool EmailValidacao { get; set; }
        #endregion

        #region Metodos

        private void VerificarTxt()
        {
            if (EmailValidacao)
                ValidarEmail();
            else if (AutoValidacao)
                ValidarVazio();
        }

        private void ValidarVazio()
        {
            if (string.IsNullOrWhiteSpace(txtPadrao.Text))
            {
                TextoAviso = "Preenchimento Obrigatório!";
                IsInvalido = true;
            }
            else if (IsInvalido)
            {
                IsInvalido = false;
            }
        }

        private void ValidarEmail()
        {
            var Validar = new Validar();
            if(Validar.Email(txtPadrao.Text))
            {
                IsInvalido = false;
            }
            else
            {
                TextoAviso = "Email invalido!";
                IsInvalido = true;
            }
        }

        #endregion

    }
}