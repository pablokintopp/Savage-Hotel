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
        private string cellLastValue;

        public Func_List()
        {
            InitializeComponent();
        }

        public Func_List(Func_Menu func_Menu)
        {
            InitializeComponent();
            this.func_Menu = func_Menu;
            //CARREGA UM EVENTHANDLER NO LOAD
            this.Load += new EventHandler(Func_List_Load);
        }

        private void Func_List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseHotelDataSet1.Funcionario' table. You can move, or remove it, as needed.
            this.funcionarioTableAdapter.Fill(this.databaseHotelDataSet1.Funcionario);

            //Linkando um evento para lidar com mudanças nos campos da DataGridView
            this.dataGridView1.CellValidating += new
            DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
                      
        }

        private void dataGridView1_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
        {
            //nome da coluna
            string headerText =
                dataGridView1.Columns[e.ColumnIndex].HeaderText;

            string cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if(e.ColumnIndex > 0)
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;

            //TODO IMPEDIR A MUDANCA NO BANCO SEM A PERMIÇAO DESTE METÓDO
            //TODO DESATIVAR BINDING com o bancoAUTOMATICO
            //TODO Verficar nome/index da Coluna e validade de acordo e validar de acordo
            // MessageBox.Show("Validando "+headerText);
        }
        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        private void funcionarioBindingSource_CurrentChanged(object sender, EventArgs e)
        {
                    }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //SALVADO TEMPORARIAMENTO O VALOR DE CADA CELULA QUE ESTEJA EM FOCO
            //Para CASO a pessoa desista de editar a coluna            
            cellLastValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();            
        }
    }
}
