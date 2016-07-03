using Savage_Hotel_System.Class;
using Savage_Hotel_System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Savage_Hotel_System.Views
{
    public partial class Fornecedor_List : Form
    {
        private Fornecedor_Menu JanelaFornecedorMenu;
        private string valorQuandoEntrou;
        private List<DataGridViewCell> errorCells;
        private List<DataGridViewCell> changedCells;
        private int idSelected;

        public Fornecedor_List()
        {
            InitializeComponent();
        }

        public Fornecedor_List(Fornecedor_Menu Janela)
        {
            InitializeComponent();
            this.JanelaFornecedorMenu = Janela;
        }

        public Fornecedor_List(Fornecedor_Menu fornecedor_Menu, int idSelected) : this(fornecedor_Menu)
        {
            this.idSelected = idSelected;
        }

        private void Fornecedor_List_Load(object sender, EventArgs e)
        {

            errorCells = new List<DataGridViewCell>();
            changedCells = new List<DataGridViewCell>();
            labelErros.Visible = false;
            labelAlteracoes.Visible = false;
            // TODO: This line of code loads data into the 'databaseHotelDataSet3.Fornecedor' table. You can move, or remove it, as needed.
            this.fornecedorTableAdapter.Fill(this.databaseHotelDataSet3.Fornecedor);

            this.dataGridView1.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;

            //caso veio do menu de busca seleciona linha com o id da busca
            if (idSelected > 0)
            {
                dataGridView1[0, 0].Selected = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == idSelected)
                    {
                        dataGridView1[0, row.Index].Selected = true;
                        dataGridView1.Rows[row.Index].Selected = true;

                        break;
                    }
                }
            }

        }



        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            //Para CASO a pessoa desista de editar a coluna            
            valorQuandoEntrou = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Console.WriteLine("Entrou: " + valorQuandoEntrou);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            JanelaFornecedorMenu.Show();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            //valor atual do campo
            string valorEditado = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            // Console.WriteLine("Editou: "+ valorEditado);

            //Cores para quando houver erros ou alterações
            Color errorColor = Color.Red;
            Color successColor = Color.ForestGreen;

            //verifica o valor atual com o de quando entrou na celula para ver se foi alterado algo
            //caso sim entra na verificacao
            if (valorEditado != valorQuandoEntrou)
            {
                //Pegando o nome da coluna onde houve alteração
                string colTitulo = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                Funcoes auxfunc = new Funcoes();

                //validando conforme  a coluna
                switch (colTitulo.Trim())
                {

                    case "Nome":
                        int verifica = auxfunc.verificanome(valorEditado);

                        if (verifica == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else if (verifica == 1)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Este campo possui caracteres inválidos!";
                        }
                        else //caso seja 2
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Tamanho mínimo do campo não foi satisfeito";
                        }

                        break;
                    case "CNPJ":
                        int verifica2 = auxfunc.verificacnpj(valorEditado);

                        if (verifica2 == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else if (verifica2 == 1)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Este campo possui caracteres inválidos!";
                        }
                        else //caso seja 2
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Tamanho mínimo do campo não foi satisfeito";
                        }
                        break;                    
                    
                    case "Telefone":
                        int verifica4 = auxfunc.verificatelefone(valorEditado);

                        if (verifica4 == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else if (verifica4 == 1)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Contém caracteres inválidos!";
                        }
                        else
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Telefone deve conter 10 digitos";

                        }

                        break;
                }

            }

            if (errorCells.Count > 0)
                labelErros.Visible = true;
            else
                labelErros.Visible = false;

            if (changedCells.Count > 0)
                labelAlteracoes.Visible = true;
            else
                labelAlteracoes.Visible = false;

            foreach (DataGridViewCell cell in errorCells)
            {
                cell.Style.ForeColor = errorColor;

            }

            Console.WriteLine("Erros: " + errorCells.Count);
            Console.WriteLine("Alterações: " + changedCells.Count);
            foreach (DataGridViewCell cell in changedCells)
            {
                cell.ToolTipText = "Alteração ainda não confirmada";
                cell.Style.ForeColor = successColor;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (errorCells.Count > 0)
            {
                MessageBox.Show("Existem Erros nas Alterações! Favor Corrigi-los antes de Salvar.", "Operação não Completada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (changedCells.Count > 0)
                {

                    foreach (DataGridViewCell cell in changedCells)
                    {

                        //Coluna onde ouver alteração
                        string nomeColuna = cell.OwningColumn.DataPropertyName;

                        //Valor alterado
                        string novoValor = cell.Value.ToString();
                        //Id no banco da linha alterada para usar no update
                        string idLinha = dataGridView1["idDataGridViewTextBoxColumn", cell.RowIndex].Value.ToString();

                        string queryString = "UPDATE " + DataBase.tableFornecedor + " SET " + nomeColuna + " = @novoValor Where Id = @idLinha";
                        //chamando função da query paramateros (querystring, lista parametros, lista valores)
                        var reader = DataBase.SqlCommand(queryString,
                            new List<string>() {
                                "@novoValor",
                                 "@idLinha"

                              }, new List<object>() {
                                      novoValor,
                                      idLinha
                        });

                        //fechando a query, causa erros se nao fechar
                        reader.Close();

                        //volta a cor normal
                        cell.Style.ForeColor = Color.Black;
                        labelAlteracoes.Visible = false;


                    }

                    MessageBox.Show("Todas alterações foram salvas!", "Alterações realizadas co Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Refresh();
                    changedCells.Clear();
                }
                else
                {
                    MessageBox.Show("Nenhuma Alteração foi feita", "Nenhuma Alteração Executada!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.fornecedorTableAdapter.Fill(this.databaseHotelDataSet3.Fornecedor);
            errorCells.Clear();
            changedCells.Clear();
            labelAlteracoes.Visible = false;
            labelErros.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewCell selecionada = dataGridView1.SelectedCells[0];
            if (selecionada != null)
            {
                string nomeLinha = dataGridView1["nameDataGridViewTextBoxColumn", selecionada.RowIndex].Value.ToString();
                DialogResult result1 = MessageBox.Show("Tem certeza que deseja deletar " + nomeLinha + " ?", "Remoção irreversível!", MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {

                    //Id no banco da linha para excluir
                    string idLinha = dataGridView1["idDataGridViewTextBoxColumn", selecionada.RowIndex].Value.ToString();

                    string queryString = "DELETE FROM " + DataBase.tableFornecedor + " Where Id = @idLinha";
                    //chamando função da query paramateros (querystring, lista parametros, lista valores)
                    var reader = DataBase.SqlCommand(queryString,
                        new List<string>() {
                                 "@idLinha"

                          }, new List<object>() {
                                      idLinha
                    });

                    //fechando a query, causa erros se nao fechar
                    reader.Close();
                    //remove da view
                    dataGridView1.Rows.Remove(selecionada.OwningRow);

                }

            }
            else
            {
                MessageBox.Show("Nenhuma Dado deletado", "Selecione pelo menos um campo para escluir a linha!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //dataGridView1[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red; 
        }

        private void Fornecedor_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            JanelaFornecedorMenu.Show();
        }
    }
}
