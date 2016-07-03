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
    public partial class Produto_Menu : Form
    {
        private MenuMain JanelaMenuMain;

        public Produto_Menu()
        {
            InitializeComponent();
        }

        public Produto_Menu(MenuMain Janela)
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
            Form Cadastro = new Produto_Cadastro(this);
            this.Hide();
            Cadastro.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form Lista = new Produto_List(this);
            this.Hide();
            Lista.Show();
        }

        private void Func_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            JanelaMenuMain.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Busca = new Produto_Busca(this);
            this.Hide();
            Busca.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form Pedido = new Produto_Pedido(this);
            this.Hide();
            Pedido.Show();
        }
    }
}
