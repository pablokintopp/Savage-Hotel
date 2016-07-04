using Savage_Hotel_System.Class;
using Savage_Hotel_System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Savage_Hotel_System.Views
{
    public partial class Produto_Pedido : Form
    {
        private Produto_Menu JanelaProdutoMenu;
        private int idProduto = -1;
        private int idFornecedor = -1;       
        private int quantidade = 1;
        private double valor = 0;
        private string data = "";

        public Produto_Pedido()
        {
            InitializeComponent();
        }

        public Produto_Pedido(Produto_Menu Janela)
        {
            InitializeComponent();
            this.JanelaProdutoMenu = Janela;
        }

        private void Produto_Pedido_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseHotelDataSet8.PedidoProduto' table. You can move, or remove it, as needed.
            this.pedidoProdutoTableAdapter.Fill(this.databaseHotelDataSet8.PedidoProduto);
            // TODO: This line of code loads data into the 'databaseHotelDataSet6.Produto' table. You can move, or remove it, as needed.
            this.produtoTableAdapter.Fill(this.databaseHotelDataSet6.Produto);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            JanelaProdutoMenu.Show();
            this.Hide();
        }

        public void updateProdutoSelecionado()
        {
            if (produtoGridView.SelectedRows.Count == 1)
            {
                idProduto = (int)produtoGridView.SelectedRows[0].Cells[0].Value;
                idFornecedor = (int)produtoGridView.SelectedRows[0].Cells[3].Value;
               
            }
                
            else
                idProduto = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idProduto < 0)
            {
                MessageBox.Show("É OBRIGATORIO SELECIONAR UM PRODUTO! ");
            }
            else
            {
                Funcoes aux = new Funcoes();
                int validaData = aux.VerificaDataPedido(dateTimePedido.Value);
                
                if (validaData == 0) 
                {
                    quantidade = (int)numericUpDown1.Value;
                    data = dateTimePedido.Text;
                    Console.WriteLine(produtoGridView.SelectedRows[0].Cells[2].Value);
                    
                    double vlr = double.Parse( produtoGridView.SelectedRows[0].Cells[2].Value.ToString());
                    valor = vlr * quantidade;
                    InserirBanco();
                    this.pedidoProdutoTableAdapter.Fill(this.databaseHotelDataSet8.PedidoProduto);

                }else
                {
                    MessageBox.Show("ESPERA-SE QUE A DATA SEJA DO DIA ATUAL OU DO ULTIMO MÊS!");
                }
                
            }
        }

        private int InserirBanco()
        {
            //Console.WriteLine("DATA: " + dateTimeNascimento.Value.ToString("dd/MM/yyyy"));
            //pega os valores das entradas para serem inseridos 
            List<object> parametrosValores = new List<object>()
            {
                idProduto,
                idFornecedor,
                quantidade,
                valor,
                data
            };

            //Estes parametros devem ter o mesmo NOME das colunas da Tabela
            //E devem seguir a mesma ordem de insercao na lista dos valores acima
            List<string> parametrosNomes = new List<string>()
            {
                "ProdutoId",
                "FornecedorId",
                "Quantidade",
                 "ValorTotal",
                 "Data"
            };
            string nomeDaTabela = DataBase.tablePedidoProduto;

            return DataBase.SqlCommandInsert(nomeDaTabela, parametrosNomes, parametrosValores);
        }

        private void produtoGridView_SelectionChanged(object sender, EventArgs e)
        {
            updateProdutoSelecionado();
        }

        private void Produto_Pedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                JanelaProdutoMenu.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
