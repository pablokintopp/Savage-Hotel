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
        private Produto_Menu produto_Menu;
        private int idProduto = -1;        
        private int quantidade = 1;
        private double valor = 0;
        private string data = "";

        public Produto_Pedido()
        {
            InitializeComponent();
        }

        public Produto_Pedido(Produto_Menu produto_Menu)
        {
            InitializeComponent();
            this.produto_Menu = produto_Menu;
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
            produto_Menu.Show();
            this.Hide();
        }

        public void updateProdutoSelecionado()
        {
            if (produtoGridView.SelectedRows.Count == 1)
                idProduto = (int)produtoGridView.SelectedRows[0].Cells[0].Value;
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
                if (true) //TODO VALIDAR DATA
                {
                    quantidade = (int)numericUpDown1.Value; 
                    //data = ?
                    //valor =  ?                   
                    InserirBanco();
                    this.pedidoProdutoTableAdapter.Fill(this.databaseHotelDataSet8.PedidoProduto);

                }else
                {
                    MessageBox.Show("DATA INVÁLIDA!");
                }
                
            }
        }

        private void InserirBanco()
        {
           //TODO INSERIR NO BANCO
        }
    }
}
