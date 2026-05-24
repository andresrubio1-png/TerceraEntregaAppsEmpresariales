using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PCEClient.Models;
using PCEClient.Services;

namespace PCEClient.Forms
{
    public partial class ListarContratosPorFiltroForm : Form, ISupplyContractObserver
    {
        public ListarContratosPorFiltroForm()
        {
            InitializeComponent();
            cboStatus.DataSource = Enum.GetValues(typeof(ContractStatus));
            SupplyContractEventManager.Instance.Subscribe(this);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SupplyContractEventManager.Instance.Unsubscribe(this);
            base.OnFormClosed(e);
        }

        public void OnContractsChanged()
        {
            if (InvokeRequired) { Invoke(new Action(OnContractsChanged)); return; }
            AplicarFiltro();
        }

        private void btnFiltrar_Click(object sender, EventArgs e) => AplicarFiltro();

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            txtManufacturerId.Enabled = rbManufacturer.Checked;
            cboStatus.Enabled         = rbStatus.Checked;
            txtMinValue.Enabled       = rbValueRange.Checked;
            txtMaxValue.Enabled       = rbValueRange.Checked;
        }

        private async void AplicarFiltro()
        {
            try
            {
                btnFiltrar.Enabled = false;
                List<SupplyContract> results;

                if (rbManufacturer.Checked)
                {
                    if (!int.TryParse(txtManufacturerId.Text, out int mid))
                    { btnFiltrar.Enabled = true; MessageBox.Show("ID de fabricante inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    results = await ApiService.Instance.GetAllContractsAsync(manufacturerId: mid);
                }
                else if (rbStatus.Checked)
                {
                    var st = (ContractStatus)cboStatus.SelectedItem;
                    results = await ApiService.Instance.GetAllContractsAsync(status: st);
                }
                else
                {
                    if (!double.TryParse(txtMinValue.Text, out double min) ||
                        !double.TryParse(txtMaxValue.Text, out double max))
                    { btnFiltrar.Enabled = true; MessageBox.Show("Rango de valor inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    results = await ApiService.Instance.GetAllContractsAsync(minValue: min, maxValue: max);
                }

                btnFiltrar.Enabled = true;
                LoadResults(results);
            }
            catch (Exception ex)
            {
                btnFiltrar.Enabled = true;
                MessageBox.Show($"Error al filtrar:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadResults(List<SupplyContract> results)
        {
            dgvResultados.Rows.Clear();
            foreach (var c in results)
            {
                dgvResultados.Rows.Add(
                    c.ContractNumber,
                    c.TotalValue,
                    c.DurationMonths,
                    c.Status,
                    c.SignedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    c.ManufacturerId,
                    c.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            lblCount.Text = $"Total: {results.Count}";
        }
    }
}
