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
    public partial class Produto_List : Form
    {
        private Produto_Menu MenuProduto;

        public Produto_List()
        {
            InitializeComponent();
        }

        public Produto_List(Produto_Menu Menu)
        {
            InitializeComponent();
            this.MenuProduto = Menu;
        }

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.quartoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void Reserva_Cadastro_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetProduto.Produto' table. You can move, or remove it, as needed.
            //this.produtoTableAdapter.Fill(this.dataSetProduto.Produto);
            this.produtoTableAdapter.Busca_Listar(this.dataSetProduto.Produto);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MenuProduto.Show();
            this.Close();
        }
    }
}
