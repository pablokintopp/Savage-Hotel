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
    public partial class Reserva_Pedidos : Form
    {
        private Reserva_Menu reserva_Menu;
        private int idProduto = -1;
        private int idReserva = -1;
        private int quantidade = 1;

        public Reserva_Pedidos()
        {
            InitializeComponent();
        }

        public Reserva_Pedidos(Reserva_Menu reserva_Menu)
        {
            InitializeComponent();
            this.reserva_Menu = reserva_Menu;
        }

        private void Reserva_Pedidos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseHotelDataSet6.Produto' table. You can move, or remove it, as needed.
            this.produtoTableAdapter1.Fill(this.databaseHotelDataSet6.Produto);
            // TODO: This line of code loads data into the 'databaseHotelDataSet5.Reserva' table. You can move, or remove it, as needed.
            this.reservaTableAdapter1.Fill(this.databaseHotelDataSet5.Reserva);
            // TODO: This line of code loads data into the 'databaseHotelDataSet4.PedidoReserva' table. You can move, or remove it, as needed.
            this.pedidoReservaTableAdapter.Fill(this.databaseHotelDataSet4.PedidoReserva);
            // TODO: This line of code loads data into the 'dataSetReserva.Reserva' table. You can move, or remove it, as needed.
            this.reservaTableAdapter.Fill(this.dataSetReserva.Reserva);

            updateProdutoSelecionado();
            updateReservaSelecionada();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            reserva_Menu.Show();
        }
        public void updateProdutoSelecionado()
        {
            if (produtoGridView.SelectedRows.Count == 1)
                idProduto = (int)produtoGridView.SelectedRows[0].Cells[0].Value;
            else
                idProduto = -1;
        }
        public void updateReservaSelecionada()
        {
            if (reservaGridView.SelectedRows.Count == 1)
                idReserva = (int)reservaGridView.SelectedRows[0].Cells[0].Value;
            else
                idReserva = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(idProduto < 0 || idReserva < 0)
            {
                MessageBox.Show("É OBRIGATORIO SELECIONAR UM PRODUTO E UMA RESERVAR! ");
            }else
            {
                quantidade = (int)numericUpDown1.Value;
                InserirBanco();
                this.pedidoReservaTableAdapter.Fill(this.databaseHotelDataSet4.PedidoReserva);
            }
        }

        private int InserirBanco()
        {
            //Console.WriteLine("DATA: " + dateTimeNascimento.Value.ToString("dd/MM/yyyy"));
            //pega os valores das entradas para serem inseridos 
            List<object> parametrosValores = new List<object>()
            {
                idReserva,
                idProduto,
                quantidade

            };

            //Estes parametros devem ter o mesmo NOME das colunas da Tabela
            //E devem seguir a mesma ordem de insercao na lista dos valores acima
            List<string> parametrosNomes = new List<string>()
            {
                "ReservaId",
                "ProdutoId",
                "Quantidade"
            };
            string nomeDaTabela = DataBase.tablePedidoReserva;
            return DataBase.SqlCommandInsert(nomeDaTabela, parametrosNomes, parametrosValores);

        }

        private void produtoGridView_SelectionChanged(object sender, EventArgs e)
        {
            updateProdutoSelecionado();
        }

        private void reservaGridView_SelectionChanged(object sender, EventArgs e)
        {
            updateReservaSelecionada();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.pedidoReservaTableAdapter.FillBy(this.databaseHotelDataSet4.PedidoReserva);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
