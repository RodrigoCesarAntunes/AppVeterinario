﻿using System;
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
            txtPadrao.Focused += (s, ar) => VerificarTxt();
            
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

        //public bool AutoValidacao { get; set; } = false;
        /// <summary>
        /// Valores que podem ser passados:
        /// Email, Vazio (verifica se o campo é vazio), Data
        /// </summary>
        public TiposDeValidacao ValidarDado { get; set; } = TiposDeValidacao.Nada;
        #endregion

        #region Metodos

        private void VerificarTxt()
        {
            if (ValidarDado == TiposDeValidacao.Nada)
                return;

            switch (ValidarDado)
            {
                case TiposDeValidacao.Email:
                    txtPadrao.Unfocused += (s, ar) => ValidarEmail();
                    txtPadrao.TextChanged += (s, ar) => ValidarEmail();
                    txtPadrao.MaxLength = 255;
                    break;
                case TiposDeValidacao.Vazio:
                    txtPadrao.Unfocused += (s, ar) => ValidarVazio();
                    txtPadrao.TextChanged += (s, ar) => ValidarVazio();
                    txtPadrao.MaxLength = 255;
                    break;
                case TiposDeValidacao.Data:
                    txtPadrao.Unfocused += (s, ar) => ValidarData();
                    txtPadrao.TextChanged += (s, ar) => TextoData(ar);
                    txtPadrao.MaxLength = 10;
                    break;
            }

            //else if (AutoValidacao)
            //    ValidarVazio();
        }

        private void ValidarData()
        {
           

            var Validar = new Validar();
            if (Validar.Data(txtPadrao.Text))
            {
                IsInvalido = false;
            }
            else
            {
                TextoAviso = "Data invalida!";
                IsInvalido = true;
            }
        }

        private void TextoData(TextChangedEventArgs e)
        {
            if(e.OldTextValue != null && e.NewTextValue != null)
                if (e.NewTextValue.Length < e.OldTextValue.Length)
                {
                    if (e.NewTextValue.Length == 3 || e.NewTextValue.Length == 2)
                    {
                        txtPadrao.Text = txtPadrao.Text.Replace("/", "");
                        return;
                    }
                    else if (e.NewTextValue.Length == 6 || e.NewTextValue.Length == 5)
                    {
                        txtPadrao.Text = txtPadrao.Text.Substring(0, 5);
                        return;
                    }

                }

            txtPadrao.Text.ApenasInteiro();

            if (txtPadrao.Text.Length == 2 && txtPadrao.Text.Count(c => c == '/') == 0 )
            {
                txtPadrao.Text += "/";
            }
            else if((txtPadrao.Text.Length == 3 && txtPadrao.Text[2] != '/'))
            {
                var aux = txtPadrao.Text[2];
                txtPadrao.Text = txtPadrao.Text.Substring(0,2) + '/' + aux;
            }
            else if (txtPadrao.Text.Count(c => c == '/') < 2 && txtPadrao.Text.Length == 5)
            {
                txtPadrao.Text += "/";
            }
            else if ((txtPadrao.Text.Length == 6 && txtPadrao.Text[5] != '/'))
            {
                var aux = txtPadrao.Text[5];
                txtPadrao.Text = txtPadrao.Text.Substring(0, 5) + '/' + aux;
            }

            if (txtPadrao.Text.Contains("."))
            {
                TextoAviso = "Data invalida!";
                IsInvalido = true;
            }
            else if (IsInvalido)
                IsInvalido = false;
            
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
            if (Validar.Email(txtPadrao.Text))
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