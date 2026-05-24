namespace PCEClient.Forms
{
    partial class ListarContratosForm
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
            this.btnRefrescar     = new System.Windows.Forms.Button();
            this.lblCount         = new System.Windows.Forms.Label();
            this.dgvContratos     = new System.Windows.Forms.DataGridView();
            this.colContractNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalValue     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurationMonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSignedAt       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedAt      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            this.SuspendLayout();

            this.btnRefrescar.Location = new System.Drawing.Point(20, 15);
            this.btnRefrescar.Name     = "btnRefrescar";
            this.btnRefrescar.Size     = new System.Drawing.Size(100, 25);
            this.btnRefrescar.Text     = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click   += new System.EventHandler(this.btnRefrescar_Click);

            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(135, 20);
            this.lblCount.Name     = "lblCount";
            this.lblCount.Text     = "Total: 0";

            this.dgvContratos.AllowUserToAddRows    = false;
            this.dgvContratos.AllowUserToDeleteRows = false;
            this.dgvContratos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colContractNumber, this.colTotalValue, this.colDurationMonths,
                this.colStatus, this.colSignedAt, this.colManufacturerId, this.colCreatedAt });
            this.dgvContratos.Location = new System.Drawing.Point(20, 50);
            this.dgvContratos.Name     = "dgvContratos";
            this.dgvContratos.ReadOnly = true;
            this.dgvContratos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContratos.Size     = new System.Drawing.Size(900, 320);

            this.colContractNumber.HeaderText = "N° Contrato";   this.colContractNumber.Name = "colContractNumber"; this.colContractNumber.Width = 130; this.colContractNumber.ReadOnly = true;
            this.colTotalValue.HeaderText     = "Valor total";   this.colTotalValue.Name     = "colTotalValue";     this.colTotalValue.Width     = 110; this.colTotalValue.ReadOnly     = true;
            this.colDurationMonths.HeaderText = "Duración (m)";  this.colDurationMonths.Name = "colDurationMonths"; this.colDurationMonths.Width = 90;  this.colDurationMonths.ReadOnly = true;
            this.colStatus.HeaderText         = "Estado";        this.colStatus.Name         = "colStatus";         this.colStatus.Width         = 90;  this.colStatus.ReadOnly         = true;
            this.colSignedAt.HeaderText       = "Firma";         this.colSignedAt.Name       = "colSignedAt";       this.colSignedAt.Width       = 140; this.colSignedAt.ReadOnly       = true;
            this.colManufacturerId.HeaderText = "Fabricante ID"; this.colManufacturerId.Name = "colManufacturerId"; this.colManufacturerId.Width = 100; this.colManufacturerId.ReadOnly = true;
            this.colCreatedAt.HeaderText      = "Creado";        this.colCreatedAt.Name      = "colCreatedAt";      this.colCreatedAt.Width      = 140; this.colCreatedAt.ReadOnly      = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(940, 390);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvContratos);
            this.Name = "ListarContratosForm";
            this.Text = "Listar Contratos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button        btnRefrescar;
        private System.Windows.Forms.Label         lblCount;
        private System.Windows.Forms.DataGridView  dgvContratos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurationMonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSignedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedAt;
    }
}
