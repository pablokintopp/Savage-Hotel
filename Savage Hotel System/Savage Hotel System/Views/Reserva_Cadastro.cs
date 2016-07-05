using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Savage_Hotel_System.Data;
using Savage_Hotel_System.Class;
using System.Data.SqlClient;

namespace Savage_Hotel_System.Views
{
    public partial class Reserva_Cadastro : Form
    {
        private int IDQuarto = -1;
        private int IDCliente = -1;
        private int disponibilidade = -1;
        private double valorReserva = 0;  
        private Reserva_Menu JanelaMenuReserva;
        public Reserva_Cadastro()
        {
            InitializeComponent();
        }

        public Reserva_Cadastro(Reserva_Menu Janela)
        {
            InitializeComponent();
            this.JanelaMenuReserva = Janela;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            JanelaMenuReserva.Show();
            this.Close();
        }
        public void DefinirIDQuarto(int newIDQuarto)
        {
            IDQuarto = newIDQuarto;
        }

        public void DefinirIDCliente(int newIDCliente)
        {
            IDCliente = newIDCliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Quartos = new Reserva_IncluirQuarto(this);
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
            // TODO: This line of code loads data into the 'dataSetCliente.Cliente' table. You can move, or remove it, as needed.
            //this.clienteTableAdapter.Fill(this.dataSetCliente.Cliente);
            // TODO: This line of code loads data into the 'quarto._Quarto' table. You can move, or remove it, as needed.
            //this.quartoTableAdapter.Fill(this.quarto._Quarto);

            //idTextBox.Text = idquarto.ToString();
            label5.Text = "";
            labelValorTotal.Visible = false;
            panelIncluirQuartos.Hide();
        }
        public void refresh() {
            if (IDCliente > -1)
            {
                this.clienteTableAdapter.Busca_ID(this.dataSetCliente.Cliente, IDCliente);
                panelIncluirQuartos.Show();
            }
            if (IDQuarto > -1)
            {
                //numeroQuartoTextBox.Text = ID.ToString();
                this.quartoTableAdapter.Busca_ID(this.quarto._Quarto, IDQuarto);
            }
        }

        private void quartoBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.quartoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.quarto);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Cliente = new Reserva_IncluirCliente(this);
            Cliente.ShowDialog();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            int somarerros = 0;
            if (IDCliente > -1)
            {
                if (IDQuarto > -1)
                {
                    //Se já tiver Clicado em Verificar Disponibilidade
                    if (disponibilidade != 0) {
                        label5.Text = "Verifique a Disponibilidade do Quarto"; 
                    }
                    somarerros += disponibilidade;


                    if (somarerros == 0)
                    {
                        if (InserirBanco() > 0)
                        {
                            MessageBox.Show("Inserido com Sucesso!");
                            this.Close();
                            this.JanelaMenuReserva.Show();
                        }
                        else
                        {
                            MessageBox.Show("Houve alguma falha na insercao!");
                        }
                    }
                }
                else {
                    label5.Text = "Adicione um Quarto a Reserva";
                }
            }
            else {
                label5.Text = "Adicione um Cliente a Reserva";
            }
        }

        //Metodo que chama a insercao do banco passando como parametros o nome da tabela a ser inserido, os nomes das colunas e respectivos valores
        private int InserirBanco()
        {
            //Console.WriteLine("DATA: " + dateTimeNascimento.Value.ToString("dd/MM/yyyy"));
            //pega os valores das entradas para serem inseridos 
            List<object> parametrosValores = new List<object>()
            {
                valorReserva,
                dateTimeEntrada.Text,
                dateTimePickerSaida.Text,
                IDCliente,
                IDQuarto

            };

            //Estes parametros devem ter o mesmo NOME das colunas da Tabela
            //E devem seguir a mesma ordem de insercao na lista dos valores acima
            List<string> parametrosNomes = new List<string>()
            {
                "Valor",
                "InicioReserva",
                "FimReserva",
                "IdCLiente",
                "IdQuarto"
            };
            string nomeDaTabela = DataBase.tableReserva;
            return DataBase.SqlCommandInsert(nomeDaTabela, parametrosNomes, parametrosValores);

        }

        //metodo retorna o valor da reserva usando o valor da diaria do quarto e o numero de dias
        public double valorTotalReserva()
        {
            double dias = (dateTimePickerSaida.Value - dateTimeEntrada.Value).TotalDays;
            double valorDiaria = Double.Parse( quartoDataGridView.Rows[0].Cells["ValorDiaria"].Value.ToString());
           
           

            return dias * valorDiaria;

        }

        //Metodo para consultar banco se o quarto estara disponivel durante a data escolhida
        //retorno -1 = quarto nao selecionado
        // retorno 1  = não disponivel entre as datas de entrada e saida
        // retorno  0 = disponivel
        private int verificarDisponibilidadeQuarto()
        {
            string dataEntrada = dateTimeEntrada.Text;
            string dataSaida = dateTimePickerSaida.Text;

            //Consulta vai ser algo como:
            //Select distinct Reserva.id as Reserva from dbo.Reserva , dbo.Quarto where Reserva.IdQuarto = Quarto.id and Quarto.id = 1 and ( (Reserva.InicioReserva >= '18/06/2016' and Reserva.InicioReserva <= '20/06/2016') or (Reserva.FImReserva >= '18/06/2016' and Reserva.FImReserva <= '20/06/2016'));

            string queryString = "Select distinct Reserva.id as Reserva from dbo.Reserva , dbo.Quarto where Reserva.IdQuarto = Quarto.id and Quarto.id = "+IDQuarto+" and ( (Reserva.InicioReserva >= '"+dataEntrada+ "' and Reserva.InicioReserva <= '" + dataSaida + "') or (Reserva.FImReserva >= '" + dataEntrada + "' and Reserva.FImReserva <= '" + dataSaida + "'))";
            Console.WriteLine(queryString);
            SqlDataReader dr = DataBase.SqlCommand(queryString, null, null);

            //se a consulta retorna linhas significa que o quarto nao esta disponivel.
            if (dr.HasRows)
            {
                dr.Close();
                return 1;
            }

            else
            {
                dr.Close();
                return 0;
            }                
        }

        private void buttonVerificar_Click(object sender, EventArgs e)
        {
            labelValorTotal.Visible = false;
            if (IDCliente > -1)
            {
                if (IDQuarto > -1)
                {
                    Funcoes auxfunc = new Funcoes();
                    String DataEntrada = dateTimeEntrada.Text;
                    String DataSaida = dateTimePickerSaida.Text;
                    int retorno = 0;

                    //Verifica Datas de Reserva
                    retorno = auxfunc.VerificaDataReserva(DataEntrada, DataSaida);
                    switch (retorno)
                    {
                        case 0:
                            dateTimeEntrada.BackColor = Color.LightGreen;
                            label5.Text = "";
                            break;
                        case 1:
                            dateTimeEntrada.BackColor = Color.IndianRed;
                            label5.Text = "Data do mesmo dia não é Permitido";
                            break;
                        case 2:
                            dateTimeEntrada.BackColor = Color.IndianRed;
                            label5.Text = "Datas passadas São Inválidas";
                            break;
                    }
                    if (retorno == 0)
                    {
                        IDQuarto = IDQuarto == -1 ? 1 : IDQuarto; // teste
                        int disp = verificarDisponibilidadeQuarto();
                        label5.Text = disp == 0 ? "Disponivel" : "Não disponivel";
                        disponibilidade = disp;
                        //atualiza valor total
                        if(disp == 0)
                        {
                            valorReserva = valorTotalReserva();
                            labelValorTotal.Text = "Valor Da Reserva: "+ valorReserva.ToString();
                            labelValorTotal.Visible = true;
                        }
                    }
                }
                else
                {
                    label5.Text = "Adicione um Quarto a Reserva";
                }
            }
            else
            {
                label5.Text = "Adicione um Cliente a Reserva";
            }
        }

        private void Reserva_Cadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                JanelaMenuReserva.Show();
            }
            catch (Exception)
            {

            }
        }
    }
}
