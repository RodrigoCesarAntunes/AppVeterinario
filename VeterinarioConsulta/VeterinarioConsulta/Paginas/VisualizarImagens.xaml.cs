using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarioConsulta.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeterinarioConsulta.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VisualizarImagens : PopupPage
	{
		public VisualizarImagens ()
		{
			InitializeComponent ();
            this.CloseWhenBackgroundIsClicked = true;
            //pagina.BackgroundClicked += PopupPage_BackgroundClicked;
        }

        public string imagemSource
        {
            set { img.Source = value; }
        }

        //protected async void PopupPage_BackgroundClicked(object sender, EventArgs e)
        //{
        //    var modal = new TratarModal();
        //    await modal.FecharModal();
        //}
    }
}