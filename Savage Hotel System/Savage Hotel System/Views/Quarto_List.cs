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
    public partial class Quarto_List : Form
    {
        private Quarto_Menu JanelaQuartoMenu;
        private List<DataGridViewCell> errorCells;
        private List<DataGridViewCell> changedCells;
        private string valorQuandoEntrou;
        private int idSelected;

        public Quarto_List()
        {
            InitializeComponent();
        }

        public Quarto_List(Quarto_Menu Janela)
        {
            InitializeComponent();
            this.JanelaQuartoMenu = Janela;
        }

        public Quarto_List(Quarto_Menu Menu, int idSelected) : this(Menu)
        {
            this.idSelected = idSelected;
        }

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.quartoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void Reserva_Cadastro_Load(object sender, EventArgs e)
        {
            errorCells = new List<DataGridViewCell>();
            changedCells = new List<DataGridViewCell>();
            labelErros.Visible = false;
            labelAlteracoes.Visible = false;
            // TODO: This line of code loads data into the 'quarto._Quarto' table. You can move, or remove it, as needed.
            this.quartoTableAdapter.Fill(this.quarto._Quarto);
            this.quartoDataGridView.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;

            //caso veio do menu de busca seleciona linha com o id da busca
            if (idSelected > 0)
            {
                quartoDataGridView[0, 0].Selected = false;
                foreach (DataGridViewRow row in quartoDataGridView.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == idSelected)
                    {
                        quartoDataGridView[0, row.Index].Selected = true;
                        quartoDataGridView.Rows[row.Index].Selected = true;

                        break;
                    }
                }
            }

        }

        private void quartoDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            //Para CASO a pessoa desista de editar a coluna            
            valorQuandoEntrou = quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Console.WriteLine("Entrou: " + valorQuandoEntrou);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            JanelaQuartoMenu.Show();
            this.Close();
        }

        private void quartoDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            //valor atual do campo
            string valorEditado = quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            // Console.WriteLine("Editou: "+ valorEditado);

            //Cores para quando houver erros ou alterações
            Color errorColor = Color.Red;
            Color successColor = Color.ForestGreen;

            //verifica o valor atual com o de quando entrou na celula para ver se foi alterado algo
            //caso sim entra na verificacao
            if (valorEditado != valorQuandoEntrou)
            {
                //Pegando o nome da coluna onde houve alteração
                string colTitulo = quartoDataGridView.Columns[e.ColumnIndex].HeaderText;
                Funcoes auxfunc = new Funcoes();

                //validando conforme  a coluna
                switch (colTitulo.Trim())
                {

                    case "NumeroQuarto":
                        int verifica = auxfunc.verificanumeroquarto(valorEditado);

                        if (verifica == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else if (verifica == 1)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Este campo possui caracteres inválidos!";
                        }
                        else //caso seja 2
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "O quarto deve ter 4 digitos";
                        }

                        break;

                    case "QuantidadeCamaSolteiro":
                        int verifica2 = auxfunc.verificaQuantidade(valorEditado);

                        if (verifica2 == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else if (verifica2 == 1)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Este campo possui caracteres inválidos ou valor negativo";
                        }                       

                        break;

                    case "QuantidadeCamaCasal":
                        int verifica3 = auxfunc.verificaQuantidade(valorEditado);

                        if (verifica3 == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else if (verifica3 == 1)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Este campo possui caracteres inválidos ou valor negativo";
                        }

                        break;

                    default:
                        if(valorEditado.Trim().Length == 0)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Valor não pode ser vazio";

                        }else
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(quartoDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

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
                        string idLinha = quartoDataGridView[0, cell.RowIndex].Value.ToString();

                        string queryString = "UPDATE " + DataBase.tableQuarto + " SET " + nomeColuna + " = @novoValor Where Id = @idLinha";
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
                    quartoDataGridView.Refresh();
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
            this.quartoTableAdapter.Fill(this.quarto._Quarto);
            errorCells.Clear();
            changedCells.Clear();
            labelAlteracoes.Visible = false;
            labelErros.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (changedCells.Count() == 0)
            {
                DataGridViewCell selecionada = quartoDataGridView.SelectedCells[0];
                if (selecionada != null)
                {
                    string nomeLinha = quartoDataGridView[1, selecionada.RowIndex].Value.ToString();
                    DialogResult result1 = MessageBox.Show("Tem certeza que deseja deletar " + nomeLinha + " ?", "Remoção irreversível!", MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.Yes)
                    {

                        //Id no banco da linha para excluir
                        string idLinha = quartoDataGridView[0, selecionada.RowIndex].Value.ToString();

                        string queryString = "DELETE FROM " + DataBase.tableQuarto + " Where Id = @idLinha";
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
                        quartoDataGridView.Rows.Remove(selecionada.OwningRow);

                    }

                }
                else
                {
                    MessageBox.Show("Nenhuma Dado deletado", "Selecione pelo menos um campo para escluir a linha!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }else
            {
                MessageBox.Show("Salve ou descarte qualquer alteração antes de deletar um Quarto!", "Alterações Pendentes!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void quartoDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //dataGridView1[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red; 
        }

        private void quartoBindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {

        }

        private void Quarto_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                JanelaQuartoMenu.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
