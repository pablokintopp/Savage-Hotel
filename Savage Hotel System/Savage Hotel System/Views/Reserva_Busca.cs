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
    public partial class Reserva_Busca : Form
    {
        private int idSelected = 0;
        //resultado da pre-pesquisa
        private AutoCompleteStringCollection result;
        //colunas a serem pre-pesquisadas
        private List<String> columnsName;
        private List<String> columnsNameExibicao;

        private Reserva_Menu menu;
        

        public Reserva_Busca()
        {
            InitializeComponent();
        }

        public Reserva_Busca(Reserva_Menu reserva_Menu)
        {
            InitializeComponent();
            this.menu= reserva_Menu;
        }

        private void Reserva_Busca_Load(object sender, EventArgs e)
        {
            inicializaAutoCompletar();
        }

        private void inicializaAutoCompletar()
        {

            //busca todas informacoes relevantes e armazena num array
            //este array sera usado pra sugerir e autopletar dados no campo de busca
            String queryString = "Select distinct * from " + DataBase.tableReserva +" ,"+ DataBase.tableCliente + " ," + DataBase.tableQuarto + " where Reserva.idCliente = Cliente.id and Reserva.idQuarto = Quarto.id" ;
            SqlDataReader dataReader = DataBase.SqlCommand(queryString, null, null);
            result = new AutoCompleteStringCollection();

            //inicializa as listas com os nomes reais das colunas e o nome que sera exibido ao usuario
            columnsName = new List<string>();
            columnsNameExibicao = new List<string>();
            columnsName.Add("Name");
            columnsNameExibicao.Add("Cliente");
            columnsName.Add("numeroQuarto");
            columnsNameExibicao.Add("'Numero Quarto'");
            columnsName.Add("InicioReserva");
            columnsNameExibicao.Add("'Data Entrada'");
            columnsName.Add("FIMReserva");
            columnsNameExibicao.Add("'Data Saida'");



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

                String queryString = "Select distinct Reserva.id as codigo";

                List<String> parNames = new List<String>();
                List<Object> parValues = new List<Object>();

                for (int i = 0; i < columnsName.Count; i++)
                {
                    queryString += " , " + columnsName[i] + " as " + columnsNameExibicao[i];

                }

                queryString += " from " + DataBase.tableReserva + " ," + DataBase.tableCliente + " ," + DataBase.tableQuarto + " where (Reserva.idCliente = Cliente.Id and Reserva.idQuarto = Quarto.Id) and ( ";

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

                queryString += " )";
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
            menu.Show();
        }

        private void buttonGoToList_Click(object sender, EventArgs e)
        {
            DataGridViewCell selected = dataGridView1.SelectedCells[0];
            idSelected = Convert.ToInt32(dataGridView1.Rows[selected.RowIndex].Cells[0].Value);
            Reserva_List lista = new Reserva_List(menu, idSelected);
            lista.Show();
            this.Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            button1.Visible = true;

        }
    }
}
