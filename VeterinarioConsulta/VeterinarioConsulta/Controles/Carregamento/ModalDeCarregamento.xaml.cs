﻿using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeterinarioConsulta.Controles.Carregamento
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModalDeCarregamento : PopupPage
    {
		public ModalDeCarregamento ()
		{
			InitializeComponent ();
            this.CloseWhenBackgroundIsClicked = false;
		}

        public string Texto
        {
            get { return lblCarregando.Text; }
            set { lblCarregando.Text = value; }
        }
    }
}