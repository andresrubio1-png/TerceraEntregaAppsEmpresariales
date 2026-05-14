using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PCEClient.Models;
using PCEClient.Services;

namespace PCEClient.Forms
{
    public partial class BuscarComponentePorNombreForm : Form
    {
        public BuscarComponentePorNombreForm()
        {
            InitializeComponent();
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
                List<PassiveComponent> resultados = await ApiService.Instance.GetByNameAsync(txtNombre.Text.Trim());
                btnBuscar.Enabled = true;

                dgvResultados.Rows.Clear();

                if (resultados == null || resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron componentes con ese nombre.", "Sin resultados",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblConteo.Text = "0 resultados";
                    return;
                }

                foreach (var c in resultados)
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
                        c.Manufacturer?.Country ?? "—",
                        c.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                lblConteo.Text = $"{resultados.Count} resultado(s)";
            }
            catch (Exception ex)
            {
                btnBuscar.Enabled = true;
                MessageBox.Show($"Error al buscar:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
