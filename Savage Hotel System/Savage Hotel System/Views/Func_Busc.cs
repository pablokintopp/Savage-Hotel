﻿using Savage_Hotel_System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Savage_Hotel_System.Views
{
    public partial class Func_Busc : Form
    {
        private Func_Menu JanelaFuncMenu;
        private Func_List JanelaFuncList;
        private int idSelected = 0;
        //resultado da pre-pesquisa
        private AutoCompleteStringCollection result;
        //colunas a serem pre-pesquisadas
        private List<String> columnsName;
        private List<String> columnsNameExibicao;
        
        public Func_Busc()
        {
            InitializeComponent();
        }
        public Func_Busc(Func_Menu Janela)
        {
            InitializeComponent();
            this.JanelaFuncMenu = Janela;

        }

        private void Func_Busc_Load(object sender, EventArgs e)
        {
            //busca todas informacoes de funcionario e armazena num array
            //este array sera usado pra sugerir e autopletar dados no campo de busca
            String queryString = "Select * from "+DataBase.tableFuncionario;
            SqlDataReader dataReader = DataBase.SqlCommand(queryString, null, null);
            result = new AutoCompleteStringCollection();

            //inicializa as listas com os nomes reais das colunas e o nome que sera exibido ao usuario
            columnsName = new List<string>();
            columnsNameExibicao = new List<string>();
            columnsName.Add("Name");
            columnsNameExibicao.Add("Nome");
            columnsName.Add("Phone");
            columnsNameExibicao.Add("Telefone");
            columnsName.Add("CPF");
            columnsNameExibicao.Add("CPF");
            columnsName.Add("Office");
            columnsNameExibicao.Add("Cargo");
            columnsName.Add("Login");
            columnsNameExibicao.Add("Usuario");



            //add cada dado em funcionario a lista do autocompletar result
            while (dataReader.Read())
            {
                //result.AddRange(dataReader.);
                foreach( String colName in columnsName)
                {
                    result.Add(Convert.ToString(dataReader[colName]));
                    //Console.WriteLine("DEBUG" + result[result.Count - 1]);

                }
                
            }
            dataReader.Close();

            //faz o link do campo de busca com a lista de sugestoes/autocompletar
            textBoxSearch.AutoCompleteCustomSource = result;
            
        }

        //handler para tecla pressionada
        //usando para quando for apertado a tecla enter
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {                
                executeQuery();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            executeQuery();
        }

        public void executeQuery()
        {
            if (textBoxSearch.Text.Length > 3)
            {
                labelErros.Visible = false;
                String value = textBoxSearch.Text.Trim();
                value = "%" + value + "%";

                String queryString = "Select Id as codigo";

                List<String> parNames = new List<String>();
                List<Object> parValues = new List<Object>();

                for (int i = 0; i < columnsName.Count; i++)
                {
                    queryString += " , " + columnsName[i] + " as " + columnsNameExibicao[i];

                }

                queryString += " from " + DataBase.tableFuncionario + " where ";

                for (int i = 0; i < columnsName.Count; i++)
                {
                    if (i > 0)
                    {
                        queryString += " or UPPER(" + columnsName[i] + ") like UPPER(@" + columnsName[i] + ")";
                    }
                    else
                    {
                        queryString += "UPPER(" + columnsName[i] + ") like UPPER(@" + columnsName[i] + ")";

                    }
                    parNames.Add("@" + columnsName[i]);
                    parValues.Add(value);

                }
                SqlDataReader reader = DataBase.SqlCommand(queryString, parNames, parValues);

                //Add resultado da busca ao datagridview
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();



                reader.Close();

            }
            else
            {
                labelErros.Visible = true;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            JanelaFuncMenu.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataGridViewCell selected = dataGridView1.SelectedCells[0];
            idSelected = Convert.ToInt32(dataGridView1.Rows[selected.RowIndex].Cells[0].Value);
            JanelaFuncList = new Func_List(JanelaFuncMenu, idSelected);
            JanelaFuncList.Show();
            this.Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
                button1.Visible = true;
            else
                button1.Visible = false;

        }

        private void Func_Busc_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { 
                JanelaFuncMenu.Show();
            }catch(Exception exc)
            {

            }
        }
    }
}
