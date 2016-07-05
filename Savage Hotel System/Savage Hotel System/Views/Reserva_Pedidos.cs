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
        private Reserva_Menu JanelaReservaMenu;
        private int idProduto = -1;
        private int idReserva = -1;
        private int quantidade = 1;

        public Reserva_Pedidos()
        {
            InitializeComponent();
        }

        public Reserva_Pedidos(Reserva_Menu Janela)
        {
            InitializeComponent();
            this.JanelaReservaMenu = Janela;
        }

        private void Reserva_Pedidos_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'databaseHotelDataSet6.Produto' table. You can move, or remove it, as needed.
            this.produtoTableAdapter.Busca_Listar(this.dataSetProduto.Produto);
            
            // TODO: This line of code loads data into the 'dataSetPedidosReserva.PedidoReserva' table. You can move, or remove it, as needed.
            //this.pedidoReservaTableAdapter.Listar(this.dataSetPedidosReserva.PedidoReserva);

            // TODO: This line of code loads data into the 'databaseHotelDataSet5.Reserva' table. You can move, or remove it, as needed.
            //this.reservaTableAdapter1.Fill(this.databaseHotelDataSet5.Reserva);
            // TODO: This line of code loads data into the 'dataSetReserva.Reserva' table. You can move, or remove it, as needed.
            this.reservaTableAdapter.Busca_Listar(this.dataSetReserva.Reserva);

            updateProdutoSelecionado();
            updateReservaSelecionada();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            JanelaReservaMenu.Show();
        }
        public void updateProdutoSelecionado()
        {
            if (produtoDataGridView.SelectedRows.Count == 1) {
                idProduto = (int)produtoDataGridView.SelectedRows[0].Cells[0].Value;
            }
            else {
                idProduto = -1;
            }
        }
        public void updateReservaSelecionada()
        {
            if (reservaDataGridView.SelectedRows.Count == 1)
            {
                idReserva = (int)reservaDataGridView.SelectedRows[0].Cells[0].Value;
            }
            else
            {
                idReserva = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(idProduto < 0 || idReserva < 0)
            {
                MessageBox.Show("É OBRIGATORIO SELECIONAR UM PRODUTO E UMA RESERVAR! ");
            }else
            {
                quantidade = (int)numericUpDown1.Value;
                if (InserirBanco() > 0)
                {
                    MessageBox.Show("Inserido com Sucesso!");
                    this.Close();
                    JanelaReservaMenu.Show();
                }
                else
                {
                    MessageBox.Show("Houve alguma falha na insercao!");
                }
                //this.pedidoReservaTableAdapter.Listar(this.dataSetPedidosReserva.PedidoReserva);

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
                //this.pedidoReservaTableAdapter.Listar(this.dataSetPedidosReserva.PedidoReserva);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void pedidoReservaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.pedidoReservaBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dataSetPedidosReserva);

        }

        private void busca_2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //this.produtoTableAdapter.busca_2(this.dataSetProduto.Produto, ((int)(System.Convert.ChangeType(param1ToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void produtoDataGridView_Click(object sender, EventArgs e)
        {
            updateProdutoSelecionado();
        }

        private void reservaDataGridView_Click(object sender, EventArgs e)
        {
            updateReservaSelecionada();
        }

        private void Reserva_Pedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                JanelaReservaMenu.Show();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
