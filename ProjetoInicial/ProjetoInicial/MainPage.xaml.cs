using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProjetoInicial.model;

namespace ProjetoInicial
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        static int idPessoa = 0;
        List<Pessoa> pessoas = new List<Pessoa>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void salvar(object sender, EventArgs e)
        {
            idPessoa++;
            Pessoa p = new Pessoa()
            {
                id = idPessoa,
                nome = txtName.Text,
                email = txtEmail.Text
            };

            pessoas.Add(p);
            carregarLista();            

            DisplayAlert("Primeiro projeto", $"o nome informado é: {txtName.Text}!", "Fechar");
        }

        private void carregarLista()
        {
            lstPessoas.ItemsSource = null;
            lstPessoas.ItemsSource = pessoas;
        }

        private void excluir(object sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;
            int idPessoa = Int16.Parse(botaoClicado.CommandParameter.ToString());

            Pessoa pessoaExcluir = pessoas.Where(p => p.id == idPessoa).
                SingleOrDefault();

            pessoas.Remove(pessoaExcluir);
            carregarLista();
        }
    }
}
