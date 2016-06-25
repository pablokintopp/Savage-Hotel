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
        private MenuMain Main;

        public Reserva_Menu()
        {
            InitializeComponent();
        }

        public Reserva_Menu(MenuMain MenuMain)
        {
            InitializeComponent();
            this.Main = MenuMain;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main.Show();
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
            Main.Show();
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
    }
}
