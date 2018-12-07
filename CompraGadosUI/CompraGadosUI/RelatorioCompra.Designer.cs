namespace CompraGadosUI
{
    partial class RelatorioCompra
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
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblDataEntregaDe = new System.Windows.Forms.Label();
            this.lblPecuarista = new System.Windows.Forms.Label();
            this.cmbPecuarista = new System.Windows.Forms.ComboBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.gridResultado = new System.Windows.Forms.DataGridView();
            this.txtDataEntregaDe = new System.Windows.Forms.MaskedTextBox();
            this.txtDataEntregaAte = new System.Windows.Forms.MaskedTextBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(12, 12);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 0;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(93, 12);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(174, 12);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(255, 12);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 3;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(336, 12);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(96, 57);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 5;
            this.lblId.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(118, 54);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 6;
            // 
            // lblDataEntregaDe
            // 
            this.lblDataEntregaDe.AutoSize = true;
            this.lblDataEntregaDe.Location = new System.Drawing.Point(13, 83);
            this.lblDataEntregaDe.Name = "lblDataEntregaDe";
            this.lblDataEntregaDe.Size = new System.Drawing.Size(99, 13);
            this.lblDataEntregaDe.TabIndex = 7;
            this.lblDataEntregaDe.Text = "Data de entrega de";
            // 
            // lblPecuarista
            // 
            this.lblPecuarista.AutoSize = true;
            this.lblPecuarista.Location = new System.Drawing.Point(227, 57);
            this.lblPecuarista.Name = "lblPecuarista";
            this.lblPecuarista.Size = new System.Drawing.Size(57, 13);
            this.lblPecuarista.TabIndex = 9;
            this.lblPecuarista.Text = "Pecuarista";
            // 
            // cmbPecuarista
            // 
            this.cmbPecuarista.FormattingEnabled = true;
            this.cmbPecuarista.Location = new System.Drawing.Point(290, 54);
            this.cmbPecuarista.Name = "cmbPecuarista";
            this.cmbPecuarista.Size = new System.Drawing.Size(121, 21);
            this.cmbPecuarista.TabIndex = 10;
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(261, 83);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(23, 13);
            this.lblAte.TabIndex = 11;
            this.lblAte.Text = "Até";
            // 
            // gridResultado
            // 
            this.gridResultado.AllowUserToAddRows = false;
            this.gridResultado.AllowUserToDeleteRows = false;
            this.gridResultado.AllowUserToResizeRows = false;
            this.gridResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResultado.Location = new System.Drawing.Point(16, 106);
            this.gridResultado.MultiSelect = false;
            this.gridResultado.Name = "gridResultado";
            this.gridResultado.ReadOnly = true;
            this.gridResultado.Size = new System.Drawing.Size(620, 332);
            this.gridResultado.TabIndex = 14;
            // 
            // txtDataEntregaDe
            // 
            this.txtDataEntregaDe.Location = new System.Drawing.Point(118, 80);
            this.txtDataEntregaDe.Mask = "00/00/0000";
            this.txtDataEntregaDe.Name = "txtDataEntregaDe";
            this.txtDataEntregaDe.Size = new System.Drawing.Size(100, 20);
            this.txtDataEntregaDe.TabIndex = 15;
            this.txtDataEntregaDe.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataEntregaAte
            // 
            this.txtDataEntregaAte.Location = new System.Drawing.Point(290, 80);
            this.txtDataEntregaAte.Mask = "00/00/0000";
            this.txtDataEntregaAte.Name = "txtDataEntregaAte";
            this.txtDataEntregaAte.Size = new System.Drawing.Size(100, 20);
            this.txtDataEntregaAte.TabIndex = 16;
            this.txtDataEntregaAte.ValidatingType = typeof(System.DateTime);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(234, 444);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 17;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(315, 444);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // RelatorioCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 479);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.txtDataEntregaAte);
            this.Controls.Add(this.txtDataEntregaDe);
            this.Controls.Add(this.gridResultado);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.cmbPecuarista);
            this.Controls.Add(this.lblPecuarista);
            this.Controls.Add(this.lblDataEntregaDe);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnPesquisar);
            this.Name = "RelatorioCompra";
            this.Text = "Consulta de compra de gado";
            this.Load += new System.EventHandler(this.RelatorioCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblDataEntregaDe;
        private System.Windows.Forms.Label lblPecuarista;
        private System.Windows.Forms.ComboBox cmbPecuarista;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DataGridView gridResultado;
        private System.Windows.Forms.MaskedTextBox txtDataEntregaDe;
        private System.Windows.Forms.MaskedTextBox txtDataEntregaAte;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
    }
}

