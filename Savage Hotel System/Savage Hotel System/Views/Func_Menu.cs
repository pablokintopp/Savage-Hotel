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
    public partial class Func_Menu : Form
    {
        private MenuMain JanelaMenuMain;

        public Func_Menu()
        {
            InitializeComponent();
        }

        public Func_Menu(MenuMain Janela)
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
            Form Cadastro = new Func_Cad(this);
            this.Hide();
            Cadastro.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form Lista = new Func_List(this);
            this.Hide();
            Lista.Show();
        }

        private void Func_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            JanelaMenuMain.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Func_Busc busca = new Func_Busc(this);
            busca.Show();
            this.Hide();
        }

        private void Func_Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
