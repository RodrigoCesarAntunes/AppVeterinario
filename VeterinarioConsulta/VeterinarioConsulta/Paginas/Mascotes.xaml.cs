using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarioConsulta.Servicos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VeterinarioConsulta.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mascotes : ContentPage
	{
		public Mascotes ()
		{
			InitializeComponent ();
            IniciarList();
        }

        

        public void IniciarList()
        {
            var animais = new AnimaisServico().ObterTodos();
            listMascotes.ItemsSource = animais;

            listMascotes.ItemSelected += ItemSelecionado;
        }

        private void ItemSelecionado(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null)
                return;

            (sender as ListView).SelectedItem = null;
        }
    }
}