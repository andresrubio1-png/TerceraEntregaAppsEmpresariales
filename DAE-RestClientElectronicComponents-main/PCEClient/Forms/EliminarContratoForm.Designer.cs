namespace PCEClient.Forms
{
    partial class EliminarContratoForm
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
            this.grpDetalles           = new System.Windows.Forms.GroupBox();
            this.lblDetContractNumber  = new System.Windows.Forms.Label();
            this.lblDetTotalValue      = new System.Windows.Forms.Label();
            this.lblDetDurationMonths  = new System.Windows.Forms.Label();
            this.lblDetStatus          = new System.Windows.Forms.Label();
            this.lblDetSignedAt        = new System.Windows.Forms.Label();
            this.lblDetManufacturerId  = new System.Windows.Forms.Label();
            this.lblDetCreatedAt       = new System.Windows.Forms.Label();
            this.btnEliminar           = new System.Windows.Forms.Button();
            this.grpDetalles.SuspendLayout();
            this.SuspendLayout();

            this.grpDetalles.Controls.Add(this.lblDetContractNumber);
            this.grpDetalles.Controls.Add(this.lblDetTotalValue);
            this.grpDetalles.Controls.Add(this.lblDetDurationMonths);
            this.grpDetalles.Controls.Add(this.lblDetStatus);
            this.grpDetalles.Controls.Add(this.lblDetSignedAt);
            this.grpDetalles.Controls.Add(this.lblDetManufacturerId);
            this.grpDetalles.Controls.Add(this.lblDetCreatedAt);
            this.grpDetalles.Location = new System.Drawing.Point(20, 20);
            this.grpDetalles.Size     = new System.Drawing.Size(420, 220);
            this.grpDetalles.Text     = "Detalles del Contrato";

            this.lblDetContractNumber.AutoSize = true; this.lblDetContractNumber.Location = new System.Drawing.Point(15, 25);  this.lblDetContractNumber.Text = "N° Contrato:";
            this.lblDetTotalValue.AutoSize     = true; this.lblDetTotalValue.Location     = new System.Drawing.Point(15, 50);  this.lblDetTotalValue.Text     = "Valor total:";
            this.lblDetDurationMonths.AutoSize = true; this.lblDetDurationMonths.Location = new System.Drawing.Point(15, 75);  this.lblDetDurationMonths.Text = "Duración:";
            this.lblDetStatus.AutoSize         = true; this.lblDetStatus.Location         = new System.Drawing.Point(15, 100); this.lblDetStatus.Text         = "Estado:";
            this.lblDetSignedAt.AutoSize       = true; this.lblDetSignedAt.Location       = new System.Drawing.Point(15, 125); this.lblDetSignedAt.Text       = "Firma:";
            this.lblDetManufacturerId.AutoSize = true; this.lblDetManufacturerId.Location = new System.Drawing.Point(15, 150); this.lblDetManufacturerId.Text = "Fabricante ID:";
            this.lblDetCreatedAt.AutoSize      = true; this.lblDetCreatedAt.Location      = new System.Drawing.Point(15, 175); this.lblDetCreatedAt.Text      = "Creado:";

            this.btnEliminar.BackColor = System.Drawing.Color.IndianRed;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location  = new System.Drawing.Point(20, 250);
            this.btnEliminar.Size      = new System.Drawing.Size(420, 35);
            this.btnEliminar.Text      = "Eliminar Contrato";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click    += new System.EventHandler(this.btnEliminar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(465, 305);
            this.Controls.Add(this.grpDetalles);
            this.Controls.Add(this.btnEliminar);
            this.Name = "EliminarContratoForm";
            this.Text = "Eliminar Contrato";
            this.grpDetalles.ResumeLayout(false);
            this.grpDetalles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDetalles;
        private System.Windows.Forms.Label    lblDetContractNumber;
        private System.Windows.Forms.Label    lblDetTotalValue;
        private System.Windows.Forms.Label    lblDetDurationMonths;
        private System.Windows.Forms.Label    lblDetStatus;
        private System.Windows.Forms.Label    lblDetSignedAt;
        private System.Windows.Forms.Label    lblDetManufacturerId;
        private System.Windows.Forms.Label    lblDetCreatedAt;
        private System.Windows.Forms.Button   btnEliminar;
    }
}
