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
    public partial class Reserva_Menu : Form
    {
        private int NumeroQuarto = -1;
        private MenuMain Main;
        public Reserva_Menu()
        {
            InitializeComponent();
        }

        public Reserva_Menu(MenuMain MenuMain)
        {
            InitializeComponent();
            this.Main = MenuMain;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main.Show();
            this.Close();
        }
        public void DefinirNumeroQuarto(int newNumeroQuarto)
        {
            NumeroQuarto = newNumeroQuarto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Quartos = new Reserva_Quartos(this);
            //this.Hide();
            //Quartos.Show();
            Quartos.ShowDialog();
        }
        

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.quartoBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void Reserva_Menu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quarto._Quarto' table. You can move, or remove it, as needed.
            //this.quartoTableAdapter.Fill(this.quarto._Quarto);
            //idTextBox.Text = idquarto.ToString();
            
        }
        public void refresh() {
            if (NumeroQuarto > -1)
            {
                numeroQuartoTextBox.Text = NumeroQuarto.ToString();
                this.quartoTableAdapter.busca_DetalhesQuartoDeNumeroTal(this.quarto._Quarto, NumeroQuarto.ToString());
            }            
        }
    }
}
