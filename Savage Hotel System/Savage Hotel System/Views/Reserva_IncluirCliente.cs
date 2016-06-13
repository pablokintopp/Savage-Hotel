﻿using System;
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
    public partial class Reserva_IncluirCliente : Form
    {
        private Reserva_Cadastro CadastroReserva;
        int quantidadeItensNaGridView = 0;
        public Reserva_IncluirCliente()
        {
            InitializeComponent();
        }

        public Reserva_IncluirCliente(Reserva_Cadastro CadastroReserva)
        {
            InitializeComponent();
            this.CadastroReserva = CadastroReserva;
        }

        private void quartoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.quartoBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void Reserva_Cadastro_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetCliente.Cliente' table. You can move, or remove it, as needed.
            //this.clienteTableAdapter.Fill(this.dataSetCliente.Cliente);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CadastroReserva.Show();
            this.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            //Buscar pelo Número do Quarto
            if (radioButtonCPF.Checked == true)
            {
                this.clienteTableAdapter.Busca_CPF(this.dataSetCliente.Cliente, textBoxBusca.Text);

            }

            //Buscar pelo Número de Camas de Solteiro nos Quartos
            if (radioButtonQuantidadeCamaSolteiro.Checked == true)
            {
                //this.quartoTableAdapter.busca_QuantidadeCamaSolteiro(this.quarto._Quarto, textBoxBusca.Text, "disponivel");
            }

            //Buscar pelo Número de Camas de Casal nos Quartos
            if (radioButtonQuantidadeCamaCasal.Checked == true)
            {
                //this.quartoTableAdapter.busca_QuantidadeCamaCasal(this.quarto._Quarto, textBoxBusca.Text, "disponivel");
            }

            //Conta quantas linhas estão na GridView
            quantidadeItensNaGridView = clienteDataGridView.Rows.Count;
            label3.Text = "Quantidade de Intens Econtrados ";
            label3.Text += quantidadeItensNaGridView.ToString();

            mostrarInfos();

        }

        private void mostrarInfos() {
            if (quantidadeItensNaGridView > 0)
            {
                int linha = -1;
                //Numero da Linha Selecionada
                label1.Text = "Linha Selecionada ";
                label1.Text += clienteDataGridView.SelectedRows[0].Index.ToString();
                linha = (int)clienteDataGridView.SelectedRows[0].Index;

                //ID do Banco referente a linha selecionada
                /*label2.Text = "ID do Quarto Selecionado ";
                label2.Text += quartoDataGridView.SelectedCells[2].Value.ToString();*/

                //Numero do Quarto Selecionado
                label2.Text = "Numero do Quarto Selecionado ";
                label2.Text += clienteDataGridView.Rows[linha].Cells[2].Value.ToString();
            }
        }

        private void quartoDataGridView_Click(object sender, EventArgs e)
        {
            mostrarInfos();
        }

        private void Selecionarbutton_Click(object sender, EventArgs e)
        {
            int IDCliente = -1;
            if (quantidadeItensNaGridView > 0)
            {
                int linha = -1;
                //Numero da Linha Selecionada
                label1.Text = "Linha Selecionada ";
                label1.Text += clienteDataGridView.SelectedRows[0].Index.ToString();
                linha = (int)clienteDataGridView.SelectedRows[0].Index;

                //ID do Banco referente a linha selecionada
                /*label2.Text = "ID do Quarto Selecionado ";
                label2.Text += quartoDataGridView.SelectedCells[2].Value.ToString();*/

                //ID do Quarto Selecionado
                label2.Text = "Numero do Quarto Selecionado ";
                IDCliente = Convert.ToInt16(clienteDataGridView.Rows[linha].Cells[0].Value);
                label2.Text = IDCliente.ToString();

                CadastroReserva.DefinirIDCliente(IDCliente);
                CadastroReserva.refresh();
                CadastroReserva.Show();
                this.Close();
            }

            
        }

        private void quartoDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            mostrarInfos();
        }

        private void quartoDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            mostrarInfos();
        }
    }
}