using System;
using System.Windows.Forms;
using PCEClient.Models;
using PCEClient.Services;

namespace PCEClient.Forms
{
    public partial class EliminarComponenteForm : Form
    {
        private PassiveComponent _componenteEncontrado;

        public EliminarComponenteForm(PassiveComponent componente)
        {
            InitializeComponent();
            _componenteEncontrado = componente ?? throw new ArgumentNullException(nameof(componente));
            ShowDetails(_componenteEncontrado);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_componenteEncontrado == null) return;

            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el componente con ID {_componenteEncontrado.Id}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                btnEliminar.Enabled = false;
                bool deleted = await ApiService.Instance.DeleteAsync(_componenteEncontrado.Id.Value);
                btnEliminar.Enabled = true;

                if (deleted)
                {
                    MessageBox.Show("Componente eliminado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ComponentEventManager.Instance.NotifyAll();
                    _componenteEncontrado = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el componente.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                btnEliminar.Enabled = true;
                MessageBox.Show($"Error al eliminar:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDetails(PassiveComponent c)
        {
            lblDetId.Text           = $"ID: {c.Id}";
            lblDetPinCount.Text     = $"Núm. de pines: {c.PinCount}";
            lblDetPackageType.Text  = $"Encapsulado: {c.PackageType}";
            lblDetVoltage.Text      = $"Voltaje: {c.Voltage} V";
            lblDetTolerance.Text    = $"Tolerancia: {c.Tolerance}";
            lblDetNominalValue.Text = $"Valor nominal: {c.NominalValue?.Value} {c.NominalValue?.Unit}";
            lblDetCreatedAt.Text    = $"Creado: {c.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss")}";
            lblDetManufacturer.Text = $"Fabricante: {c.Manufacturer?.Name ?? "—"}";
            lblDetCountry.Text      = $"País: {c.Manufacturer?.Country ?? "—"}";
            lblDetLeadTime.Text     = $"T. de entrega: {c.Manufacturer?.AverageLeadTime} días";
        }
    }
}
