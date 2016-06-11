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
        private MenuMain Main;

        public Func_Menu()
        {
            InitializeComponent();
        }

        public Func_Menu(MenuMain MenuMain)
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
            Form Cadastro = new Func_Cad(this);
            this.Hide();
            Cadastro.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form Lista = new Func_List(this,3);
            this.Hide();
            Lista.Show();
        }

        private void Func_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.Show();
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
