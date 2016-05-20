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

        public Func_List()
        {
            InitializeComponent();
        }

        public Func_List(Func_Menu func_Menu)
        {
            InitializeComponent();
            this.func_Menu = func_Menu;
        }

        private void Func_List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseHotelDataSet1.Funcionario' table. You can move, or remove it, as needed.
            this.funcionarioTableAdapter.Fill(this.databaseHotelDataSet1.Funcionario);


        }

        private void funcionarioBindingSource_CurrentChanged(object sender, EventArgs e)
        {
                    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
