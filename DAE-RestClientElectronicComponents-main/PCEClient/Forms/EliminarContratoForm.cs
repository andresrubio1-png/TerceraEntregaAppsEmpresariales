using System;
using System.Windows.Forms;
using PCEClient.Models;
using PCEClient.Services;

namespace PCEClient.Forms
{
    public partial class EliminarContratoForm : Form
    {
        private SupplyContract _contrato;

        public EliminarContratoForm(SupplyContract contrato)
        {
            InitializeComponent();
            _contrato = contrato ?? throw new ArgumentNullException(nameof(contrato));
            ShowDetails(_contrato);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_contrato == null) return;

            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el contrato {_contrato.ContractNumber}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                btnEliminar.Enabled = false;
                bool deleted = await ApiService.Instance.DeleteContractAsync(_contrato.ContractNumber);
                btnEliminar.Enabled = true;

                if (deleted)
                {
                    MessageBox.Show("Contrato eliminado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SupplyContractEventManager.Instance.NotifyAll();
                    _contrato = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el contrato.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                btnEliminar.Enabled = true;
                MessageBox.Show($"Error al eliminar:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
