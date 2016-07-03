using Savage_Hotel_System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Savage_Hotel_System.Views
{
    public partial class Reserva_IncluirCliente : Form
    {
        //Para a sugestao de autoCompletar
        private AutoCompleteStringCollection result;
        //colunas a serem pre-pesquisadas para o auto completar
        private List<String> columnsName;
        private List<String> columnsNameExibicao;

        private Reserva_Cadastro JanelaReservaCadastro;
        int quantidadeItensNaGridView = 0;
        public Reserva_IncluirCliente()
        {
            InitializeComponent();
        }

        public Reserva_IncluirCliente(Reserva_Cadastro Janela)
        {
            InitializeComponent();
            this.JanelaReservaCadastro = Janela;
        }

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.quartoBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.quarto);
        }


        private void Reserva_IncluirCliente_Load(object sender, EventArgs e)
        {
            //inicializaAutoCompletar(DataBase.tableCliente);
            inicializaAutoCompletar(DataBase.tableCliente);
            // TODO: This line of code loads data into the 'dataSetCliente.Cliente' table. You can move, or remove it, as needed.
            //this.clienteTableAdapter.Fill(this.dataSetCliente.Cliente);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            JanelaReservaCadastro.Show();
            this.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            //Buscar pelo Nome ou Pelo CPF
            this.clienteTableAdapter.Busca_NOMEouCPF(this.dataSetCliente.Cliente, textBoxBusca.Text);

            //Conta quantas linhas estão na GridView
            quantidadeItensNaGridView = clienteDataGridView.Rows.Count;
            label3.Text = "Quantidade de Intens Econtrados ";
            label3.Text += quantidadeItensNaGridView.ToString();

            mostrarInfos();

        }

        private void mostrarInfos() {
            if (quantidadeItensNaGridView > 0)
            {
                int linha = -1;
                //Numero da Linha Selecionada
                label1.Text = "Linha Selecionada ";
                label1.Text += clienteDataGridView.SelectedRows[0].Index.ToString();
                linha = (int)clienteDataGridView.SelectedRows[0].Index;

                //ID do Banco referente a linha selecionada
                /*label2.Text = "ID do Quarto Selecionado ";
                label2.Text += quartoDataGridView.SelectedCells[2].Value.ToString();*/

                //Numero do Quarto Selecionado
                label2.Text = "Numero do Quarto Selecionado ";
                label2.Text += clienteDataGridView.Rows[linha].Cells[2].Value.ToString();
            }
        }

        private void quartoDataGridView_Click(object sender, EventArgs e)
        {
            mostrarInfos();
        }

        private void Selecionarbutton_Click(object sender, EventArgs e)
        {
            int IDCliente = -1;
            if (quantidadeItensNaGridView > 0)
            {
                int linha = -1;
                //Numero da Linha Selecionada
                label1.Text = "Linha Selecionada ";
                label1.Text += clienteDataGridView.SelectedRows[0].Index.ToString();
                linha = (int)clienteDataGridView.SelectedRows[0].Index;

                //ID do Banco referente a linha selecionada
                /*label2.Text = "ID do Quarto Selecionado ";
                label2.Text += quartoDataGridView.SelectedCells[2].Value.ToString();*/

                //ID do Quarto Selecionado
                label2.Text = "Numero do Quarto Selecionado ";
                IDCliente = Convert.ToInt16(clienteDataGridView.Rows[linha].Cells[0].Value);
                label2.Text = IDCliente.ToString();

                JanelaReservaCadastro.DefinirIDCliente(IDCliente);
                JanelaReservaCadastro.refresh();
                JanelaReservaCadastro.Show();
                this.Close();
            }

            
        }

        private void quartoDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            mostrarInfos();
        }

        private void quartoDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarInfos();
        }



/////// Métodos para o autocompletar
        private void inicializaAutoCompletar(String tabela)
        {

            //busca todas informacoes relevantes e armazena num array
            //este array sera usado pra sugerir e autopletar dados no campo de busca
            String queryString = "Select * from " + tabela;
            SqlDataReader dataReader = DataBase.SqlCommand(queryString, null, null);
            result = new AutoCompleteStringCollection();

            //inicializa as listas com os nomes reais das colunas e o nome que sera exibido ao usuario
            columnsName = new List<string>();
            columnsNameExibicao = new List<string>();
            columnsName.Add("Name");
            columnsNameExibicao.Add("Name");
            columnsName.Add("CPF");
            columnsNameExibicao.Add("CPF");

            //add cada dado da busca a lista do autocompletar que sera exibida no textBox
            while (dataReader.Read())
            {
                //result.AddRange(dataReader.);
                foreach (String colName in columnsName)
                {
                    result.Add(Convert.ToString(dataReader[colName]));

                }

            }
            dataReader.Close();

            //faz o link do campo de busca com a lista de sugestoes/autocompletar
            textBoxBusca.AutoCompleteCustomSource = result;
        }
/////// Métodos para o autocompletar

/////// Método para cadastrar um novo cliente
        private void buttonCadastrarCliente_Click(object sender, EventArgs e)
        {
            Form CadastrarCliente = new Cli_Cad(this);
            CadastrarCliente.ShowDialog();
        }
/////// Método para cadastrar um novo cliente

/////// Método para recarregar para mudanças
        public void refresh() {
            inicializaAutoCompletar(DataBase.tableCliente);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
/////// Método para recarregar para mudanças

        private void Reserva_IncluirCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            JanelaReservaCadastro.Show();
        }
    }
}
