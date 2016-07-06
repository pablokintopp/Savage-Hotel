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
    public partial class Reserva_Pagamento : Form
    {

        //resultado da pre-pesquisa
        private AutoCompleteStringCollection result;
        //colunas a serem pre-pesquisadas
        private List<String> columnsNameReserva;
        private List<String> columnsNameExibicaoReserva;        
        private Reserva_Menu JanelaReservaMenu;
        private int reservaId = -1;


        public Reserva_Pagamento()
        {
            InitializeComponent();
        }

        public Reserva_Pagamento(Reserva_Menu Janela)
        {
            InitializeComponent();
            this.JanelaReservaMenu = Janela;
        }

        private void Reserva_Pagamento_Load(object sender, EventArgs e)
        {
            inicializaAutoCompletar();
            executeQueryReserva();        
        }
      

        private void inicializaAutoCompletar()
        {

            //busca todas informacoes relevantes e armazena num array
            //este array sera usado pra sugerir e autopletar dados no campo de busca
            String queryString = "Select distinct * from " + DataBase.tableReserva + " ," + DataBase.tableCliente + " ," + DataBase.tableQuarto + " where Reserva.idCliente = Cliente.id and Reserva.idQuarto = Quarto.id";
            SqlDataReader dataReader = DataBase.SqlCommand(queryString, null, null);
            result = new AutoCompleteStringCollection();

            //inicializa as listas com os nomes reais das colunas e o nome que sera exibido ao usuario
            columnsNameReserva = new List<string>();
            columnsNameExibicaoReserva = new List<string>();
            columnsNameReserva.Add("Name");
            columnsNameExibicaoReserva.Add("Cliente");
            columnsNameReserva.Add("Valor");
            columnsNameExibicaoReserva.Add("Valor");
            columnsNameReserva.Add("numeroQuarto");
            columnsNameExibicaoReserva.Add("'Numero Quarto'");
            columnsNameReserva.Add("InicioReserva");
            columnsNameExibicaoReserva.Add("'Data Entrada'");
            columnsNameReserva.Add("FIMReserva");
            columnsNameExibicaoReserva.Add("'Data Saida'");



            //add cada dado da busca a lista do autocompletar que sera exibida no textBox
            while (dataReader.Read())
            {
                //result.AddRange(dataReader.);
                foreach (String colName in columnsNameReserva)
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
                executeQueryReserva();
            }
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            executeQueryReserva();
        }

        public void executeQueryReserva()
        {            
                
                String value = textBoxSearch.Text.Trim();
                value = "%" + value + "%";

                String queryString = "Select distinct Reserva.id as codigo";

                List<String> parNames = new List<String>();
                List<Object> parValues = new List<Object>();

                for (int i = 0; i < columnsNameReserva.Count; i++)
                {
                    queryString += " , " + columnsNameReserva[i] + " as " + columnsNameExibicaoReserva[i];

                }

                queryString += " from " + DataBase.tableReserva + " ," + DataBase.tableCliente + " ," + DataBase.tableQuarto + " where (Reserva.idCliente = Cliente.Id and Reserva.idQuarto = Quarto.Id) and (Reserva.Pagamento = 'pendente') and ( ";

                for (int i = 0; i < columnsNameReserva.Count; i++)
                {
                    if (i > 0)
                    {
                        queryString += " or UPPER(" + columnsNameReserva[i] + ") like UPPER(@" + columnsNameReserva[i] + ")";
                    }
                    else
                    {
                        queryString += "UPPER(" + columnsNameReserva[i] + ") like UPPER(@" + columnsNameReserva[i] + ")";

                    }
                    parNames.Add("@" + columnsNameReserva[i]);
                    parValues.Add(value);

                }

                queryString += " )";
                SqlDataReader reader = DataBase.SqlCommand(queryString, parNames, parValues);

                //Add resultado da busca ao datagridview
                DataTable dt = new DataTable();
                dt.Load(reader);
                reservaDataGridView.AutoGenerateColumns = true;
                reservaDataGridView.DataSource = dt;
                reservaDataGridView.Refresh();



                reader.Close();

            
            

        }
        public void executeQueryProduto(int reservaId)
        {



            // String queryString = "Select  PedidoReserva.Id as 'Codigo Pedido', Produto.Nome , Produto.Valor, PedidoReserva.Quantidade from "+DataBase.tableProduto+ ", " + DataBase.tablePedidoReserva + "  where PedidoReserva.ProdutoId = Produto.Id and PedidoReserva.Id = " + reservaId;
            String queryString = "Select PedidoReserva.Id , Produto.Nome , Produto.Valor , PedidoReserva.Quantidade from " + DataBase.tableProduto + ", " + DataBase.tablePedidoReserva + " where (PedidoReserva.ProdutoId = Produto.Id and  PedidoReserva.ReservaId = "+reservaId+") ";


            SqlDataReader reader = DataBase.SqlCommand(queryString, null, null);

            DataTable dt = new DataTable();
            dt.Load(reader);
            produtoDataGridView.AutoGenerateColumns = true;
            produtoDataGridView.DataSource = dt;
            produtoDataGridView.Refresh();



            reader.Close();

            updateLabels();

        }

        private void updateLabels()
        {
            double somaProdutos = 0;
            double valorReserva = 0;
            int quantidadeProduto = 1;
            DataGridViewRow reservaSelected = reservaDataGridView.SelectedRows[0];

            valorReserva = Double.Parse( reservaSelected.Cells["Valor"].Value.ToString());
            
            label4.Text = "VALOR DA RESERVA: " + valorReserva;
            
            foreach(DataGridViewRow produtoRow in produtoDataGridView.Rows)
            {
                quantidadeProduto = int.Parse(produtoRow.Cells["Quantidade"].Value.ToString());

                somaProdutos += (Double.Parse(produtoRow.Cells[0].Value.ToString())* quantidadeProduto);
            }
            label5.Text = "VALOR DOS PRODUTOS: " + somaProdutos;

            label6.Text = "VALOR TOTAL: " + ((double)somaProdutos + (double)valorReserva);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            try
            {
                JanelaReservaMenu.Show();
            }
            catch (Exception)
            {
             
            }
        }

        private void reservaDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            reservaId = -1;

            if (reservaDataGridView.SelectedRows.Count > 0) { 
                DataGridViewRow row = reservaDataGridView.SelectedRows[0];
                reservaId = int.Parse(row.Cells[0].Value.ToString());                    
                executeQueryProduto(reservaId);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(reservaId > -1)
            {
                string queryString = "UPDATE " + DataBase.tableReserva + " SET  Pagamento = 'efetuado' Where Id = "+reservaId;
                SqlDataReader reader = DataBase.SqlCommand(queryString, null, null);

                reader.Close();
                MessageBox.Show("PAGAMENTO EFETUADO COM SUCESSO! ");
                executeQueryReserva();
            }else
            {
                MessageBox.Show("SELECIONE PELO MENOS UMA RESERVA PARA EFETUAR PAGAMENTO!");
            }
        }
    }
}
