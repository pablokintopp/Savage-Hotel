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
    public partial class Produto_Cadastro : Form
    {
        private int IDFornecedor = -1;
        private Produto_Menu JanelaProdutoMenu;
        public Produto_Cadastro()
        {
            InitializeComponent();
        }

        public Produto_Cadastro(Produto_Menu Janela)
        {
            InitializeComponent();
            this.JanelaProdutoMenu = Janela;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            JanelaProdutoMenu.Show();
            this.Close();
        }
        public void definirID(int newID)
        {
            IDFornecedor = newID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Fornecedor = new Produto_Cadastro_BuscaFornecedor(this);
            Fornecedor.ShowDialog();
        }
        

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.quartoBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void Reserva_Menu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetFornecedor.Fornecedor' table. You can move, or remove it, as needed.
            //this.fornecedorTableAdapter.Fill(this.dataSetFornecedor.Fornecedor);
            panel2.Enabled = false;
            label4.Hide();
            label5.Hide();
            label6.Hide();
        }
        public void refresh() {
            if (IDFornecedor > -1)
            {
                this.fornecedorTableAdapter.Busca_ID(this.dataSetFornecedor.Fornecedor, IDFornecedor);
                panel2.Enabled = true;
            }            
        }

        private void fornecedorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.fornecedorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetFornecedor);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IDFornecedor > -1) {
                label6.Visible = false;
                int retorno = 0;
                int somarerros = 0;
                Funcoes auxfunc = new Funcoes();
                String aux;

                //Mostra Labels
                label4.Show();
                label5.Show();

                //Verifica Descrição
                aux = textBoxNome.Text;
                retorno = auxfunc.verificanome(aux);
                somarerros += retorno;
                switch (retorno)
                {
                    case 0:
                        textBoxNome.BackColor = Color.LightGreen;
                        label4.Text = "";
                        break;
                    case 1:
                        textBoxNome.BackColor = Color.IndianRed;
                        label4.Text = "Presença de Caracteres Inválidos";
                        break;
                    case 2:
                        textBoxNome.BackColor = Color.IndianRed;
                        label4.Text = "Digite algo pelo menos";
                        break;
                }

                //Verifica Preço
                aux = textBoxValor.Text;
                retorno = auxfunc.verificavalor(aux);
                somarerros += retorno;
                switch (retorno)
                {
                    case 0:
                        textBoxValor.BackColor = Color.LightGreen;
                        label5.Text = "";
                        break;
                    case 1:
                        textBoxValor.BackColor = Color.IndianRed;
                        label5.Text = "Preencha apenas com números e com 1 ponto";
                        break;
                    case 2:
                        textBoxValor.BackColor = Color.IndianRed;
                        label5.Text = "Digite no formato xxxx.xx";
                        break;
                }

                if (somarerros == 0)
                {
                    if (InserirBanco() > 0)
                    {
                        MessageBox.Show("Inserido com Sucesso!");
                        this.Close();
                        JanelaProdutoMenu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Houve alguma falha na insercao!");
                    }
                }
            }else
            {
                label6.Show();
                label6.Text = "Selecione Um Fornecedor";
            }
            
        }

        //Metodo que chama a insercao do banco passando como parametros o nome da tabela a ser inserido, os nomes das colunas e respectivos valores
        private int InserirBanco()
        {
            //pega os valores das entradas para serem inseridos 
            List<object> parametrosValores = new List<object>()
            {
                textBoxNome.Text,
                textBoxValor.Text,
                IDFornecedor

            };

            //Estes parametros devem ter o mesmo NOME das colunas da Tabela
            //E devem seguir a mesma ordem de insercao na lista dos valores acima
            List<string> parametrosNomes = new List<string>()
            {
                "Nome",
                "Valor",
                "IdFornecedor"
            };
            string nomeDaTabela = DataBase.tableProduto;
            return DataBase.SqlCommandInsert(nomeDaTabela, parametrosNomes, parametrosValores);

        }

        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            textBoxNome.BackColor = Color.White;
        }

        private void textBoxValor_TextChanged(object sender, EventArgs e)
        {
            textBoxValor.BackColor = Color.White;
        }

        private void Produto_Cadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            JanelaProdutoMenu.Show();
        }
    }
}
