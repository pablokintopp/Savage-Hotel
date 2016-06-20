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
        private Reserva_Menu MenuReserva;
        private int idSelected;

        public Reserva_List()
        {
            InitializeComponent();
        }

        public Reserva_List(Reserva_Menu Menu)
        {
            InitializeComponent();
            this.MenuReserva = Menu;
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

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuReserva.Show();
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
    }
}
