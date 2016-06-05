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
        private Quarto_Menu MenuQuarto;

        public Quarto_List()
        {
            InitializeComponent();
        }

        public Quarto_List(Quarto_Menu Menu)
        {
            InitializeComponent();
            this.MenuQuarto = Menu;
        }

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.quartoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void Reserva_Cadastro_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quarto._Quarto' table. You can move, or remove it, as needed.
            this.quartoTableAdapter.Fill(this.quarto._Quarto);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuQuarto.Show();
            this.Close();
        }
    }
}
