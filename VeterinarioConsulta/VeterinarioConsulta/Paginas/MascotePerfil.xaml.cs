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

        private bool isEditar;

        public MascotePerfil ()
		{
			InitializeComponent ();
            PreencherPerfil();

        }

        

        public void PreencherPerfil()
        {
            var animal = AnimaisServico.AnimalAtual;
            
            editDescricao.Text = animal.Descricao;
            txtEspecie.Text = animal.Especie;
            txtIdade.Text = animal.Idade;
            txtNome.Text = animal.Nome;
            txtPeso.Text = animal.Peso + "KG";
            txtRaca.Text = animal.Raca;
            txtTamanho.Text = animal.Tamanho;

        }

        private void ToolbarEditar_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Cadastro.AdicionarMascote() {Title = "Editar"});

            if (isEditar)
                Confirmar();
            else
                Editar();

            isEditar = !isEditar;
        }

        private void Editar()
        {
            editDescricao.IsEnabled = true;
            txtEspecie.IsEnabled = true;
            txtIdade.IsEnabled = true;
            txtNome.IsEnabled = true;
            txtPeso.IsEnabled = true;
            txtRaca.IsEnabled = true;
            txtTamanho.IsEnabled = true;

            txtNome.Focus();

            btnToolbar.Text = "Confirmar";
        }

        private void Confirmar()
        {
            editDescricao.IsEnabled = false;
            txtEspecie.IsEnabled = false;
            txtIdade.IsEnabled = false;
            txtNome.IsEnabled = false;
            txtPeso.IsEnabled = false;
            txtRaca.IsEnabled = false;
            txtTamanho.IsEnabled = false;
            
            btnToolbar.Text = "Editar";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            isEditar = false;
        }


    }
}