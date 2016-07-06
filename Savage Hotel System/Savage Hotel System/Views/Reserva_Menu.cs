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
    public partial class Reserva_Menu : Form
    {
        private MenuMain JanelaMenuMain;

        public Reserva_Menu()
        {
            InitializeComponent();
        }

        public Reserva_Menu(MenuMain Janela)
        {
            InitializeComponent();
            this.JanelaMenuMain = Janela;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            JanelaMenuMain.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form Cadastro = new Reserva_Cadastro(this);
            this.Hide();
            Cadastro.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form Lista = new Reserva_List(this);
            this.Hide();
            Lista.Show();
        }

        private void Func_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            JanelaMenuMain.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Busca = new Reserva_Busca(this);
            this.Hide();
            Busca.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form Pedidos = new Reserva_Pedidos(this);
            this.Hide();
            Pedidos.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form PedidosLista = new Reserva_Pedidos_Lista(this);
            this.Hide();
            PedidosLista.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form Pagamento = new Reserva_Pagamento(this);
            this.Hide();
            Pagamento.Show();
        }
    }
}
