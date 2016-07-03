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
    public partial class Fornecedor_Busca : Form
    {
        private Fornecedor_Menu JanelaFornecedorMenu;
        private int idSelected = 0;
        //resultado da pre-pesquisa
        private AutoCompleteStringCollection result;
        //colunas a serem pre-pesquisadas para o auto completar
        private List<String> columnsName;
        private List<String> columnsNameExibicao;

        public Fornecedor_Busca()
        {
            InitializeComponent();
        }

        public Fornecedor_Busca(Fornecedor_Menu Janela)
        {
            InitializeComponent();
            this.JanelaFornecedorMenu = Janela;
        }

        private void Fornecedor_Busca_Load(object sender, EventArgs e)
        {
            //busca todas informacoes relevantes e armazena num array
            //este array sera usado pra sugerir e autopletar dados no campo de busca
            String queryString = "Select * from " + DataBase.tableFornecedor;
            SqlDataReader dataReader = DataBase.SqlCommand(queryString, null, null);
            result = new AutoCompleteStringCollection();

            //inicializa as listas com os nomes reais das colunas e o nome que sera exibido ao usuario
            columnsName = new List<string>();
            columnsNameExibicao = new List<string>();
            columnsName.Add("Name");
            columnsNameExibicao.Add("Nome");
            columnsName.Add("Phone");
            columnsNameExibicao.Add("Telefone");
            columnsName.Add("CNPJ");
            columnsNameExibicao.Add("CNPJ");




            //add cada dado da busca a lista do autocompletar result
            while (dataReader.Read())
            {
                //result.AddRange(dataReader.);
                foreach (String colName in columnsName)
                {
                    result.Add(Convert.ToString(dataReader[colName]));
                    //Console.WriteLine("DEBUG" + result[result.Count - 1]);

                }

            }
            dataReader.Close();

            //faz o link do campo de busca com a lista de sugestoes/autocompletar
            textBoxSearch.AutoCompleteCustomSource = result;
        }


        //handler para tecla pressionada
        //usando para quando for apertado a tecla enter
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                executeQuery();
            }
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            executeQuery();
        }

        public void executeQuery()
        {
            if (textBoxSearch.Text.Length > 3)
            {
                labelErros.Visible = false;
                String value = textBoxSearch.Text.Trim();
                value = "%" + value + "%";

                String queryString = "Select Id as codigo";

                List<String> parNames = new List<String>();
                List<Object> parValues = new List<Object>();

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
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();



                reader.Close();

            }
            else
            {
                labelErros.Visible = true;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            JanelaFornecedorMenu.Show();
        }

        private void buttonGoToList_Click(object sender, EventArgs e)
        {
            DataGridViewCell selected = dataGridView1.SelectedCells[0];
            idSelected = Convert.ToInt32(dataGridView1.Rows[selected.RowIndex].Cells[0].Value);
            Fornecedor_List lista = new Fornecedor_List(JanelaFornecedorMenu, idSelected);
            lista.Show();
            this.Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            button1.Visible = true;

        }

        private void Fornecedor_Busca_FormClosing(object sender, FormClosingEventArgs e)
        {
            JanelaFornecedorMenu.Show();
        }
    }
}
