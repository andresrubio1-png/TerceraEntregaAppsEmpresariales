using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PCEClient.Models;
using PCEClient.Services;

namespace PCEClient.Forms
{
    public partial class SeleccionarComponentePorNombreForm : Form
    {
        private List<PassiveComponent> _resultados = new List<PassiveComponent>();

        public PassiveComponent SelectedComponent { get; private set; }

        public SeleccionarComponentePorNombreForm(string titulo = "Seleccionar Componente")
        {
            InitializeComponent();
            this.Text = titulo;
            btnSeleccionar.Enabled = false;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Ingrese un nombre válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnBuscar.Enabled = false;
                _resultados = await ApiService.Instance.GetByNameAsync(txtNombre.Text.Trim());
                btnBuscar.Enabled = true;

                dgvResultados.Rows.Clear();
                btnSeleccionar.Enabled = false;

                if (_resultados == null || _resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron componentes con ese nombre.", "Sin resultados",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblConteo.Text = "0 resultados";
                    return;
                }

                foreach (var c in _resultados)
                {
                    dgvResultados.Rows.Add(
                        c.Id,
                        c.Name,
                        c.PinCount,
                        c.PackageType,
                        c.Voltage,
                        c.Tolerance,
                        $"{c.NominalValue?.Value} {c.NominalValue?.Unit}",
                        c.Manufacturer?.Name ?? "—",
                        c.Manufacturer?.Country ?? "—");
                }
                lblConteo.Text = $"{_resultados.Count} resultado(s) — seleccione uno y confirme";
                btnSeleccionar.Enabled = true;
            }
            catch (Exception ex)
            {
                btnBuscar.Enabled = true;
                MessageBox.Show($"Error al buscar:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un componente de la lista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvResultados.SelectedRows[0].Index;
            if (rowIndex < 0 || rowIndex >= _resultados.Count) return;

            SelectedComponent = _resultados[rowIndex];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
