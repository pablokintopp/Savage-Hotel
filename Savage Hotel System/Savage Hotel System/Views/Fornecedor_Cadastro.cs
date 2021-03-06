﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Savage_Hotel_System.Class;
using Savage_Hotel_System.Data;

namespace Savage_Hotel_System.Views
{
    public partial class Fornecedor_Cadastro : Form
    {
        private Fornecedor_Menu JanelaFornecedorMenu;

        public Fornecedor_Cadastro()
        {
            InitializeComponent();
        }

        public Fornecedor_Cadastro(Fornecedor_Menu Janela)
        {
            InitializeComponent();
            this.JanelaFornecedorMenu = Janela;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            JanelaFornecedorMenu.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Func_Cad_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseHotelDataSet.Funcionario' table. You can move, or remove it, as needed.
           // this.funcionarioTableAdapter.Fill(this.databaseHotelDataSet.Funcionario);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int retorno = 0;
            int somaretornos = 0;
            Funcoes auxfunc = new Funcoes();
            String aux;
            
            //Mostra Labels
            label1.Show();
            label2.Show();
            label3.Show();

            //Verifica Nome
            aux = textBoxNome.Text;
            retorno = auxfunc.verificanome(aux);
            somaretornos += retorno;
            switch (retorno)
            {
                case 0:
                    textBoxNome.BackColor = Color.LightGreen;
                    label1.Text = "";
                    break;
                case 1:
                    textBoxNome.BackColor = Color.IndianRed;
                    label1.Text = "Presença de Caracteres Inválidos";
                    break;
                case 2:
                    textBoxNome.BackColor = Color.IndianRed;
                    label1.Text = "Digite pelo menos o primeiro nome";
                    break;
            }

            //Verifica Telefone
            aux = textBoxPhone.Text;
            retorno=auxfunc.verificatelefone(aux);
            somaretornos += retorno;
            switch (retorno) {
                case 0:
                    textBoxPhone.BackColor = Color.LightGreen;
                    label2.Text = "";
                    break;
                case 1:
                    textBoxPhone.BackColor = Color.IndianRed;
                    label2.Text = "Preencha apenas com números";
                    break;
                case 2:
                    textBoxPhone.BackColor = Color.IndianRed ;
                    label2.Text = "O Tamanho do Campo é Inválido";
                    break;
            }

            //Verifica CNPJ
            aux = textBoxCNPJ.Text;
            retorno = auxfunc.verificacnpj(aux);
            somaretornos += retorno;
            switch (retorno)
            {
                case 0:
                    textBoxCNPJ.BackColor = Color.LightGreen;
                    label3.Text = "";
                    break;
                case 1:
                    textBoxCNPJ.BackColor = Color.IndianRed;
                    label3.Text = "Preencha apenas com números";
                    break;
                case 2:
                    textBoxCNPJ.BackColor = Color.IndianRed;
                    label3.Text = "O Tamanho do Campo é Inválido";
                    break;
            }

            if (somaretornos == 0)
            {
                if (InserirBanco() > 0)
                {
                    MessageBox.Show("Inserido com Sucesso!");
                    this.Close();
                    JanelaFornecedorMenu.Show();
                }
                else
                {
                    MessageBox.Show("Houve alguma falha na insercao!");
                }
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBoxNome.BackColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBoxPhone.BackColor = Color.White;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBoxCNPJ.BackColor = Color.White;
        }      

        //Metodo que chama a insercao do banco passando como parametros o nome da tabela a ser inserido, os nomes das colunas e respectivos valores
        private int InserirBanco()
        {
            //pega os valores das entradas para serem inseridos 
            List<object> parametrosValores = new List<object>()
            {
                textBoxNome.Text,
                textBoxCNPJ.Text,
                textBoxPhone.Text
            };

            //Estes parametros devem ter o mesmo NOME das colunas da Tabela
            //E devem seguir a mesma ordem de insercao na lista dos valores acima
            List<string> parametrosNomes = new List<string>()
            {
                "Name",
                "CNPJ",
                "Phone"
            };
            string nomeDaTabela = DataBase.tableFornecedor;
            return DataBase.SqlCommandInsert(nomeDaTabela, parametrosNomes, parametrosValores);

        }

        private void Fornecedor_Cadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                JanelaFornecedorMenu.Show();
            }
            catch (Exception)
            {
                                
            }
        }
    }
}
