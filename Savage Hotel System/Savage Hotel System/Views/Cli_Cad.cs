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
    public partial class Cli_Cad : Form
    {
        private Cli_Menu JanelaClienteMenu = null;
        private Reserva_IncluirCliente JanelaAnteriorReserva = null;

        public Cli_Cad()
        {
            InitializeComponent();
        }

        public Cli_Cad(Cli_Menu Janela)
        {
            InitializeComponent();
            this.JanelaClienteMenu = Janela;
        }

        public Cli_Cad(Reserva_IncluirCliente Janela)
        {
            InitializeComponent();
            this.JanelaAnteriorReserva = Janela;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            voltar_janela();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Func_Cad_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseHotelDataSet.Funcionario' table. You can move, or remove it, as needed.
            // this.funcionarioTableAdapter.Fill(this.databaseHotelDataSet.Funcionario);

            //Definir a data de hoje no campo Data
            dateTimeNascimento.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int retorno = 0;
            int somarerros = 0;
            Funcoes auxfunc = new Funcoes();
            String aux;
            
            //Mostra Labels
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();

            //Verifica Nome
            aux = textBoxNome.Text;
            retorno = auxfunc.verificanome(aux);
            somarerros += retorno;
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
            somarerros += retorno;
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

            //Verifica CPF
            aux = textBoxCPF.Text;
            retorno = auxfunc.verificacpf(aux);
            somarerros += retorno;
            switch (retorno)
            {
                case 0:
                    textBoxCPF.BackColor = Color.LightGreen;
                    label3.Text = "";
                    break;
                case 1:
                    textBoxCPF.BackColor = Color.IndianRed;
                    label3.Text = "Preencha apenas com números";
                    break;
                case 2:
                    textBoxCPF.BackColor = Color.IndianRed;
                    label3.Text = "O Tamanho do Campo é Inválido";
                    break;
            }

            //Verifica Data de Nascimento
            String dia;
            dia = dateTimeNascimento.Text;
            label4.Text = dia[0].ToString();
            aux = dateTimeNascimento.Text;
            retorno = auxfunc.VerificaDataNascimento(aux);
            somarerros += retorno;
            switch (retorno)
            {
                case 0:
                    dateTimeNascimento.BackColor = Color.LightGreen;
                    label4.Text = "";
                    break;
                case 1:
                    dateTimeNascimento.BackColor = Color.IndianRed;
                    label4.Text = "Data de hoje não é Permitido";
                    break;
                case 2:
                    dateTimeNascimento.BackColor = Color.IndianRed;
                    label4.Text = "Datas futuras São Inválidas";
                    break;
            }

            if (somarerros == 0) {
                if (InserirBanco() > 0) {
                    MessageBox.Show("Inserido com Sucesso!");
                    this.Close();
                    voltar_janela();
                }
                else
                {
                    MessageBox.Show("Houve alguma falha na insercao!");
                } 
            }
        }

        private void voltar_janela() {
            this.Close();
            if (JanelaAnteriorReserva != null)
            {
                JanelaAnteriorReserva.Show();
                //É necessário recarregar as listas de auto completar
                JanelaAnteriorReserva.refresh();
            }
            else
            {
                if (JanelaClienteMenu != null)
                {
                    JanelaClienteMenu.Show();
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
            textBoxCPF.BackColor = Color.White;
        }      

        //Metodo que chama a insercao do banco passando como parametros o nome da tabela a ser inserido, os nomes das colunas e respectivos valores
        private int InserirBanco()
        {
            //pega os valores das entradas para serem inseridos 
            List<object> parametrosValores = new List<object>()
            {
                textBoxNome.Text,
                radioButton1.Checked ? "M":"F",
                textBoxCPF.Text,
                textBoxPhone.Text,
                dateTimeNascimento.Text

            };

            //Estes parametros devem ter o mesmo NOME das colunas da Tabela
            //E devem seguir a mesma ordem de insercao na lista dos valores acima
            List<string> parametrosNomes = new List<string>()
            {
                "Name",
                "Gender",
                "CPF",
                "Phone",
                "Birthday"
            };
            string nomeDaTabela = DataBase.tableCliente;
            return DataBase.SqlCommandInsert(nomeDaTabela, parametrosNomes, parametrosValores);

        }

        private void Cli_Cad_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                JanelaClienteMenu.Show();
            }
            catch (Exception)
            {                
            }
        }
    }
}
