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
        private Produto_Menu MenuProduto;
        public Produto_Cadastro()
        {
            InitializeComponent();
        }

        public Produto_Cadastro(Produto_Menu Menu)
        {
            InitializeComponent();
            this.MenuProduto = Menu;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuProduto.Show();
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
        }
        public void refresh() {
            if (IDFornecedor > -1)
            {
                this.fornecedorTableAdapter.Busca_ID(this.dataSetFornecedor.Fornecedor, IDFornecedor);
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
            int retorno = 0;
            int somarerros = 0;
            Funcoes auxfunc = new Funcoes();
            String aux;

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
                    MenuProduto.Show();
                }
                else
                {
                    MessageBox.Show("Houve alguma falha na insercao!");
                }
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
    }
}
