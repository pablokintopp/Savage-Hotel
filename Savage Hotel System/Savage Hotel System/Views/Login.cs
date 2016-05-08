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

namespace Savage_Hotel_System
{
    public partial class formLogin : Form
    {
        //Necessário para conectar com o banco de dados
        SqlConnection connection;
        string connectionUrl;

        public formLogin()
        {
            InitializeComponent();

            //Salvando o caminho do DataBase
            connectionUrl = ConfigurationManager.ConnectionStrings["Savage_Hotel_System.Properties.Settings.DatabaseHotelConnectionString"].ConnectionString;
        }
    }
}
