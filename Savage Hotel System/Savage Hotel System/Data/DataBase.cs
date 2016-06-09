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
        public static string tableCliente = "[dbo].[Cliente]";
        public static string tableFornecedor = "[dbo].[Fornecedor]";
        public static string tableQuarto = "[dbo].[Quarto]";
        public static string tableProduto = "[dbo].[Produto]";

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

        //CONSULTA SQL, retorna um SqlDataReader que contem a tabela de resposta a consulta
        public static SqlDataReader SqlCommand(string queryString, List<string> parNames, List<object> parValues)
        {
            Console.WriteLine("QUERY: "+queryString);

            SqlCommand command = new SqlCommand(queryString, connection);
            if(parNames != null)
            {
                for (int i = 0; i < parNames.Count; i++)
                {
                    command.Parameters.AddWithValue(parNames[i], parValues[i]);
                }
            }
            

            SqlDataReader reader = command.ExecuteReader();

           

            return reader;
        }

        //SQL INSERT, retorna o numero de LInhas afetadas na tabela (geralmente 0 ou 1)
        public static int SqlCommandInsert(string tableName, List<string> parNames, List<object> parValues)
        {
           
            string parameterString = "";
            string parameterValuesString = "";

            //monta as strings dos parametros da consulta nos estilos:
            //(Coluna1,Coluna2,Coluna3...) e (@Coluna1,@Coluna2,@Coluna3...)
            for (int i = 0; i < parNames.Count; i++)
            {
                if (i > 0) { 
                    parameterString += "," + parNames[i];
                    parameterValuesString += ",@" + parNames[i];
                }
                else { 
                    parameterString += parNames[i];
                    parameterValuesString += "@" + parNames[i];
                }
            }

            //String concatenada para a insercao sql
            string queryString = "INSERT INTO " + tableName + "("+parameterString+") VALUES("+parameterValuesString+");";


            SqlCommand command = new SqlCommand(queryString, connection);
            //Add os valores a cada parametro:
            // command.Parameters.AddWithValue(@Coluna1, novoValor);
            for (int i = 0; i < parNames.Count; i++)
            {
                command.Parameters.AddWithValue("@"+parNames[i], parValues[i]);
                
            }
            //executa comando e retorna quantas linhas foram afetadas
            int rowsAfected = command.ExecuteNonQuery();

            
            return rowsAfected;
        }
    }
}
