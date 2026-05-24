namespace PCEClient.Forms
{
    partial class BuscarContratoForm
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
            this.lblNum                = new System.Windows.Forms.Label();
            this.txtContractNumber     = new System.Windows.Forms.TextBox();
            this.btnBuscar             = new System.Windows.Forms.Button();
            this.grpDetalles           = new System.Windows.Forms.GroupBox();
            this.lblDetContractNumber  = new System.Windows.Forms.Label();
            this.lblDetTotalValue      = new System.Windows.Forms.Label();
            this.lblDetDurationMonths  = new System.Windows.Forms.Label();
            this.lblDetStatus          = new System.Windows.Forms.Label();
            this.lblDetSignedAt        = new System.Windows.Forms.Label();
            this.lblDetManufacturerId  = new System.Windows.Forms.Label();
            this.lblDetCreatedAt       = new System.Windows.Forms.Label();
            this.grpDetalles.SuspendLayout();
            this.SuspendLayout();

            this.lblNum.AutoSize = true; this.lblNum.Location = new System.Drawing.Point(20, 20); this.lblNum.Text = "N° Contrato:";
            this.txtContractNumber.Location = new System.Drawing.Point(100, 17); this.txtContractNumber.Name = "txtContractNumber"; this.txtContractNumber.Size = new System.Drawing.Size(180, 20);
            this.btnBuscar.Location = new System.Drawing.Point(295, 15); this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 25); this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.grpDetalles.Controls.Add(this.lblDetContractNumber);
            this.grpDetalles.Controls.Add(this.lblDetTotalValue);
            this.grpDetalles.Controls.Add(this.lblDetDurationMonths);
            this.grpDetalles.Controls.Add(this.lblDetStatus);
            this.grpDetalles.Controls.Add(this.lblDetSignedAt);
            this.grpDetalles.Controls.Add(this.lblDetManufacturerId);
            this.grpDetalles.Controls.Add(this.lblDetCreatedAt);
            this.grpDetalles.Location = new System.Drawing.Point(20, 55);
            this.grpDetalles.Name     = "grpDetalles";
            this.grpDetalles.Size     = new System.Drawing.Size(420, 220);
            this.grpDetalles.Text     = "Detalles del Contrato";

            this.lblDetContractNumber.AutoSize = true; this.lblDetContractNumber.Location = new System.Drawing.Point(15, 25);  this.lblDetContractNumber.Text = "N° Contrato:";
            this.lblDetTotalValue.AutoSize     = true; this.lblDetTotalValue.Location     = new System.Drawing.Point(15, 50);  this.lblDetTotalValue.Text     = "Valor total:";
            this.lblDetDurationMonths.AutoSize = true; this.lblDetDurationMonths.Location = new System.Drawing.Point(15, 75);  this.lblDetDurationMonths.Text = "Duración:";
            this.lblDetStatus.AutoSize         = true; this.lblDetStatus.Location         = new System.Drawing.Point(15, 100); this.lblDetStatus.Text         = "Estado:";
            this.lblDetSignedAt.AutoSize       = true; this.lblDetSignedAt.Location       = new System.Drawing.Point(15, 125); this.lblDetSignedAt.Text       = "Firma:";
            this.lblDetManufacturerId.AutoSize = true; this.lblDetManufacturerId.Location = new System.Drawing.Point(15, 150); this.lblDetManufacturerId.Text = "Fabricante ID:";
            this.lblDetCreatedAt.AutoSize      = true; this.lblDetCreatedAt.Location      = new System.Drawing.Point(15, 175); this.lblDetCreatedAt.Text      = "Creado:";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(465, 295);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.txtContractNumber);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.grpDetalles);
            this.Name = "BuscarContratoForm";
            this.Text = "Buscar Contrato por Número";
            this.grpDetalles.ResumeLayout(false);
            this.grpDetalles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label    lblNum;
        private System.Windows.Forms.TextBox  txtContractNumber;
        private System.Windows.Forms.Button   btnBuscar;
        private System.Windows.Forms.GroupBox grpDetalles;
        private System.Windows.Forms.Label    lblDetContractNumber;
        private System.Windows.Forms.Label    lblDetTotalValue;
        private System.Windows.Forms.Label    lblDetDurationMonths;
        private System.Windows.Forms.Label    lblDetStatus;
        private System.Windows.Forms.Label    lblDetSignedAt;
        private System.Windows.Forms.Label    lblDetManufacturerId;
        private System.Windows.Forms.Label    lblDetCreatedAt;
    }
}
