using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PCEClient.Models;
using PCEClient.Services;

namespace PCEClient.Forms
{
    public partial class SeleccionarContratoForm : Form
    {
        private List<SupplyContract> _contratos = new List<SupplyContract>();

        public SupplyContract SelectedContract { get; private set; }

        public SeleccionarContratoForm(string titulo = "Seleccionar Contrato")
        {
            InitializeComponent();
            this.Text = titulo;
            btnSeleccionar.Enabled = false;
            LoadAll();
        }

        private async void LoadAll()
        {
            try
            {
                btnRefrescar.Enabled = false;
                _contratos = await ApiService.Instance.GetAllContractsAsync();
                btnRefrescar.Enabled = true;

                dgvContratos.Rows.Clear();
                btnSeleccionar.Enabled = false;

                foreach (var c in _contratos)
                {
                    dgvContratos.Rows.Add(
                        c.ContractNumber,
                        c.TotalValue,
                        c.DurationMonths,
                        c.Status,
                        c.SignedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                        c.ManufacturerId);
                }
                lblConteo.Text = $"{_contratos.Count} contrato(s) — seleccione uno y confirme";
                btnSeleccionar.Enabled = _contratos.Count > 0;
            }
            catch (Exception ex)
            {
                btnRefrescar.Enabled = true;
                MessageBox.Show($"Error al cargar contratos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e) => LoadAll();

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvContratos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un contrato de la lista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvContratos.SelectedRows[0].Index;
            if (rowIndex < 0 || rowIndex >= _contratos.Count) return;

            SelectedContract = _contratos[rowIndex];
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
