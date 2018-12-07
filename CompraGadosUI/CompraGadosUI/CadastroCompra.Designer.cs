namespace CompraGadosUI
{
    partial class CadastroCompra
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblDataEntrega = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDataEntrega = new System.Windows.Forms.MaskedTextBox();
            this.cmbPecuarista = new System.Windows.Forms.ComboBox();
            this.gbAnimais = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.gbAnimais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(80, 15);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id";
            // 
            // lblDataEntrega
            // 
            this.lblDataEntrega.AutoSize = true;
            this.lblDataEntrega.Location = new System.Drawing.Point(12, 41);
            this.lblDataEntrega.Name = "lblDataEntrega";
            this.lblDataEntrega.Size = new System.Drawing.Size(84, 13);
            this.lblDataEntrega.TabIndex = 1;
            this.lblDataEntrega.Text = "Data de entrega";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pecuarista";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(102, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 3;
            // 
            // txtDataEntrega
            // 
            this.txtDataEntrega.Location = new System.Drawing.Point(102, 38);
            this.txtDataEntrega.Mask = "00/00/0000";
            this.txtDataEntrega.Name = "txtDataEntrega";
            this.txtDataEntrega.Size = new System.Drawing.Size(100, 20);
            this.txtDataEntrega.TabIndex = 4;
            this.txtDataEntrega.ValidatingType = typeof(System.DateTime);
            // 
            // cmbPecuarista
            // 
            this.cmbPecuarista.FormattingEnabled = true;
            this.cmbPecuarista.Location = new System.Drawing.Point(271, 38);
            this.cmbPecuarista.Name = "cmbPecuarista";
            this.cmbPecuarista.Size = new System.Drawing.Size(121, 21);
            this.cmbPecuarista.TabIndex = 5;
            // 
            // gbAnimais
            // 
            this.gbAnimais.Controls.Add(this.btnAlterar);
            this.gbAnimais.Controls.Add(this.btnExcluir);
            this.gbAnimais.Controls.Add(this.btnAdicionar);
            this.gbAnimais.Controls.Add(this.lblValorTotal);
            this.gbAnimais.Controls.Add(this.lblTotal);
            this.gbAnimais.Controls.Add(this.dataGridView1);
            this.gbAnimais.Location = new System.Drawing.Point(15, 64);
            this.gbAnimais.Name = "gbAnimais";
            this.gbAnimais.Size = new System.Drawing.Size(377, 232);
            this.gbAnimais.TabIndex = 6;
            this.gbAnimais.TabStop = false;
            this.gbAnimais.Text = "Animais";
            this.gbAnimais.Enter += new System.EventHandler(this.gbAnimais_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(365, 141);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(173, 206);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total:";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(213, 206);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(75, 13);
            this.lblValorTotal.TabIndex = 2;
            this.lblValorTotal.Text = "valorTotalAqui";
            this.lblValorTotal.Visible = false;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(6, 19);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(87, 19);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(168, 19);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 5;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            // 
            // CadastroCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 320);
            this.Controls.Add(this.gbAnimais);
            this.Controls.Add(this.cmbPecuarista);
            this.Controls.Add(this.txtDataEntrega);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDataEntrega);
            this.Controls.Add(this.lblId);
            this.Name = "CadastroCompra";
            this.Text = "Cadastro de compra de gado";
            this.Deactivate += new System.EventHandler(this.CadastroCompra_Deactivate);
            this.gbAnimais.ResumeLayout(false);
            this.gbAnimais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDataEntrega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.MaskedTextBox txtDataEntrega;
        private System.Windows.Forms.ComboBox cmbPecuarista;
        private System.Windows.Forms.GroupBox gbAnimais;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAdicionar;
    }
}