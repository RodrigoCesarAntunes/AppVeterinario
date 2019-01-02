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
	public partial class MascotePerfil : ContentPage
	{
        
        public MascotePerfil ()
		{
			InitializeComponent ();
            PreencherPerfil();

        }

        

        public void PreencherPerfil()
        {
            var animal = AnimaisServico.AnimalAtual;

            lblDescricao.Text = "Descrição: " + animal.Descricao;
            //lblEspecie.Text = "Espécie: " + animal.Especie;
            lblIdade.Text = "idade: " + animal.Idade;
            //lblNome.Text = "Nome: " + animal.Nome;
            lblPeso.Text = "Peso: " + animal.Peso + "KG";
            lblRaca.Text = "Raça: " + animal.Raca;
            lblTamanho.Text = "Tamanho: " + animal.Tamanho;

        }

        private void ToolbarEditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro.AdicionarMascote() {Title = "Editar"});
        }
    }
}