namespace PCEClient.Forms
{
    partial class ListarContratosPorFiltroForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.rbManufacturer    = new System.Windows.Forms.RadioButton();
            this.rbStatus          = new System.Windows.Forms.RadioButton();
            this.rbValueRange      = new System.Windows.Forms.RadioButton();
            this.txtManufacturerId = new System.Windows.Forms.TextBox();
            this.cboStatus         = new System.Windows.Forms.ComboBox();
            this.lblMin            = new System.Windows.Forms.Label();
            this.txtMinValue       = new System.Windows.Forms.TextBox();
            this.lblMax            = new System.Windows.Forms.Label();
            this.txtMaxValue       = new System.Windows.Forms.TextBox();
            this.btnFiltrar        = new System.Windows.Forms.Button();
            this.lblCount          = new System.Windows.Forms.Label();
            this.dgvResultados     = new System.Windows.Forms.DataGridView();
            this.colContractNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalValue     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurationMonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSignedAt       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedAt      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();

            this.rbManufacturer.AutoSize = true; this.rbManufacturer.Checked = true; this.rbManufacturer.TabStop = true;
            this.rbManufacturer.Location = new System.Drawing.Point(20, 15); this.rbManufacturer.Text = "Por fabricante (ID)";
            this.rbManufacturer.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);

            this.rbStatus.AutoSize = true; this.rbStatus.Location = new System.Drawing.Point(20, 40); this.rbStatus.Text = "Por estado";
            this.rbStatus.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);

            this.rbValueRange.AutoSize = true; this.rbValueRange.Location = new System.Drawing.Point(20, 65); this.rbValueRange.Text = "Por rango de valor";
            this.rbValueRange.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);

            this.txtManufacturerId.Location = new System.Drawing.Point(170, 13); this.txtManufacturerId.Size = new System.Drawing.Size(120, 20); this.txtManufacturerId.Name = "txtManufacturerId";

            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Location = new System.Drawing.Point(170, 38); this.cboStatus.Size = new System.Drawing.Size(120, 21); this.cboStatus.Name = "cboStatus"; this.cboStatus.Enabled = false;

            this.lblMin.AutoSize = true; this.lblMin.Location = new System.Drawing.Point(170, 67); this.lblMin.Text = "Min:";
            this.txtMinValue.Location = new System.Drawing.Point(205, 64); this.txtMinValue.Size = new System.Drawing.Size(70, 20); this.txtMinValue.Name = "txtMinValue"; this.txtMinValue.Enabled = false;
            this.lblMax.AutoSize = true; this.lblMax.Location = new System.Drawing.Point(290, 67); this.lblMax.Text = "Max:";
            this.txtMaxValue.Location = new System.Drawing.Point(325, 64); this.txtMaxValue.Size = new System.Drawing.Size(70, 20); this.txtMaxValue.Name = "txtMaxValue"; this.txtMaxValue.Enabled = false;

            this.btnFiltrar.Location = new System.Drawing.Point(420, 30); this.btnFiltrar.Size = new System.Drawing.Size(100, 35); this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            this.lblCount.AutoSize = true; this.lblCount.Location = new System.Drawing.Point(20, 100); this.lblCount.Text = "Total: 0";

            this.dgvResultados.AllowUserToAddRows    = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colContractNumber, this.colTotalValue, this.colDurationMonths,
                this.colStatus, this.colSignedAt, this.colManufacturerId, this.colCreatedAt });
            this.dgvResultados.Location = new System.Drawing.Point(20, 120);
            this.dgvResultados.Name     = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultados.Size     = new System.Drawing.Size(900, 280);

            this.colContractNumber.HeaderText = "N° Contrato";   this.colContractNumber.Name = "colContractNumber"; this.colContractNumber.Width = 130;
            this.colTotalValue.HeaderText     = "Valor total";   this.colTotalValue.Name     = "colTotalValue";     this.colTotalValue.Width     = 110;
            this.colDurationMonths.HeaderText = "Duración (m)";  this.colDurationMonths.Name = "colDurationMonths"; this.colDurationMonths.Width = 90;
            this.colStatus.HeaderText         = "Estado";        this.colStatus.Name         = "colStatus";         this.colStatus.Width         = 90;
            this.colSignedAt.HeaderText       = "Firma";         this.colSignedAt.Name       = "colSignedAt";       this.colSignedAt.Width       = 140;
            this.colManufacturerId.HeaderText = "Fabricante ID"; this.colManufacturerId.Name = "colManufacturerId"; this.colManufacturerId.Width = 100;
            this.colCreatedAt.HeaderText      = "Creado";        this.colCreatedAt.Name      = "colCreatedAt";      this.colCreatedAt.Width      = 140;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(940, 420);
            this.Controls.Add(this.rbManufacturer);
            this.Controls.Add(this.rbStatus);
            this.Controls.Add(this.rbValueRange);
            this.Controls.Add(this.txtManufacturerId);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.txtMinValue);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.txtMaxValue);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvResultados);
            this.Name = "ListarContratosPorFiltroForm";
            this.Text = "Listar Contratos por Filtro";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton rbManufacturer;
        private System.Windows.Forms.RadioButton rbStatus;
        private System.Windows.Forms.RadioButton rbValueRange;
        private System.Windows.Forms.TextBox     txtManufacturerId;
        private System.Windows.Forms.ComboBox    cboStatus;
        private System.Windows.Forms.Label       lblMin;
        private System.Windows.Forms.TextBox     txtMinValue;
        private System.Windows.Forms.Label       lblMax;
        private System.Windows.Forms.TextBox     txtMaxValue;
        private System.Windows.Forms.Button      btnFiltrar;
        private System.Windows.Forms.Label       lblCount;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurationMonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSignedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedAt;
    }
}
