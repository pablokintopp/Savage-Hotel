using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savage_Hotel_System.Data
{
    public static class DataBase
    {
        //Necessário para conectar com o banco de dados

        public static  string connectionUrl = ConfigurationManager.ConnectionStrings["Savage_Hotel_System.Properties.Settings.DatabaseHotelConnectionString"].ConnectionString;
        public static SqlConnection connection = new SqlConnection(connectionUrl);

        //Nome tabelas
        public static string tableFuncionario = "[dbo].[Funcionario]";

        //Conecta ao DB
        public static string Connect()
        {
            string ret;          

            try
            {
                connection.Open();
                ret = "Connected";
            }
            catch (SqlException ex)
            {

                ret = ex.Message;
            }

            Console.WriteLine(ret);
            return ret;

            
        }

        //disconecta do banco de dados
        public static string Disconnect()
        {
            if(connection != null)
            {
                connection.Close();
            }
            return "Disconneted";
        }

        //Comando sql a ser executado, retorna um SqlDataReader que deve ser lido
        public static SqlDataReader SqlCommand(string queryString, List<string> parNames, List<object> parValues)
        {           

            SqlCommand command = new SqlCommand(queryString, connection);
            for (int i = 0; i < parNames.Count ; i++)
            {
                command.Parameters.AddWithValue(parNames[i], parValues[i]);
            }

            SqlDataReader reader = command.ExecuteReader();      

            
            return reader;
        }
    }
}
