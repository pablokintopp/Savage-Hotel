﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Savage_Hotel_System.Data;
using Savage_Hotel_System.Class;

namespace Savage_Hotel_System.Views
{
    public partial class Reserva_Cadastro : Form
    {
        private int IDQuarto = -1;
        private int IDCliente = -1;
        private Reserva_Menu MenuReserva;
        public Reserva_Cadastro()
        {
            InitializeComponent();
        }

        public Reserva_Cadastro(Reserva_Menu MenuReserva)
        {
            InitializeComponent();
            this.MenuReserva = MenuReserva;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuReserva.Show();
            this.Close();
        }
        public void DefinirIDQuarto(int newIDQuarto)
        {
            IDQuarto = newIDQuarto;
        }

        public void DefinirIDCliente(int newIDCliente)
        {
            IDCliente = newIDCliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Quartos = new Reserva_IncluirQuarto(this);
            //this.Hide();
            //Quartos.Show();
            Quartos.ShowDialog();
        }
        

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.quartoBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void Reserva_Menu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetCliente.Cliente' table. You can move, or remove it, as needed.
            //this.clienteTableAdapter.Fill(this.dataSetCliente.Cliente);
            // TODO: This line of code loads data into the 'quarto._Quarto' table. You can move, or remove it, as needed.
            //this.quartoTableAdapter.Fill(this.quarto._Quarto);

            //idTextBox.Text = idquarto.ToString();
            panel3.Enabled = false;

        }
        public void refresh() {
            if (IDCliente > -1)
            {
                this.clienteTableAdapter.Busca_ID(this.dataSetCliente.Cliente, IDCliente);
                panel3.Enabled = true;
            }
            if (IDQuarto > -1)
            {
                //numeroQuartoTextBox.Text = ID.ToString();
                this.quartoTableAdapter.Busca_ID(this.quarto._Quarto, IDQuarto);
            }
        }

        private void quartoBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.quartoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Cliente = new Reserva_IncluirCliente(this);
            this.Hide();
            Cliente.Show();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            int somarerros = 0;
            int retorno = 0;
            if (IDCliente > -1) {
                if (IDQuarto > -1) {
                    String DataEntrada = dateTimeEntrada.Text;
                    String DataSaida = dateTimePickerSaida.Text;
                    Funcoes auxfunc = new Funcoes();

                    //Verifica Datas de Reserva
                    retorno = auxfunc.VerificaDataReserva(DataEntrada,DataSaida);
                    somarerros += retorno;
                    switch (retorno)
                    {
                        case 0:
                            dateTimeEntrada.BackColor = Color.LightGreen;
                            label5.Text = "";
                            break;
                        case 1:
                            dateTimeEntrada.BackColor = Color.IndianRed;
                            label5.Text = "Data do mesmo dia não é Permitido";
                            break;
                        case 2:
                            dateTimeEntrada.BackColor = Color.IndianRed;
                            label5.Text = "Datas passadas São Inválidas";
                            break;
                    }

                    if (somarerros == 0)
                    {
                        if (InserirBanco() > 0)
                        {
                            MessageBox.Show("Inserido com Sucesso!");
                            this.Close();
                            this.MenuReserva.Show();
                        }
                        else
                        {
                            MessageBox.Show("Houve alguma falha na insercao!");
                        }
                    }
                }
            }
        }

        //Metodo que chama a insercao do banco passando como parametros o nome da tabela a ser inserido, os nomes das colunas e respectivos valores
        private int InserirBanco()
        {
            //Console.WriteLine("DATA: " + dateTimeNascimento.Value.ToString("dd/MM/yyyy"));
            //pega os valores das entradas para serem inseridos 
            List<object> parametrosValores = new List<object>()
            {
                0,
                dateTimeEntrada.Text,
                dateTimePickerSaida.Text,
                IDCliente,
                IDQuarto

            };

            //Estes parametros devem ter o mesmo NOME das colunas da Tabela
            //E devem seguir a mesma ordem de insercao na lista dos valores acima
            List<string> parametrosNomes = new List<string>()
            {
                "Valor",
                "InicioReserva",
                "FimReserva",
                "IdCLiente",
                "IdQuarto"
            };
            string nomeDaTabela = DataBase.tableReserva;
            return DataBase.SqlCommandInsert(nomeDaTabela, parametrosNomes, parametrosValores);

        }

    }
}