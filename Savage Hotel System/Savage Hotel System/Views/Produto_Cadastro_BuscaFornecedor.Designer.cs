namespace Savage_Hotel_System.Views
{
    partial class Produto_Cadastro_BuscaFornecedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produto_Cadastro_BuscaFornecedor));
            this.textBoxBusca = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.radioButtonNome = new System.Windows.Forms.RadioButton();
            this.radioButtonCNPJ = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Selecionarbutton = new System.Windows.Forms.Button();
            this.fornecedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetFornecedor = new Savage_Hotel_System.DataSet.DataSetFornecedor();
            this.fornecedorDataGridView = new System.Windows.Forms.DataGridView();
            this.fornecedorTableAdapter = new Savage_Hotel_System.DataSet.DataSetFornecedorTableAdapters.FornecedorTableAdapter();
            this.tableAdapterManager = new Savage_Hotel_System.DataSet.DataSetFornecedorTableAdapters.TableAdapterManager();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFornecedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxBusca
            // 
            this.textBoxBusca.Location = new System.Drawing.Point(12, 59);
            this.textBoxBusca.Name = "textBoxBusca";
            this.textBoxBusca.Size = new System.Drawing.Size(100, 20);
            this.textBoxBusca.TabIndex = 2;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(118, 56);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 3;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // radioButtonNome
            // 
            this.radioButtonNome.AutoSize = true;
            this.radioButtonNome.Checked = true;
            this.radioButtonNome.Location = new System.Drawing.Point(12, 12);
            this.radioButtonNome.Name = "radioButtonNome";
            this.radioButtonNome.Size = new System.Drawing.Size(53, 17);
            this.radioButtonNome.TabIndex = 4;
            this.radioButtonNome.TabStop = true;
            this.radioButtonNome.Text = "Nome";
            this.radioButtonNome.UseVisualStyleBackColor = true;
            // 
            // radioButtonCNPJ
            // 
            this.radioButtonCNPJ.AutoSize = true;
            this.radioButtonCNPJ.Location = new System.Drawing.Point(12, 35);
            this.radioButtonCNPJ.Name = "radioButtonCNPJ";
            this.radioButtonCNPJ.Size = new System.Drawing.Size(52, 17);
            this.radioButtonCNPJ.TabIndex = 5;
            this.radioButtonCNPJ.TabStop = true;
            this.radioButtonCNPJ.Text = "CNPJ";
            this.radioButtonCNPJ.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Savage_Hotel_System.Properties.Resources.back;
            this.pictureBox1.Location = new System.Drawing.Point(660, 373);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Linha Selecionada ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Numero do Quarto Selecionado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Quantidade de Intens Econtrados";
            // 
            // Selecionarbutton
            // 
            this.Selecionarbutton.Location = new System.Drawing.Point(313, 390);
            this.Selecionarbutton.Name = "Selecionarbutton";
            this.Selecionarbutton.Size = new System.Drawing.Size(75, 23);
            this.Selecionarbutton.TabIndex = 11;
            this.Selecionarbutton.Text = "Selecionar";
            this.Selecionarbutton.UseVisualStyleBackColor = true;
            this.Selecionarbutton.Click += new System.EventHandler(this.Selecionarbutton_Click);
            // 
            // fornecedorBindingSource
            // 
            this.fornecedorBindingSource.DataMember = "Fornecedor";
            this.fornecedorBindingSource.DataSource = this.dataSetFornecedor;
            // 
            // dataSetFornecedor
            // 
            this.dataSetFornecedor.DataSetName = "DataSetFornecedor";
            this.dataSetFornecedor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fornecedorDataGridView
            // 
            this.fornecedorDataGridView.AllowUserToAddRows = false;
            this.fornecedorDataGridView.AllowUserToDeleteRows = false;
            this.fornecedorDataGridView.AllowUserToResizeColumns = false;
            this.fornecedorDataGridView.AllowUserToResizeRows = false;
            this.fornecedorDataGridView.AutoGenerateColumns = false;
            this.fornecedorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fornecedorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.fornecedorDataGridView.DataSource = this.fornecedorBindingSource;
            this.fornecedorDataGridView.Location = new System.Drawing.Point(12, 151);
            this.fornecedorDataGridView.MultiSelect = false;
            this.fornecedorDataGridView.Name = "fornecedorDataGridView";
            this.fornecedorDataGridView.ReadOnly = true;
            this.fornecedorDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fornecedorDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fornecedorDataGridView.Size = new System.Drawing.Size(680, 220);
            this.fornecedorDataGridView.TabIndex = 12;
            this.fornecedorDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fornecedorDataGridView_KeyDown);
            this.fornecedorDataGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fornecedorDataGridView_KeyUp);
            // 
            // fornecedorTableAdapter
            // 
            this.fornecedorTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.FornecedorTableAdapter = this.fornecedorTableAdapter;
            this.tableAdapterManager.UpdateOrder = Savage_Hotel_System.DataSet.DataSetFornecedorTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CNPJ";
            this.dataGridViewTextBoxColumn3.HeaderText = "CNPJ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Phone";
            this.dataGridViewTextBoxColumn4.HeaderText = "Phone";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Produto_Cadastro_BuscaFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 425);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fornecedorDataGridView);
            this.Controls.Add(this.Selecionarbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radioButtonCNPJ);
            this.Controls.Add(this.radioButtonNome);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.textBoxBusca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Produto_Cadastro_BuscaFornecedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Savage Hotel - Lista de Fornecedores";
            this.Load += new System.EventHandler(this.Reserva_Cadastro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFornecedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxBusca;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.RadioButton radioButtonNome;
        private System.Windows.Forms.RadioButton radioButtonCNPJ;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Selecionarbutton;
        private DataSet.DataSetFornecedor dataSetFornecedor;
        private System.Windows.Forms.BindingSource fornecedorBindingSource;
        private DataSet.DataSetFornecedorTableAdapters.FornecedorTableAdapter fornecedorTableAdapter;
        private DataSet.DataSetFornecedorTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView fornecedorDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}