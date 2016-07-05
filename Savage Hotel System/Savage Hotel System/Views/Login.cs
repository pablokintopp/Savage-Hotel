using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Savage_Hotel_System.Data;
using Savage_Hotel_System.Models;
using Savage_Hotel_System.Views;

namespace Savage_Hotel_System
{
    public partial class formLogin : Form
    {
        

        public formLogin()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            DataBase.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: VALIDAR INPUTS

            string login = textBoxLogin.Text;
            string pass = textBoxPassword.Text;

            List<object> parValues = new List<object>()
            {
                login,
                pass

            };

            List<string> parName = new List<string>()
            {
                "@Login",
                "@Password"

            };
            //Abre conexao
           
            string queryString = "SELECT * FROM "+ DataBase.tableFuncionario +
                "  WHERE Login = @Login and Password = @Password";
            SqlDataReader dr = DataBase.SqlCommand(queryString, parName, parValues);

            if (dr.Read())
            {

                Employee user = new Employee() {
                    ID = (int)dr["Id"],
                    Name = (string)dr["Name"],                                      
                    Office = (string)dr["Office"]
                };
                Form formMainMenu = new MenuMain(this, user);

                textBoxLogin.Text = "";
                textBoxPassword.Text = "";
                labelStatus.Text = "";
                labelStatus.Visible = false;
                this.Hide();
                formMainMenu.Show();
            }
            else
            {
                labelStatus.Text = "Senha ou Login inválidos!";
                labelStatus.Visible = true;                

            }
            dr.Close();
            
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
