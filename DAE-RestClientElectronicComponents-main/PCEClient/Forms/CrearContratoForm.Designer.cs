namespace PCEClient.Forms
{
    partial class CrearContratoForm
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
            this.grpFabricante      = new System.Windows.Forms.GroupBox();
            this.dgvFabricantes     = new System.Windows.Forms.DataGridView();
            this.colFabId           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFabName         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFabCountry      = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFabLeadTime     = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFabSeleccionado = new System.Windows.Forms.Label();
            this.btnRefrescarFab    = new System.Windows.Forms.Button();
            this.grpContrato        = new System.Windows.Forms.GroupBox();
            this.lblContractNumber  = new System.Windows.Forms.Label();
            this.txtContractNumber  = new System.Windows.Forms.TextBox();
            this.lblTotalValue      = new System.Windows.Forms.Label();
            this.txtTotalValue      = new System.Windows.Forms.TextBox();
            this.lblDurationMonths  = new System.Windows.Forms.Label();
            this.txtDurationMonths  = new System.Windows.Forms.TextBox();
            this.lblStatus          = new System.Windows.Forms.Label();
            this.cboStatus          = new System.Windows.Forms.ComboBox();
            this.lblSignedAt        = new System.Windows.Forms.Label();
            this.dtpSignedAt        = new System.Windows.Forms.DateTimePicker();
            this.btnCrear           = new System.Windows.Forms.Button();
            this.grpFabricante.SuspendLayout();
            this.grpContrato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFabricantes)).BeginInit();
            this.SuspendLayout();

            // ── grpFabricante ──────────────────────────────────────────────
            this.grpFabricante.Controls.Add(this.dgvFabricantes);
            this.grpFabricante.Controls.Add(this.lblFabSeleccionado);
            this.grpFabricante.Controls.Add(this.btnRefrescarFab);
            this.grpFabricante.Location = new System.Drawing.Point(12, 12);
            this.grpFabricante.Name     = "grpFabricante";
            this.grpFabricante.Size     = new System.Drawing.Size(580, 210);
            this.grpFabricante.Text     = "Seleccionar Fabricante (obligatorio)";

            this.dgvFabricantes.AllowUserToAddRows    = false;
            this.dgvFabricantes.AllowUserToDeleteRows = false;
            this.dgvFabricantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFabricantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFabId, this.colFabName, this.colFabCountry, this.colFabLeadTime });
            this.dgvFabricantes.Location      = new System.Drawing.Point(10, 22);
            this.dgvFabricantes.Name          = "dgvFabricantes";
            this.dgvFabricantes.ReadOnly      = true;
            this.dgvFabricantes.Size          = new System.Drawing.Size(555, 130);
            this.dgvFabricantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFabricantes.MultiSelect   = false;
            this.dgvFabricantes.SelectionChanged += new System.EventHandler(this.dgvFabricantes_SelectionChanged);

            this.colFabId.HeaderText = "ID";       this.colFabId.Name   = "colFabId";   this.colFabId.Width   = 45;
            this.colFabName.HeaderText = "Nombre"; this.colFabName.Name = "colFabName"; this.colFabName.Width = 200;
            this.colFabCountry.HeaderText = "País"; this.colFabCountry.Name = "colFabCountry"; this.colFabCountry.Width = 100;
            this.colFabLeadTime.HeaderText = "T. de entrega (días)"; this.colFabLeadTime.Name = "colFabLeadTime"; this.colFabLeadTime.Width = 140;

            this.lblFabSeleccionado.AutoSize  = true;
            this.lblFabSeleccionado.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblFabSeleccionado.Location  = new System.Drawing.Point(10, 162);
            this.lblFabSeleccionado.Name      = "lblFabSeleccionado";
            this.lblFabSeleccionado.Text      = "Ninguno seleccionado";

            this.btnRefrescarFab.Location = new System.Drawing.Point(450, 158);
            this.btnRefrescarFab.Name     = "btnRefrescarFab";
            this.btnRefrescarFab.Size     = new System.Drawing.Size(115, 25);
            this.btnRefrescarFab.Text     = "↻ Refrescar";
            this.btnRefrescarFab.UseVisualStyleBackColor = true;
            this.btnRefrescarFab.Click   += new System.EventHandler(this.btnRefrescarFab_Click);

            // ── grpContrato ────────────────────────────────────────────────
            this.grpContrato.Controls.Add(this.lblContractNumber);
            this.grpContrato.Controls.Add(this.txtContractNumber);
            this.grpContrato.Controls.Add(this.lblTotalValue);
            this.grpContrato.Controls.Add(this.txtTotalValue);
            this.grpContrato.Controls.Add(this.lblDurationMonths);
            this.grpContrato.Controls.Add(this.txtDurationMonths);
            this.grpContrato.Controls.Add(this.lblStatus);
            this.grpContrato.Controls.Add(this.cboStatus);
            this.grpContrato.Controls.Add(this.lblSignedAt);
            this.grpContrato.Controls.Add(this.dtpSignedAt);
            this.grpContrato.Location = new System.Drawing.Point(12, 232);
            this.grpContrato.Name     = "grpContrato";
            this.grpContrato.Size     = new System.Drawing.Size(580, 220);
            this.grpContrato.Text     = "Datos del Contrato";

            this.lblContractNumber.AutoSize = true; this.lblContractNumber.Location = new System.Drawing.Point(15, 25); this.lblContractNumber.Text = "N° Contrato:";
            this.txtContractNumber.Location = new System.Drawing.Point(170, 22); this.txtContractNumber.Size = new System.Drawing.Size(370, 20); this.txtContractNumber.Name = "txtContractNumber";
            this.lblTotalValue.AutoSize = true; this.lblTotalValue.Location = new System.Drawing.Point(15, 60); this.lblTotalValue.Text = "Valor total (USD):";
            this.txtTotalValue.Location = new System.Drawing.Point(170, 57); this.txtTotalValue.Size = new System.Drawing.Size(370, 20); this.txtTotalValue.Name = "txtTotalValue";
            this.lblDurationMonths.AutoSize = true; this.lblDurationMonths.Location = new System.Drawing.Point(15, 95); this.lblDurationMonths.Text = "Duración (meses):";
            this.txtDurationMonths.Location = new System.Drawing.Point(170, 92); this.txtDurationMonths.Size = new System.Drawing.Size(370, 20); this.txtDurationMonths.Name = "txtDurationMonths";
            this.lblStatus.AutoSize = true; this.lblStatus.Location = new System.Drawing.Point(15, 130); this.lblStatus.Text = "Estado:";
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Location = new System.Drawing.Point(170, 127); this.cboStatus.Size = new System.Drawing.Size(370, 21); this.cboStatus.Name = "cboStatus";
            this.lblSignedAt.AutoSize = true; this.lblSignedAt.Location = new System.Drawing.Point(15, 165); this.lblSignedAt.Text = "Fecha de firma:";
            this.dtpSignedAt.Location = new System.Drawing.Point(170, 162); this.dtpSignedAt.Size = new System.Drawing.Size(370, 20); this.dtpSignedAt.Name = "dtpSignedAt";

            // ── btnCrear ───────────────────────────────────────────────────
            this.btnCrear.Enabled  = false;
            this.btnCrear.Location = new System.Drawing.Point(12, 465);
            this.btnCrear.Name     = "btnCrear";
            this.btnCrear.Size     = new System.Drawing.Size(580, 35);
            this.btnCrear.Text     = "Crear Contrato";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click   += new System.EventHandler(this.btnCrear_Click);

            // ── CrearContratoForm ──────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(606, 515);
            this.Controls.Add(this.grpFabricante);
            this.Controls.Add(this.grpContrato);
            this.Controls.Add(this.btnCrear);
            this.Name = "CrearContratoForm";
            this.Text = "Crear Contrato de Suministro";
            this.grpFabricante.ResumeLayout(false);
            this.grpFabricante.PerformLayout();
            this.grpContrato.ResumeLayout(false);
            this.grpContrato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFabricantes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox     grpFabricante;
        private System.Windows.Forms.DataGridView dgvFabricantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFabId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFabName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFabCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFabLeadTime;
        private System.Windows.Forms.Label        lblFabSeleccionado;
        private System.Windows.Forms.Button       btnRefrescarFab;
        private System.Windows.Forms.GroupBox     grpContrato;
        private System.Windows.Forms.Label        lblContractNumber;
        private System.Windows.Forms.TextBox      txtContractNumber;
        private System.Windows.Forms.Label        lblTotalValue;
        private System.Windows.Forms.TextBox      txtTotalValue;
        private System.Windows.Forms.Label        lblDurationMonths;
        private System.Windows.Forms.TextBox      txtDurationMonths;
        private System.Windows.Forms.Label        lblStatus;
        private System.Windows.Forms.ComboBox     cboStatus;
        private System.Windows.Forms.Label        lblSignedAt;
        private System.Windows.Forms.DateTimePicker dtpSignedAt;
        private System.Windows.Forms.Button       btnCrear;
    }
}
