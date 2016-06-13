namespace Savage_Hotel_System.Views
{
    partial class Reserva_IncluirCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reserva_IncluirCliente));
            this.textBoxBusca = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.radioButtonCPF = new System.Windows.Forms.RadioButton();
            this.radioButtonQuantidadeCamaSolteiro = new System.Windows.Forms.RadioButton();
            this.radioButtonQuantidadeCamaCasal = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Selecionarbutton = new System.Windows.Forms.Button();
            this.clienteDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetCliente = new Savage_Hotel_System.DataSet.DataSetCliente();
            this.clienteTableAdapter = new Savage_Hotel_System.DataSet.DataSetClienteTableAdapters.ClienteTableAdapter();
            this.tableAdapterManager = new Savage_Hotel_System.DataSet.DataSetClienteTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxBusca
            // 
            this.textBoxBusca.Location = new System.Drawing.Point(12, 104);
            this.textBoxBusca.Name = "textBoxBusca";
            this.textBoxBusca.Size = new System.Drawing.Size(100, 20);
            this.textBoxBusca.TabIndex = 2;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(118, 101);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 3;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // radioButtonCPF
            // 
            this.radioButtonCPF.AutoSize = true;
            this.radioButtonCPF.Location = new System.Drawing.Point(12, 12);
            this.radioButtonCPF.Name = "radioButtonCPF";
            this.radioButtonCPF.Size = new System.Drawing.Size(45, 17);
            this.radioButtonCPF.TabIndex = 4;
            this.radioButtonCPF.TabStop = true;
            this.radioButtonCPF.Text = "CPF";
            this.radioButtonCPF.UseVisualStyleBackColor = true;
            // 
            // radioButtonQuantidadeCamaSolteiro
            // 
            this.radioButtonQuantidadeCamaSolteiro.AutoSize = true;
            this.radioButtonQuantidadeCamaSolteiro.Location = new System.Drawing.Point(12, 35);
            this.radioButtonQuantidadeCamaSolteiro.Name = "radioButtonQuantidadeCamaSolteiro";
            this.radioButtonQuantidadeCamaSolteiro.Size = new System.Drawing.Size(148, 17);
            this.radioButtonQuantidadeCamaSolteiro.TabIndex = 5;
            this.radioButtonQuantidadeCamaSolteiro.TabStop = true;
            this.radioButtonQuantidadeCamaSolteiro.Text = "Quantidade Cama Solteiro";
            this.radioButtonQuantidadeCamaSolteiro.UseVisualStyleBackColor = true;
            // 
            // radioButtonQuantidadeCamaCasal
            // 
            this.radioButtonQuantidadeCamaCasal.AutoSize = true;
            this.radioButtonQuantidadeCamaCasal.Location = new System.Drawing.Point(13, 59);
            this.radioButtonQuantidadeCamaCasal.Name = "radioButtonQuantidadeCamaCasal";
            this.radioButtonQuantidadeCamaCasal.Size = new System.Drawing.Size(139, 17);
            this.radioButtonQuantidadeCamaCasal.TabIndex = 6;
            this.radioButtonQuantidadeCamaCasal.TabStop = true;
            this.radioButtonQuantidadeCamaCasal.Text = "Quantidade Cama Casal";
            this.radioButtonQuantidadeCamaCasal.UseVisualStyleBackColor = true;
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
            this.Selecionarbutton.Location = new System.Drawing.Point(313, 382);
            this.Selecionarbutton.Name = "Selecionarbutton";
            this.Selecionarbutton.Size = new System.Drawing.Size(75, 23);
            this.Selecionarbutton.TabIndex = 11;
            this.Selecionarbutton.Text = "Selecionar";
            this.Selecionarbutton.UseVisualStyleBackColor = true;
            this.Selecionarbutton.Click += new System.EventHandler(this.Selecionarbutton_Click);
            // 
            // clienteDataGridView
            // 
            this.clienteDataGridView.AllowUserToAddRows = false;
            this.clienteDataGridView.AllowUserToDeleteRows = false;
            this.clienteDataGridView.AllowUserToResizeColumns = false;
            this.clienteDataGridView.AllowUserToResizeRows = false;
            this.clienteDataGridView.AutoGenerateColumns = false;
            this.clienteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clienteDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn,
            this.cPFDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.birthdayDataGridViewTextBoxColumn});
            this.clienteDataGridView.DataSource = this.clienteBindingSource;
            this.clienteDataGridView.Location = new System.Drawing.Point(12, 151);
            this.clienteDataGridView.MultiSelect = false;
            this.clienteDataGridView.Name = "clienteDataGridView";
            this.clienteDataGridView.ReadOnly = true;
            this.clienteDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clienteDataGridView.Size = new System.Drawing.Size(680, 220);
            this.clienteDataGridView.TabIndex = 12;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "Gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "Gender";
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            this.genderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cPFDataGridViewTextBoxColumn
            // 
            this.cPFDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cPFDataGridViewTextBoxColumn.DataPropertyName = "CPF";
            this.cPFDataGridViewTextBoxColumn.HeaderText = "CPF";
            this.cPFDataGridViewTextBoxColumn.Name = "cPFDataGridViewTextBoxColumn";
            this.cPFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // birthdayDataGridViewTextBoxColumn
            // 
            this.birthdayDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.birthdayDataGridViewTextBoxColumn.DataPropertyName = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.Name = "birthdayDataGridViewTextBoxColumn";
            this.birthdayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataMember = "Cliente";
            this.clienteBindingSource.DataSource = this.dataSetCliente;
            // 
            // dataSetCliente
            // 
            this.dataSetCliente.DataSetName = "DataSetCliente";
            this.dataSetCliente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clienteTableAdapter
            // 
            this.clienteTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClienteTableAdapter = this.clienteTableAdapter;
            this.tableAdapterManager.UpdateOrder = Savage_Hotel_System.DataSet.DataSetClienteTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Reserva_IncluirCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 425);
            this.Controls.Add(this.clienteDataGridView);
            this.Controls.Add(this.Selecionarbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radioButtonQuantidadeCamaCasal);
            this.Controls.Add(this.radioButtonQuantidadeCamaSolteiro);
            this.Controls.Add(this.radioButtonCPF);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.textBoxBusca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reserva_IncluirCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Savage Hotel - Busca de Quartos";
            this.Load += new System.EventHandler(this.Reserva_Cadastro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxBusca;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.RadioButton radioButtonCPF;
        private System.Windows.Forms.RadioButton radioButtonQuantidadeCamaSolteiro;
        private System.Windows.Forms.RadioButton radioButtonQuantidadeCamaCasal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Selecionarbutton;
        private System.Windows.Forms.DataGridView clienteDataGridView;
        private DataSet.DataSetCliente dataSetCliente;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private DataSet.DataSetClienteTableAdapters.ClienteTableAdapter clienteTableAdapter;
        private DataSet.DataSetClienteTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdayDataGridViewTextBoxColumn;
    }
}