namespace PCEClient.Forms
{
    partial class SeleccionarContratoForm
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
            this.btnRefrescar      = new System.Windows.Forms.Button();
            this.lblConteo         = new System.Windows.Forms.Label();
            this.dgvContratos      = new System.Windows.Forms.DataGridView();
            this.colContractNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalValue     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurationMonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSignedAt       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionar    = new System.Windows.Forms.Button();
            this.btnCancelar       = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            this.SuspendLayout();

            this.btnRefrescar.Location = new System.Drawing.Point(20, 15);
            this.btnRefrescar.Size     = new System.Drawing.Size(100, 25);
            this.btnRefrescar.Text     = "↻ Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click   += new System.EventHandler(this.btnRefrescar_Click);

            this.lblConteo.AutoSize  = true;
            this.lblConteo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblConteo.Location  = new System.Drawing.Point(135, 20);
            this.lblConteo.Text      = "Cargando...";

            this.dgvContratos.AllowUserToAddRows    = false;
            this.dgvContratos.AllowUserToDeleteRows = false;
            this.dgvContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContratos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colContractNumber, this.colTotalValue, this.colDurationMonths,
                this.colStatus, this.colSignedAt, this.colManufacturerId });
            this.dgvContratos.Location = new System.Drawing.Point(20, 50);
            this.dgvContratos.Name     = "dgvContratos";
            this.dgvContratos.ReadOnly = true;
            this.dgvContratos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContratos.MultiSelect = false;
            this.dgvContratos.Size     = new System.Drawing.Size(770, 280);

            this.colContractNumber.HeaderText = "N° Contrato";   this.colContractNumber.Name = "colContractNumber"; this.colContractNumber.Width = 130;
            this.colTotalValue.HeaderText     = "Valor total";   this.colTotalValue.Name     = "colTotalValue";     this.colTotalValue.Width     = 110;
            this.colDurationMonths.HeaderText = "Duración (m)";  this.colDurationMonths.Name = "colDurationMonths"; this.colDurationMonths.Width = 90;
            this.colStatus.HeaderText         = "Estado";        this.colStatus.Name         = "colStatus";         this.colStatus.Width         = 90;
            this.colSignedAt.HeaderText       = "Firma";         this.colSignedAt.Name       = "colSignedAt";       this.colSignedAt.Width       = 140;
            this.colManufacturerId.HeaderText = "Fabricante ID"; this.colManufacturerId.Name = "colManufacturerId"; this.colManufacturerId.Width = 100;

            this.btnSeleccionar.Location = new System.Drawing.Point(580, 345);
            this.btnSeleccionar.Size     = new System.Drawing.Size(100, 30);
            this.btnSeleccionar.Text     = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click   += new System.EventHandler(this.btnSeleccionar_Click);

            this.btnCancelar.Location = new System.Drawing.Point(690, 345);
            this.btnCancelar.Size     = new System.Drawing.Size(100, 30);
            this.btnCancelar.Text     = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click   += new System.EventHandler(this.btnCancelar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(810, 390);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.lblConteo);
            this.Controls.Add(this.dgvContratos);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "SeleccionarContratoForm";
            this.Text = "Seleccionar Contrato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button        btnRefrescar;
        private System.Windows.Forms.Label         lblConteo;
        private System.Windows.Forms.DataGridView  dgvContratos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurationMonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSignedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturerId;
        private System.Windows.Forms.Button        btnSeleccionar;
        private System.Windows.Forms.Button        btnCancelar;
    }
}
