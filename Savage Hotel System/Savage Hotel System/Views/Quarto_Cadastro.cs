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
    public partial class Quarto_Cadastro : Form
    {
        private Quarto_Menu JanelaAnterior;
        private int QuantidadeDeQuartosCadastrados = 0;

        public Quarto_Cadastro()
        {
            InitializeComponent();
        }

        public Quarto_Cadastro(Quarto_Menu Janela)
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
            QuantidadeDeQuartosCadastrados = (int)this.quartoTableAdapter.QuantidadeDeQuartosCadastrados();
            textBoxNumeroQuarto.Text = (1000 + QuantidadeDeQuartosCadastrados + 1).ToString();



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
            label4.Show();
            label5.Show();

            //Verifica Descrição
            aux = textBoxDescricao.Text;
            retorno = auxfunc.verificanome(aux);
            somarerros += retorno;
            switch (retorno)
            {
                case 0:
                    textBoxDescricao.BackColor = Color.LightGreen;
                    label1.Text = "";
                    break;
                case 1:
                    textBoxDescricao.BackColor = Color.IndianRed;
                    label1.Text = "Presença de Caracteres Inválidos";
                    break;
                case 2:
                    textBoxDescricao.BackColor = Color.IndianRed;
                    label1.Text = "Digite algo pelo menos";
                    break;
            }

            //Verifica Número Do Quarto
            aux = textBoxNumeroQuarto.Text;
            retorno = auxfunc.verificanumeroquarto(aux);
            somarerros += retorno;
            switch (retorno)
            {
                case 0:
                    textBoxNumeroQuarto.BackColor = Color.LightGreen;
                    label2.Text = "";
                    break;
                case 1:
                    textBoxNumeroQuarto.BackColor = Color.IndianRed;
                    label2.Text = "Preencha Apenas Com Números";
                    break;
                case 2:
                    textBoxNumeroQuarto.BackColor = Color.IndianRed;
                    label2.Text = "Digite só 4 Números";
                    break;
            }

            //Verifica Quantia de Camas
            int numerocamas;
            numerocamas = numericUpDown1.Text[0] - 48;
            numerocamas += numericUpDown2.Text[0] - 48;
            switch (numerocamas)
            {
                case 0:
                    numericUpDown1.BackColor = Color.IndianRed;
                    numericUpDown2.BackColor = Color.IndianRed;
                    label4.Text = "O quarto deve possuir pelo menos uma cama solteiro";
                    label5.Text = "ou pelo menos uma cama de casal";
                    retorno = 1;
                    break;
                default:
                    numericUpDown1.BackColor = Color.LightGreen;
                    numericUpDown2.BackColor = Color.LightGreen;
                    label4.Text = "";
                    label5.Text = "";
                    retorno = 0;
                    break;
            }
            somarerros += retorno;



            if (somarerros == 0)
            {
                if (InserirBanco() > 0)
                {
                    MessageBox.Show("Inserido com Sucesso!");
                    this.Close();
                    JanelaAnterior.Show();
                }
                else
                {
                    MessageBox.Show("Houve alguma falha na insercao!");
                }
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBoxDescricao.BackColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBoxNumeroQuarto.BackColor = Color.White;
        }     

        //Metodo que chama a insercao do banco passando como parametros o nome da tabela a ser inserido, os nomes das colunas e respectivos valores
        private int InserirBanco()
        {
            //pega os valores das entradas para serem inseridos 
            List<object> parametrosValores = new List<object>()
            {
                textBoxDescricao.Text,
                textBoxNumeroQuarto.Text,
                numericUpDown1.Text,
                numericUpDown2.Text,
                "disponivel"

            };

            //Estes parametros devem ter o mesmo NOME das colunas da Tabela
            //E devem seguir a mesma ordem de insercao na lista dos valores acima
            List<string> parametrosNomes = new List<string>()
            {
                "Descricao",
                "NumeroQuarto",
                "QuantidadeCamaSolteiro",
                "QuantidadeCamaCasal",
                "Status"
            };
            string nomeDaTabela = DataBase.tableQuarto;
            return DataBase.SqlCommandInsert(nomeDaTabela, parametrosNomes, parametrosValores);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

        }

        private void quartoBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.quartoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void quartoBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.quartoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quarto);

        }
    }
}
