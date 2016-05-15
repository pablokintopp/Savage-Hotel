using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Savage_Hotel_System.Models;

namespace Savage_Hotel_System.Views
{
    public partial class MenuMain : Form
    {
        private formLogin formLogin;
        private Employee user;

        public MenuMain()
        {
            InitializeComponent();
        }

        public MenuMain(formLogin formLogin, Employee user)
        {
            InitializeComponent();
            this.formLogin = formLogin;
            this.user = user;

            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formLogin.Show();
            this.Close();
        }

        private void MenuMain_Load(object sender, EventArgs e)
        {
            labelGreetings.Text = "Bem Vindo " + user.Name + " " + user.LastName;
        }
    }
}
