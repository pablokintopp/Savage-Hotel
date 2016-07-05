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
    public partial class Reserva_List : Form
    {
        private Reserva_Menu JanelaReservaMenu;
        private int idSelected;
        private string valorQuandoEntrou;
        private List<DataGridViewCell> errorCells;
        private List<DataGridViewCell> changedCells;

        public Reserva_List()
        {
            InitializeComponent();
        }

        public Reserva_List(Reserva_Menu Janela)
        {
            InitializeComponent();
            this.JanelaReservaMenu = Janela;
        }

        public Reserva_List(Reserva_Menu Menu, int idSelected) : this(Menu)
        {
            this.idSelected = idSelected;
        }

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

        }

        private void Reserva_Cadastro_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetReserva.Reserva' table. You can move, or remove it, as needed.
            //this.reservaTableAdapter.Fill(this.dataSetReserva.Reserva);
            this.reservaTableAdapter.Busca_Listar(this.dataSetReserva.Reserva);

            errorCells = new List<DataGridViewCell>();
            changedCells = new List<DataGridViewCell>();
            labelErros.Visible = false;
            labelAlteracoes.Visible = false;

            if (idSelected > 0)
            {
                reservaDataGridView[0, 0].Selected = false;
                foreach (DataGridViewRow row in reservaDataGridView.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == idSelected)
                    {
                        reservaDataGridView[0, row.Index].Selected = true;
                        reservaDataGridView.Rows[row.Index].Selected = true;

                        break;
                    }
                }
            }

            reservaDataGridView.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            JanelaReservaMenu.Show();
            this.Close();
        }

        private void reservaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.reservaBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dataSetReserva);

        }

        private void reservaBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.reservaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetReserva);

        }

        private void reservaBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.reservaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetReserva);

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            //Para CASO a pessoa desista de editar a coluna            
            valorQuandoEntrou = reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Console.WriteLine("Entrou: " + valorQuandoEntrou);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace(',', '.');
            //valor atual do campo
            string valorEditado = reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            // Console.WriteLine("Editou: "+ valorEditado);

            //Cores para quando houver erros ou alterações
            Color errorColor = Color.Red;
            Color successColor = Color.ForestGreen;

            //verifica o valor atual com o de quando entrou na celula para ver se foi alterado algo
            //caso sim entra na verificacao
            if (valorEditado != valorQuandoEntrou)
            {
                //Pegando o nome da coluna onde houve alteração
                string colTitulo = reservaDataGridView.Columns[e.ColumnIndex].HeaderText;
                Funcoes auxfunc = new Funcoes();             

                //validando conforme  a coluna
                switch (colTitulo.Trim())
                {
                    case "Valor":
                        int verifica3 = auxfunc.verificavalor(valorEditado);
                        

                        if (verifica3 == 0)
                        {
                            //remove da lista antes de add para o caso de já existir na lista
                            changedCells.Remove(reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            changedCells.Add(reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //Remove da lista de erros caso o item estiver lá
                            errorCells.Remove(reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                        }
                        else if (verifica3 == 1)
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Contém caracteres inválidos!";
                        }
                        else
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            reservaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Somente aceita Formato aceito 00,00";

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

        private void reservaDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine("DATA ERROR: ");
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
                        string idLinha = reservaDataGridView["dataGridViewTextBoxColumn1", cell.RowIndex].Value.ToString();

                        string queryString = "UPDATE " + DataBase.tableReserva + " SET " + nomeColuna + " = @novoValor Where Id = @idLinha";
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
                    reservaDataGridView.Refresh();
                    changedCells.Clear();
                }
                else
                {
                    MessageBox.Show("Nenhuma Alteração foi feita", "Nenhuma Alteração Executada!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (changedCells.Count() == 0)
            {
                DataGridViewCell selecionada = reservaDataGridView.SelectedCells[0];
                if (selecionada != null)
                {
                    string nomeLinha = reservaDataGridView["dataGridViewTextBoxColumn1", selecionada.RowIndex].Value.ToString();
                    DialogResult result1 = MessageBox.Show("Tem certeza que deseja cancelar a Reserva de ID: " + nomeLinha + " ?", "Remoção irreversível!", MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.Yes)
                    {

                        //Id no banco da linha para excluir
                        string idLinha = reservaDataGridView["dataGridViewTextBoxColumn1", selecionada.RowIndex].Value.ToString();

                        string queryString = "DELETE FROM " + DataBase.tableReserva + " Where Id = @idLinha";
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
                        reservaDataGridView.Rows.Remove(selecionada.OwningRow);

                    }

                }
                else
                {
                    MessageBox.Show("Nenhuma Dado deletado", "Selecione pelo menos um campo para escluir a linha!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }else
            {

                MessageBox.Show("Confirme ou descarte as Alterações pendentes antes De cancelar uma Reserva!", "Alterações Pendentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Reserva_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                JanelaReservaMenu.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
