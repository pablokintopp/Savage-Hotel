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
    public partial class Reserva_IncluirQuarto : Form
    {
        //para a sugestao de autocompletar
        private AutoCompleteStringCollection result;
        //colunas a serem pre-pesquisadas para o auto completar
        private List<String> columnsName;
        private List<String> columnsNameExibicao;

        private Reserva_Cadastro JanelaReservaCadastro;
        int quantidadeItensNaGridView = 0;
        public Reserva_IncluirQuarto()
        {
            InitializeComponent();
        }

        public Reserva_IncluirQuarto(Reserva_Cadastro Janela)
        {
            InitializeComponent();
            this.JanelaReservaCadastro = Janela;
        }

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.quartoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void Reserva_Cadastro_Load(object sender, EventArgs e)
        {
            inicializaAutoCompletar(DataBase.tableQuarto);

            // TODO: This line of code loads data into the 'quarto._Quarto' table. You can move, or remove it, as needed.
            //this.quartoTableAdapter.Fill(this.quarto._Quarto);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            JanelaReservaCadastro.Show();
            this.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            //Buscar pelo Número do Quarto
            if (radioButtonNumeroQuarto.Checked == true)
            {
                this.quartoTableAdapter.busca_NumeroQuarto(this.quarto._Quarto, textBoxBusca.Text, "disponivel");
            }

            //Buscar pelo Número de Camas de Solteiro nos Quartos
            if (radioButtonQuantidadeCamaSolteiro.Checked == true)
            {
                this.quartoTableAdapter.busca_QuantidadeCamaSolteiro(this.quarto._Quarto, textBoxBusca.Text, "disponivel");
            }

            //Buscar pelo Número de Camas de Casal nos Quartos
            if (radioButtonQuantidadeCamaCasal.Checked == true)
            {
                this.quartoTableAdapter.busca_QuantidadeCamaCasal(this.quarto._Quarto, textBoxBusca.Text, "disponivel");
            }

            //Conta quantas linhas estão na GridView
            quantidadeItensNaGridView = quartoDataGridView.Rows.Count;
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
                label1.Text += quartoDataGridView.SelectedRows[0].Index.ToString();
                linha = (int)quartoDataGridView.SelectedRows[0].Index;

                //ID do Banco referente a linha selecionada
                /*label2.Text = "ID do Quarto Selecionado ";
                label2.Text += quartoDataGridView.SelectedCells[2].Value.ToString();*/

                //Numero do Quarto Selecionado
                label2.Text = "Numero do Quarto Selecionado ";
                label2.Text += quartoDataGridView.Rows[linha].Cells[2].Value.ToString();
            }
        }

        private void quartoDataGridView_Click(object sender, EventArgs e)
        {
            mostrarInfos();
        }

        private void Selecionarbutton_Click(object sender, EventArgs e)
        {
            int IDQuarto = -1;
            if (quantidadeItensNaGridView > 0)
            {
                int linha = -1;
                //Numero da Linha Selecionada
                label1.Text = "Linha Selecionada ";
                label1.Text += quartoDataGridView.SelectedRows[0].Index.ToString();
                linha = (int)quartoDataGridView.SelectedRows[0].Index;

                //ID do Banco referente a linha selecionada
                /*label2.Text = "ID do Quarto Selecionado ";
                label2.Text += quartoDataGridView.SelectedCells[2].Value.ToString();*/

                //ID do Quarto Selecionado
                label2.Text = "Numero do Quarto Selecionado ";
                IDQuarto = Convert.ToInt16(quartoDataGridView.Rows[linha].Cells[0].Value);
                label2.Text = IDQuarto.ToString();

                JanelaReservaCadastro.DefinirIDQuarto(IDQuarto);
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
            columnsName.Add("numeroQuarto");
            columnsNameExibicao.Add("numeroQuarto");


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

        private void Reserva_IncluirQuarto_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                JanelaReservaCadastro.Show();
            }
            catch (Exception)
            {
                              
            }
        }
    }
}
