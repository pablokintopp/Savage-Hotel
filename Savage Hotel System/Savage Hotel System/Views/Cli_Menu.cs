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
        private MenuMain Main;

        public Cli_Menu()
        {
            InitializeComponent();
        }

        public Cli_Menu(MenuMain MenuMain)
        {
            InitializeComponent();
            this.Main = MenuMain;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main.Show();
            this.Close();
        }
    }
}
