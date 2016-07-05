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
using Savage_Hotel_System.Data;

namespace Savage_Hotel_System.Views
{
    public partial class MenuMain : Form
    {
        private formLogin JanelaLogin;
        private Employee user;

        public MenuMain()
        {
            InitializeComponent();
        }

        public MenuMain(formLogin Janela, Employee user)
        {
            InitializeComponent();
            this.JanelaLogin = Janela;
            this.user = user;

            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            JanelaLogin.Show();
            this.Close();
        }

        private void MenuMain_Load(object sender, EventArgs e)
        {
            labelGreetings.Text = "Bem Vindo " + user.Name;
        }

        //Evento para fechar software a partir do x da janela
        private void MenuMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(this, "Você tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (user.Office == "Gerente")
            {
                Form Func = new Func_Menu(this);
                this.Hide();
                Func.Show();

            }else
            {
                MessageBox.Show("Você não tem permissão para acessar este menu");
            }
           
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form Menucliente = new Cli_Menu(this);
            this.Hide();
            Menucliente.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(user.Office == "Gerente") { 
                Form Fornecedor = new Fornecedor_Menu(this);
                this.Hide();
                Fornecedor.Show();
            }else
                {
                    MessageBox.Show("Você não tem permissão para acessar este menu");
                }
        }

        private void iconReserve_Click(object sender, EventArgs e)
        {
            Form Reserva = new Reserva_Menu(this);
            this.Hide();
            Reserva.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (user.Office == "Gerente")
            {
                Form ProdutosMenu = new Produto_Menu(this);
                this.Hide();
                ProdutosMenu.Show();
            }else
            {

                MessageBox.Show("Você não tem permissão para acessar este menu");
            }
        }

        private void QuartoBox4_Click(object sender, EventArgs e)
        {
            Form Quarto = new Quarto_Menu(this);
            this.Hide();
            Quarto.Show();
        }
    }
}
