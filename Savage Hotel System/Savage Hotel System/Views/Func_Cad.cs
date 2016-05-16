using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Savage_Hotel_System.Class;

namespace Savage_Hotel_System.Views
{
    public partial class Func_Cad : Form
    {
        private Func_Menu JanelaAnterior;

        public Func_Cad()
        {
            InitializeComponent();
        }

        public Func_Cad(Func_Menu Janela)
        {
            InitializeComponent();
            this.JanelaAnterior = Janela;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            JanelaAnterior.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Func_Cad_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseHotelDataSet.Funcionario' table. You can move, or remove it, as needed.
            this.funcionarioTableAdapter.Fill(this.databaseHotelDataSet.Funcionario);

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
            label4.Show();
            label5.Show();

            //Verifica Nome
            aux = textBox1.Text;
            retorno = auxfunc.verificanome(aux);
            somaretornos += retorno;
            switch (retorno)
            {
                case 0:
                    textBox1.BackColor = Color.LightGreen;
                    label1.Text = "";
                    break;
                case 1:
                    textBox1.BackColor = Color.IndianRed;
                    label1.Text = "Presença de Caracteres Inválidos";
                    break;
                case 2:
                    textBox1.BackColor = Color.IndianRed;
                    label1.Text = "Digite pelo menos o primeiro nome";
                    break;
            }




            //Verifica Telefone
            aux = textBox2.Text;
            retorno=auxfunc.verificatelefone(aux);
            somaretornos += retorno;
            switch (retorno) {
                case 0:
                    textBox2.BackColor = Color.LightGreen;
                    label2.Text = "";
                    break;
                case 1:
                    textBox2.BackColor = Color.IndianRed;
                    label2.Text = "Preencha apensa com números";
                    break;
                case 2:
                    textBox2.BackColor = Color.IndianRed ;
                    label2.Text = "O Tamanho do Campo é Inválido";
                    break;
            }

            //Verifica CPF
            aux = textBox3.Text;
            retorno = auxfunc.verificacpf(aux);
            somaretornos += retorno;
            switch (retorno)
            {
                case 0:
                    textBox3.BackColor = Color.LightGreen;
                    label3.Text = "";
                    break;
                case 1:
                    textBox3.BackColor = Color.IndianRed;
                    label3.Text = "Preencha apensa com números";
                    break;
                case 2:
                    textBox3.BackColor = Color.IndianRed;
                    label3.Text = "O Tamanho do Campo é Inválido";
                    break;
            }

            //Verifica Salário
            aux = textBox5.Text;
            retorno = auxfunc.verificasalario(aux);
            somaretornos += retorno;
            switch (retorno)
            {
                case 0:
                    textBox5.BackColor = Color.LightGreen;
                    label5.Text = "";
                    break;
                case 1:
                    textBox5.BackColor = Color.IndianRed;
                    label5.Text = "Preencha apensa com números";
                    break;
                case 2:
                    textBox5.BackColor = Color.IndianRed;
                    label5.Text = "Digite pelo menos um número";
                    break;
            }




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.BackColor = Color.White;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
