using System;
using System.Windows.Forms;
using PCEClient.Models;
using PCEClient.Services;

namespace PCEClient.Forms
{
    public partial class BuscarContratoForm : Form
    {
        public BuscarContratoForm()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtContractNumber.Text))
                {
                    MessageBox.Show("Ingrese un número de contrato.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnBuscar.Enabled = false;
                var c = await ApiService.Instance.GetContractByNumberAsync(txtContractNumber.Text.Trim());
                btnBuscar.Enabled = true;

                if (c == null)
                {
                    MessageBox.Show("No se encontró un contrato con ese número.", "No encontrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearDetails();
                    return;
                }

                ShowDetails(c);
            }
            catch (Exception ex)
            {
                btnBuscar.Enabled = true;
                MessageBox.Show($"Error al buscar:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDetails(SupplyContract c)
        {
            lblDetContractNumber.Text = $"N° Contrato: {c.ContractNumber}";
            lblDetTotalValue.Text     = $"Valor total: {c.TotalValue} USD";
            lblDetDurationMonths.Text = $"Duración: {c.DurationMonths} meses";
            lblDetStatus.Text         = $"Estado: {c.Status}";
            lblDetSignedAt.Text       = $"Firma: {c.SignedAt:yyyy-MM-dd HH:mm:ss}";
            lblDetManufacturerId.Text = $"Fabricante ID: {c.ManufacturerId}";
            lblDetCreatedAt.Text      = $"Creado: {c.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

        private void ClearDetails()
        {
            lblDetContractNumber.Text = "N° Contrato:";
            lblDetTotalValue.Text     = "Valor total:";
            lblDetDurationMonths.Text = "Duración:";
            lblDetStatus.Text         = "Estado:";
            lblDetSignedAt.Text       = "Firma:";
            lblDetManufacturerId.Text = "Fabricante ID:";
            lblDetCreatedAt.Text      = "Creado:";
        }
    }
}
