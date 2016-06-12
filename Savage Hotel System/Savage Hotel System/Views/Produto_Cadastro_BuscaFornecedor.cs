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
    public partial class Produto_Cadastro_BuscaFornecedor : Form
    {
        //resultado da pre-pesquisa
        private AutoCompleteStringCollection result;
        //colunas a serem pre-pesquisadas para o auto completar
        private List<String> columnsName;
        private List<String> columnsNameExibicao;

        private Produto_Cadastro Cadastro;
        int quantidadeItensNaGridView = 0;
        public Produto_Cadastro_BuscaFornecedor()
        {
            InitializeComponent();
        }

        public Produto_Cadastro_BuscaFornecedor(Produto_Cadastro NewCadastro)
        {
            InitializeComponent();
            this.Cadastro = NewCadastro;
        }

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.fornecedorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetFornecedor);

        }

        private void Reserva_Cadastro_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetFornecedor.Fornecedor' table. You can move, or remove it, as needed.
            //this.fornecedorTableAdapter.Fill(this.dataSetFornecedor.Fornecedor);

            //busca todas informacoes relevantes e armazena num array
            //este array sera usado pra sugerir e autopletar dados no campo de busca
            String queryString = "Select * from " + DataBase.tableFornecedor;
            SqlDataReader dataReader = DataBase.SqlCommand(queryString, null, null);
            result = new AutoCompleteStringCollection();

            //inicializa as listas com os nomes reais das colunas e o nome que sera exibido ao usuario
            columnsName = new List<string>();
            columnsNameExibicao = new List<string>();
            columnsName.Add("Name");
            columnsNameExibicao.Add("Name");
            columnsName.Add("CNPJ");
            columnsNameExibicao.Add("CNPJ");
            columnsName.Add("Phone");
            columnsNameExibicao.Add("Phone");
            


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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cadastro.Show();
            this.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            //Buscar pelo Nome do FOrnecedor
            if (radioButtonNome.Checked == true)
            {
                this.fornecedorTableAdapter.Busca_Nome(this.dataSetFornecedor.Fornecedor, textBoxBusca.Text);
            }

            //Buscar pelo CNPJ dos Fornecedores
            if (radioButtonCNPJ.Checked == true)
            {
                this.fornecedorTableAdapter.Busca_CNPJ(this.dataSetFornecedor.Fornecedor, textBoxBusca.Text);
            }

            //busca por qualquer campo
            if(radioButtonAny.Checked == true)
            {
                buscaQualquerCampo();

            }

            //Conta quantas linhas estão na GridView
            quantidadeItensNaGridView = fornecedorDataGridView.Rows.Count;
            label3.Text = "Quantidade de Intens Econtrados ";
            label3.Text += quantidadeItensNaGridView.ToString();
            mostrarInfos();

        }

        public void buscaQualquerCampo()
        {
            if (textBoxBusca.Text.Length > 2)
            {
                
                String value = textBoxBusca.Text.Trim();
                value = "%" + value + "%";

                String queryString = "Select Id as Id";

                List<String> parNames = new List<String>();
                List<Object> parValues = new List<Object>();

                //monta e executa as consultas para cada coluna que devera ser pesquisada
                for (int i = 0; i < columnsName.Count; i++)
                {
                    queryString += " , " + columnsName[i] + " as " + columnsNameExibicao[i];

                }

                queryString += " from " + DataBase.tableFornecedor + " where ";
                
                for (int i = 0; i < columnsName.Count; i++)
                {
                    if (i > 0)
                    {
                        queryString += " or UPPER(" + columnsName[i] + ") like UPPER(@" + columnsName[i] + ")";
                    }
                    else
                    {
                        queryString += "UPPER(" + columnsName[i] + ") like UPPER(@" + columnsName[i] + ")";

                    }
                    parNames.Add("@" + columnsName[i]);
                    parValues.Add(value);

                }
                SqlDataReader reader = DataBase.SqlCommand(queryString, parNames, parValues);

                //Add resultado da busca ao datagridview
                DataTable dt = new DataTable();
                dt.Load(reader);
                fornecedorDataGridView.AutoGenerateColumns = false;
                fornecedorDataGridView.DataSource = dt;
                fornecedorDataGridView.Refresh();



                reader.Close();

            }           

        }

        private void mostrarInfos() {
            if (quantidadeItensNaGridView > 0)
            {
                label1.Show();
                label2.Show();
                label4.Hide();

                int linha = -1;
                //Numero da Linha Selecionada
                label1.Text = "Linha Selecionada ";
                label1.Text += fornecedorDataGridView.SelectedRows[0].Index.ToString();
                linha = (int)fornecedorDataGridView.SelectedRows[0].Index;

                //ID do Banco referente a linha selecionada
                /*label2.Text = "ID do Quarto Selecionado ";
                label2.Text += quartoDataGridView.SelectedCells[2].Value.ToString();*/

                //Numero do Quarto Selecionado
                label2.Text = "ID do fornecedor ";
                label2.Text += fornecedorDataGridView.Rows[linha].Cells[0].Value.ToString();
            }
            else {
                label1.Hide();
                label2.Hide();
            }
        }

        private void quartoDataGridView_Click(object sender, EventArgs e)
        {
            mostrarInfos();
            label4.Hide();
        }

        private void Selecionarbutton_Click(object sender, EventArgs e)
        {
            int ID = -1;
            if (quantidadeItensNaGridView > 0)
            {
                int linha = -1;
                //Numero da Linha Selecionada
                label1.Text = "Linha Selecionada ";
                label1.Text += fornecedorDataGridView.SelectedRows[0].Index.ToString();
                linha = (int)fornecedorDataGridView.SelectedRows[0].Index;

                //ID do Banco referente a linha selecionada
                /*label2.Text = "ID do Quarto Selecionado ";
                label2.Text += quartoDataGridView.SelectedCells[2].Value.ToString();*/

                //Id do FOrnecedor
                label2.Text = "Numero do Quarto Selecionado ";
                ID = Convert.ToInt16(fornecedorDataGridView.Rows[linha].Cells[0].Value);
                label2.Text = ID.ToString();

                {
                    Cadastro.definirID(ID);
                    Cadastro.refresh();
                    Cadastro.Show();
                    this.Close();
                }

            }
            else {
                label4.Show();
                label4.Text = "Nada foi Selecionado!!";
            }

            
        }

        private void fornecedorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.fornecedorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetFornecedor);

        }

        private void fornecedorDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarInfos();
        }

        private void fornecedorDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            mostrarInfos();
        }
    }
}
