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
            Console.WriteLine("Editou: "+ valorEditado);
            //verifica o valor atual com o de quando entrou na celula para ver se foi alterado algo
            //caso sim entra na verificacao
            if (String.Equals(valorEditado, valorQuandoEntrou))
            {
                //Pegando o nome da coluna onde houve alteração
                string colTitulo = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                Funcoes auxfunc = new Funcoes();


                switch (colTitulo)
                {
                    case "Nome":
                        int verifica = auxfunc.verificanome(valorEditado);
                        if (verifica != 0)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(100, 200, 10, 10);

                        }
                        break;
                    case "CPF":
                        //MessageBox.Show("CPF Editado");
                        break;

                }

            }

                
            
        }
            
    }
}
