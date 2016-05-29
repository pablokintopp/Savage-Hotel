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
using Savage_Hotel_System.Data;

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
            label4.Show();
            label5.Show();
            label14.Show();
            label16.Show();
            label17.Show();

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

            //Verifica CPF
            aux = textBoxCPF.Text;
            retorno = auxfunc.verificacpf(aux);
            somaretornos += retorno;
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

            //Verifica Sexo
            String sexo;
            if (radioButton1.Checked == true)
            {
                sexo = "M";
            }
            else {
                if (radioButton2.Checked == true) {
                    sexo = "F";
                }
            }

            //Verifica Data
            label4.Text = dateTimeNascimento.Text;


            //Cargo
            String Cargo;
            Cargo = comboBoxCargo.Text;
            if (Cargo.Length == 0)
            {
                label14.Text = "Selecione um cargo";
                somaretornos += 1;
            }
            else {
                label14.Text = "";
            }
                       

            //Verifica Salário
            aux = textBoxSalario.Text;
            retorno = auxfunc.verificasalario(aux);
            somaretornos += retorno;
            switch (retorno)
            {
                case 0:
                    textBoxSalario.BackColor = Color.LightGreen;
                    label5.Text = "";
                    break;
                case 1:
                    textBoxSalario.BackColor = Color.IndianRed;
                    label5.Text = "Preencha apensa com números";
                    break;
                case 2:
                    textBoxSalario.BackColor = Color.IndianRed;
                    label5.Text = "Digite pelo menos um número";
                    break;
            }

            //Verificar Login
            aux = textBoxLogin.Text;
            if (aux.Length < 5)
            {
                textBoxLogin.BackColor = Color.IndianRed;
                label16.Text = "Insira pelo menos 5 caracteres";
                somaretornos += 1;
            }
            else {
                label16.Text = "";
                textBoxLogin.BackColor = Color.LightGreen;
            }

            //Verificar Password
            aux = textBoxSenha.Text;
            if (aux.Length < 5)
            {
                textBoxSenha.BackColor = Color.IndianRed;
                label17.Text = "Insira pelo menos 5 caracteres";
                somaretornos += 1;
            }
            else
            {
                label17.Text = "";
                textBoxSenha.BackColor = Color.LightGreen;
            }

            if (somaretornos == 0) {
                if (InserirBanco() > 0) {
                    MessageBox.Show("Inserido com Sucesso!");
                    this.Close();
                    this.JanelaAnterior.Show();
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
            textBoxCPF.BackColor = Color.White;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBoxSalario.BackColor = Color.White;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBoxLogin.BackColor = Color.White;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBoxSenha.BackColor = Color.White;
        }


       

        //Metodo que chama a insercao do banco passando como parametros o nome da tabela a ser inserido, os nomes das colunas e respectivos valores
        private int InserirBanco()
        {

            Console.WriteLine("DATA: "+ dateTimeNascimento.Value.ToString("dd/MM/yyyy"));
            //pega os valores das entradas para serem inseridos 
            List<object> parametrosValores = new List<object>()
            {
                textBoxNome.Text,
                textBoxPhone.Text,
                textBoxCPF.Text,
                radioButton1.Checked ? "M":"F",
                dateTimeNascimento.Value.ToString("dd/MM/yyyy"),
                "0",
                textBoxSalario.Text,
                textBoxLogin.Text,
                textBoxSenha.Text

            };

            //Estes parametros devem ter o mesmo NOME das colunas da Tabela
            //E devem seguir a mesma ordem de insercao na lista dos valores acima
            List<string> parametrosNomes = new List<string>()
            {
                "Name",
                "Phone",
                "CPF",
                "Gender",
                "Birthday",
                "IsManager",
                "Salary",
                "Login",
                "Password"

            };
            string nomeDaTabela = DataBase.tableFuncionario;
            return DataBase.SqlCommandInsert(nomeDaTabela, parametrosNomes, parametrosValores);

        }

    }
}
