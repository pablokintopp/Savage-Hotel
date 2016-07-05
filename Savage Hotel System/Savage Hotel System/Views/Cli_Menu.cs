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
    public partial class Cli_Menu : Form
    {
        private MenuMain JanelaMenuMain;

        public Cli_Menu()
        {
            InitializeComponent();
        }

        public Cli_Menu(MenuMain Janela)
        {
            InitializeComponent();
            this.JanelaMenuMain = Janela;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            JanelaMenuMain.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form Cadastro = new Cli_Cad(this);
            this.Hide();
            Cadastro.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form Lista = new Cli_List(this);
            this.Hide();
            Lista.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form busca = new Cli_Busca(this);
            this.Hide();
            busca.Show();
        }

        private void Cli_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            JanelaMenuMain.Show();
        }

        private void Cli_Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
