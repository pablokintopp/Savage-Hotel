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
    public partial class Func_List : Form
    {
        private Func_Menu JanelaFuncMenu;
        private string valorQuandoEntrou;
        private List<DataGridViewCell> errorCells;
        private List<DataGridViewCell> changedCells;
        private int idBusca = -1;
        public Func_List()
        {
            InitializeComponent();
        }

        public Func_List(Func_Menu Janela)
        {
            InitializeComponent();
            this.JanelaFuncMenu = Janela;
           
        }
        public Func_List(Func_Menu func_Menu , int idBusca)
        {
            InitializeComponent();
            this.JanelaFuncMenu = func_Menu;
            this.idBusca = idBusca;

        }

        private void Func_List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseHotelDataSet1.Funcionario' table. You can move, or remove it, as needed.
            this.funcionarioTableAdapter.Fill(this.databaseHotelDataSet1.Funcionario);
            errorCells = new List<DataGridViewCell>();
            changedCells = new List<DataGridViewCell>();
            labelErros.Visible = false;
            labelAlteracoes.Visible = false;
            // TODO: This line of code loads data into the 'databaseHotelDataSet1.Funcionario' table. You can move, or remove it, as needed.
            this.funcionarioTableAdapter.Fill(this.databaseHotelDataSet1.Funcionario);

            //Desabilitando o update automatico do banco pois queremos validar antes.
            this.funcionarioDataGridView.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
           
            //caso veio do menu de busca seleciona linha com o id da busca
            if(idBusca > 0)
            {
                funcionarioDataGridView.ClearSelection();
               funcionarioDataGridView[0, 0].Selected = false;
               foreach(DataGridViewRow row in funcionarioDataGridView.Rows)
                {
                    if(Convert.ToInt32( row.Cells[0].Value )== idBusca)
                    {
                        funcionarioDataGridView[0, row.Index].Selected = true;
                        funcionarioDataGridView.Rows[row.Index].Selected = true;
                        
                        break;
                    }
                }
            }
        }



        private void funcionarioBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void funcionarioDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            //Para CASO a pessoa desista de editar a coluna            
            valorQuandoEntrou = funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Console.WriteLine("Entrou: "+ valorQuandoEntrou);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            JanelaFuncMenu.Show();
        }

        private void funcionarioDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
           //valor atual do campo
            string valorEditado = funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            // Console.WriteLine("Editou: "+ valorEditado);

            //Cores para quando houver erros ou alterações
            Color errorColor = Color.Red;
            Color successColor = Color.ForestGreen;

            //verifica o valor atual com o de quando entrou na celula para ver se foi alterado algo
            //caso sim entra na verificacao
            if (valorEditado != valorQuandoEntrou)
            {
                //Pegando o nome da coluna onde houve alteração
                string colTitulo = funcionarioDataGridView.Columns[e.ColumnIndex].HeaderText;
                Funcoes auxfunc = new Funcoes();
                
                //validando conforme  a coluna
                switch (colTitulo.Trim())
                {
                    
                    case "Nome":
                        int verifica = auxfunc.verificanome(valorEditado);
                        
                        if (verifica == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);                          

                        }else if(verifica == 1){
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);                          
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Este campo possui caracteres inválidos!";
                        }else //caso seja 2
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Tamanho mínimo do campo não foi satisfeito";
                        }
                        
                        break;
                    case "CPF":
                        int verifica2 = auxfunc.verificacpf(valorEditado);

                        if (verifica2 == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else if (verifica2 == 1)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Este campo possui caracteres inválidos!";
                        }
                        else //caso seja 2
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "CPF deve possuir 11 digitos";
                        }
                        break;
                    case "Login":
                        

                        if (valorEditado.Length > 4)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Deve conter no mínimo 5 caracteres";
                        }
                        
                        break;

                    case "Senha":


                        if (valorEditado.Length > 4)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Deve conter no mínimo 5 caracteres";
                        }

                        break;
                    case "Genero":
                        
                        //remove da lista antes de add para o caso de já existir na lista
                        changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                        changedCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        break;
                    case "Cargo":

                        //remove da lista antes de add para o caso de já existir na lista
                        changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                        changedCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        break;
                    case "Data Nascimento":
                        int verificaData = auxfunc.VerificaDataNascimento(valorEditado);
                        if (verificaData == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }else
                        {
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Data Inválida Para nascimento!";
                        }

                        

                        break;
                    case "Salario":
                        int verifica3 = auxfunc.verificasalario(valorEditado);

                        if (verifica3 == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else if(verifica3 == 1)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Contém caracteres inválidos!";
                        }else
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Tamnho mínimo não satisfeito!";

                        }

                        break;
                    case "Telefone":
                        int verifica4 = auxfunc.verificatelefone(valorEditado);

                        if (verifica4 == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else if (verifica4 == 1)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Contém caracteres inválidos!";
                        }
                        else
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            funcionarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Telefone deve conter 10 digitos";

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

            Console.WriteLine("Erros: "+errorCells.Count);
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
            }else
            {
                if(changedCells.Count > 0)
                {

                    foreach(DataGridViewCell cell in changedCells)
                    {

                        //Coluna onde ouver alteração
                        string nomeColuna = cell.OwningColumn.DataPropertyName;

                        //Valor alterado
                        string novoValor = cell.Value.ToString();
                        //Id no banco da linha alterada para usar no update
                        string idLinha = funcionarioDataGridView["idDataGridViewTextBoxColumn", cell.RowIndex].Value.ToString();

                        string queryString = "UPDATE "+DataBase.tableFuncionario+" SET " + nomeColuna +" = @novoValor Where Id = @idLinha";
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
                    funcionarioDataGridView.Refresh();
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
            this.funcionarioTableAdapter.Fill(this.databaseHotelDataSet1.Funcionario);
            errorCells.Clear();
            changedCells.Clear();
            labelAlteracoes.Visible = false;
            labelErros.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(changedCells.Count() == 0)
            {
                DataGridViewCell selecionada = funcionarioDataGridView.SelectedCells[0];
                if (selecionada != null)
                {
                    string nomeLinha = funcionarioDataGridView["nameDataGridViewTextBoxColumn", selecionada.RowIndex].Value.ToString();
                    DialogResult result1 = MessageBox.Show("Tem certeza que deseja deletar " + nomeLinha + " ?", "Remoção irreversível!", MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.Yes)
                    {

                        //Id no banco da linha para excluir
                        string idLinha = funcionarioDataGridView["idDataGridViewTextBoxColumn", selecionada.RowIndex].Value.ToString();

                        string queryString = "DELETE FROM " + DataBase.tableFuncionario + " Where Id = @idLinha";
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
                        funcionarioDataGridView.Rows.Remove(selecionada.OwningRow);

                    }

                }
                else
                {
                    MessageBox.Show("Nenhuma Dado deletado", "Selecione pelo menos um campo para escluir a linha!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }else
            {
                MessageBox.Show( "Salve ou Descarte as alterações Pendentes antes de remover!", "Alterações Pendentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void Func_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                JanelaFuncMenu.Show();
            }
            catch (Exception exc)
            {

            }
        }

        private void funcionarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.funcionarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseHotelDataSet1);

        }
    }
}
