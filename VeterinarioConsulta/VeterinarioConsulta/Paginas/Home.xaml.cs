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
    public partial class Home : TabbedPage
    {
        public Home ()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void Voltar()
        {
            var pages = Children.GetEnumerator();
            pages.MoveNext();
            CurrentPage = pages.Current;
        }

        public string Tipo()
        {
            var pages = Children.GetEnumerator();
            return CurrentPage.GetType().ToString();
        }
    }
}