namespace PCEClient.Forms
{
    partial class SeleccionarComponentePorNombreForm
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
            this.lblNombre         = new System.Windows.Forms.Label();
            this.txtNombre         = new System.Windows.Forms.TextBox();
            this.btnBuscar         = new System.Windows.Forms.Button();
            this.dgvResultados     = new System.Windows.Forms.DataGridView();
            this.colId             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPinCount       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPackageType    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoltage        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTolerance      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNominalValue   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturer   = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountry        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblConteo         = new System.Windows.Forms.Label();
            this.btnSeleccionar    = new System.Windows.Forms.Button();
            this.btnCancelar       = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();

            // ── Buscar ────────────────────────────────────────────────────
            this.lblNombre.AutoSize = true; this.lblNombre.Location = new System.Drawing.Point(20, 20); this.lblNombre.Text = "Nombre:";
            this.txtNombre.Location = new System.Drawing.Point(80, 17); this.txtNombre.Name = "txtNombre"; this.txtNombre.Size = new System.Drawing.Size(250, 20);
            this.btnBuscar.Location = new System.Drawing.Point(345, 15); this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 25); this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            // ── dgvResultados ─────────────────────────────────────────────
            this.dgvResultados.AllowUserToAddRows    = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colName, this.colPinCount, this.colPackageType, this.colVoltage,
                this.colTolerance, this.colNominalValue, this.colManufacturer, this.colCountry });
            this.dgvResultados.Location      = new System.Drawing.Point(20, 55);
            this.dgvResultados.Name          = "dgvResultados";
            this.dgvResultados.ReadOnly      = true;
            this.dgvResultados.Size          = new System.Drawing.Size(770, 280);
            this.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultados.MultiSelect   = false;

            this.colId.HeaderText           = "ID";              this.colId.Name           = "colId";           this.colId.Width           = 50;
            this.colName.HeaderText         = "Nombre";          this.colName.Name         = "colName";         this.colName.Width         = 160;
            this.colPinCount.HeaderText     = "Pines";           this.colPinCount.Name     = "colPinCount";     this.colPinCount.Width     = 60;
            this.colPackageType.HeaderText  = "Encapsulado";     this.colPackageType.Name  = "colPackageType";  this.colPackageType.Width  = 100;
            this.colVoltage.HeaderText      = "Voltaje (V)";     this.colVoltage.Name      = "colVoltage";      this.colVoltage.Width      = 80;
            this.colTolerance.HeaderText    = "Tolerancia";      this.colTolerance.Name    = "colTolerance";    this.colTolerance.Width    = 80;
            this.colNominalValue.HeaderText = "Valor nominal";   this.colNominalValue.Name = "colNominalValue"; this.colNominalValue.Width = 110;
            this.colManufacturer.HeaderText = "Fabricante";      this.colManufacturer.Name = "colManufacturer"; this.colManufacturer.Width = 150;
            this.colCountry.HeaderText      = "País";            this.colCountry.Name      = "colCountry";      this.colCountry.Width      = 100;

            // ── lblConteo ─────────────────────────────────────────────────
            this.lblConteo.AutoSize  = true;
            this.lblConteo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblConteo.Location  = new System.Drawing.Point(20, 345);
            this.lblConteo.Name      = "lblConteo";
            this.lblConteo.Text      = "0 resultados";

            // ── btnSeleccionar ────────────────────────────────────────────
            this.btnSeleccionar.Location = new System.Drawing.Point(580, 370);
            this.btnSeleccionar.Name     = "btnSeleccionar";
            this.btnSeleccionar.Size     = new System.Drawing.Size(100, 30);
            this.btnSeleccionar.Text     = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click   += new System.EventHandler(this.btnSeleccionar_Click);

            // ── btnCancelar ───────────────────────────────────────────────
            this.btnCancelar.Location = new System.Drawing.Point(690, 370);
            this.btnCancelar.Name     = "btnCancelar";
            this.btnCancelar.Size     = new System.Drawing.Size(100, 30);
            this.btnCancelar.Text     = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click   += new System.EventHandler(this.btnCancelar_Click);

            // ── SeleccionarComponentePorNombreForm ────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(810, 415);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.lblConteo);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "SeleccionarComponentePorNombreForm";
            this.Text = "Seleccionar Componente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label        lblNombre;
        private System.Windows.Forms.TextBox      txtNombre;
        private System.Windows.Forms.Button       btnBuscar;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPinCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPackageType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTolerance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNominalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
        private System.Windows.Forms.Label        lblConteo;
        private System.Windows.Forms.Button       btnSeleccionar;
        private System.Windows.Forms.Button       btnCancelar;
    }
}
