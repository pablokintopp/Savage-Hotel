using Savage_Hotel_System.Class;
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
        private Func_Menu func_Menu;
        private string valorQuandoEntrou;
        private List<DataGridViewCell> errorCells;
        private List<DataGridViewCell> changedCells;
        public Func_List()
        {
            InitializeComponent();
        }

        public Func_List(Func_Menu func_Menu)
        {
            InitializeComponent();
            this.func_Menu = func_Menu;
            //CARREGA UM EVENTHANDLER NO LOAD
            //this.Load += new EventHandler(Func_List_Load);
        }

        private void Func_List_Load(object sender, EventArgs e)
        {
            errorCells = new List<DataGridViewCell>();
            changedCells = new List<DataGridViewCell>();
            labelErros.Visible = false;
            labelAlteracoes.Visible = false;
            // TODO: This line of code loads data into the 'databaseHotelDataSet1.Funcionario' table. You can move, or remove it, as needed.
            this.funcionarioTableAdapter.Fill(this.databaseHotelDataSet1.Funcionario);

            //Desabilitando o update automatico do banco pois queremos validar antes.
            this.dataGridView1.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
        }

        private void funcionarioBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            //Para CASO a pessoa desista de editar a coluna            
            valorQuandoEntrou = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            Console.WriteLine("Entrou: "+ valorQuandoEntrou);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            func_Menu.Show();
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

                        }else if(verifica == 1){
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);                          
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Este campo possui caracteres inválidos!";
                        }else //caso seja 2
                        {
                            //evita dois erros cadastrados para um mesmo item
                            errorCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            errorCells.Add(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);

                            //evita o item estar como erro e sucesso ao mesmo tempo
                            changedCells.Remove(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Tamanho mínimo do campo não foi satisfeito";
                        }
                        
                        break;
                    case "CPF":
                        //MessageBox.Show("CPF Editado");
                        break;

                }

            }            

            if (errorCells.Count > 0)
                labelErros.Visible = true;

            if (changedCells.Count > 0)
                labelAlteracoes.Visible = true;

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
                    //dataGridView1.DataBindings[0].WriteValue();
                    //DataBindings[dataGridView1.Name].WriteValue();
                    //TODO salvar alterações na databinding
                    MessageBox.Show("Todas alterações foram salvas!", "Alterações realizadas co Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nenhuma Alteração foi feita", "Nenhuma Alteração Executada!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            
        }
    }
}
