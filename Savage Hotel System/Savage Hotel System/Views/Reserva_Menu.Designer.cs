namespace Savage_Hotel_System.Views
{
    partial class Reserva_Menu
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label descricaoLabel;
            System.Windows.Forms.Label numeroQuartoLabel;
            System.Windows.Forms.Label quantidadeCamaSolteiroLabel;
            System.Windows.Forms.Label quantidadeCamaCasalLabel;
            System.Windows.Forms.Label statusLabel;
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.quartoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quarto = new Savage_Hotel_System.DataSet.Quarto();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.numeroQuartoTextBox = new System.Windows.Forms.TextBox();
            this.quantidadeCamaSolteiroTextBox = new System.Windows.Forms.TextBox();
            this.quantidadeCamaCasalTextBox = new System.Windows.Forms.TextBox();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.quartoTableAdapter = new Savage_Hotel_System.DataSet.QuartoTableAdapters.QuartoTableAdapter();
            this.tableAdapterManager = new Savage_Hotel_System.DataSet.QuartoTableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            descricaoLabel = new System.Windows.Forms.Label();
            numeroQuartoLabel = new System.Windows.Forms.Label();
            quantidadeCamaSolteiroLabel = new System.Windows.Forms.Label();
            quantidadeCamaCasalLabel = new System.Windows.Forms.Label();
            statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quartoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quarto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(12, 41);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(19, 13);
            idLabel.TabIndex = 3;
            idLabel.Text = "Id:";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Location = new System.Drawing.Point(12, 67);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(58, 13);
            descricaoLabel.TabIndex = 5;
            descricaoLabel.Text = "Descricao:";
            descricaoLabel.Visible = false;
            // 
            // numeroQuartoLabel
            // 
            numeroQuartoLabel.AutoSize = true;
            numeroQuartoLabel.Location = new System.Drawing.Point(12, 93);
            numeroQuartoLabel.Name = "numeroQuartoLabel";
            numeroQuartoLabel.Size = new System.Drawing.Size(82, 13);
            numeroQuartoLabel.TabIndex = 7;
            numeroQuartoLabel.Text = "Numero Quarto:";
            // 
            // quantidadeCamaSolteiroLabel
            // 
            quantidadeCamaSolteiroLabel.AutoSize = true;
            quantidadeCamaSolteiroLabel.Location = new System.Drawing.Point(12, 119);
            quantidadeCamaSolteiroLabel.Name = "quantidadeCamaSolteiroLabel";
            quantidadeCamaSolteiroLabel.Size = new System.Drawing.Size(133, 13);
            quantidadeCamaSolteiroLabel.TabIndex = 9;
            quantidadeCamaSolteiroLabel.Text = "Quantidade Cama Solteiro:";
            // 
            // quantidadeCamaCasalLabel
            // 
            quantidadeCamaCasalLabel.AutoSize = true;
            quantidadeCamaCasalLabel.Location = new System.Drawing.Point(12, 145);
            quantidadeCamaCasalLabel.Name = "quantidadeCamaCasalLabel";
            quantidadeCamaCasalLabel.Size = new System.Drawing.Size(124, 13);
            quantidadeCamaCasalLabel.TabIndex = 11;
            quantidadeCamaCasalLabel.Text = "Quantidade Cama Casal:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new System.Drawing.Point(12, 171);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(40, 13);
            statusLabel.TabIndex = 13;
            statusLabel.Text = "Status:";
            statusLabel.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Incluir Quarto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Savage_Hotel_System.Properties.Resources.back;
            this.pictureBox1.Location = new System.Drawing.Point(604, 218);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quartoBindingSource, "Id", true));
            this.idTextBox.Enabled = false;
            this.idTextBox.Location = new System.Drawing.Point(151, 38);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 4;
            // 
            // quartoBindingSource
            // 
            this.quartoBindingSource.DataMember = "Quarto";
            this.quartoBindingSource.DataSource = this.quarto;
            // 
            // quarto
            // 
            this.quarto.DataSetName = "Quarto";
            this.quarto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quartoBindingSource, "Descricao", true));
            this.descricaoTextBox.Enabled = false;
            this.descricaoTextBox.Location = new System.Drawing.Point(151, 64);
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(100, 20);
            this.descricaoTextBox.TabIndex = 6;
            // 
            // numeroQuartoTextBox
            // 
            this.numeroQuartoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quartoBindingSource, "NumeroQuarto", true));
            this.numeroQuartoTextBox.Enabled = false;
            this.numeroQuartoTextBox.Location = new System.Drawing.Point(151, 90);
            this.numeroQuartoTextBox.Name = "numeroQuartoTextBox";
            this.numeroQuartoTextBox.Size = new System.Drawing.Size(100, 20);
            this.numeroQuartoTextBox.TabIndex = 8;
            // 
            // quantidadeCamaSolteiroTextBox
            // 
            this.quantidadeCamaSolteiroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quartoBindingSource, "QuantidadeCamaSolteiro", true));
            this.quantidadeCamaSolteiroTextBox.Enabled = false;
            this.quantidadeCamaSolteiroTextBox.Location = new System.Drawing.Point(151, 116);
            this.quantidadeCamaSolteiroTextBox.Name = "quantidadeCamaSolteiroTextBox";
            this.quantidadeCamaSolteiroTextBox.Size = new System.Drawing.Size(100, 20);
            this.quantidadeCamaSolteiroTextBox.TabIndex = 10;
            // 
            // quantidadeCamaCasalTextBox
            // 
            this.quantidadeCamaCasalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quartoBindingSource, "QuantidadeCamaCasal", true));
            this.quantidadeCamaCasalTextBox.Enabled = false;
            this.quantidadeCamaCasalTextBox.Location = new System.Drawing.Point(151, 142);
            this.quantidadeCamaCasalTextBox.Name = "quantidadeCamaCasalTextBox";
            this.quantidadeCamaCasalTextBox.Size = new System.Drawing.Size(100, 20);
            this.quantidadeCamaCasalTextBox.TabIndex = 12;
            // 
            // statusTextBox
            // 
            this.statusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.quartoBindingSource, "Status", true));
            this.statusTextBox.Enabled = false;
            this.statusTextBox.Location = new System.Drawing.Point(151, 168);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(100, 20);
            this.statusTextBox.TabIndex = 14;
            this.statusTextBox.Visible = false;
            // 
            // quartoTableAdapter
            // 
            this.quartoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.QuartoTableAdapter = this.quartoTableAdapter;
            this.tableAdapterManager.UpdateOrder = Savage_Hotel_System.DataSet.QuartoTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(idLabel);
            this.panel1.Controls.Add(this.statusTextBox);
            this.panel1.Controls.Add(this.idTextBox);
            this.panel1.Controls.Add(statusLabel);
            this.panel1.Controls.Add(descricaoLabel);
            this.panel1.Controls.Add(this.quantidadeCamaCasalTextBox);
            this.panel1.Controls.Add(this.descricaoTextBox);
            this.panel1.Controls.Add(quantidadeCamaCasalLabel);
            this.panel1.Controls.Add(numeroQuartoLabel);
            this.panel1.Controls.Add(this.quantidadeCamaSolteiroTextBox);
            this.panel1.Controls.Add(this.numeroQuartoTextBox);
            this.panel1.Controls.Add(quantidadeCamaSolteiroLabel);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 197);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Detalhes do Quarto";
            // 
            // Reserva_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 425);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "Reserva_Menu";
            this.Text = "Reserva_Menu";
            this.Load += new System.EventHandler(this.Reserva_Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quartoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quarto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DataSet.Quarto quarto;
        private System.Windows.Forms.BindingSource quartoBindingSource;
        private DataSet.QuartoTableAdapters.QuartoTableAdapter quartoTableAdapter;
        private DataSet.QuartoTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.TextBox numeroQuartoTextBox;
        private System.Windows.Forms.TextBox quantidadeCamaSolteiroTextBox;
        private System.Windows.Forms.TextBox quantidadeCamaCasalTextBox;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}