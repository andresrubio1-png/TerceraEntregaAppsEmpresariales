using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PCEClient.Models;
using PCEClient.Services;

namespace PCEClient.Forms
{
    public partial class ActualizarContratoForm : Form, IManufacturerObserver
    {
        private SupplyContract _contrato;
        private int? _selectedManufacturerId = null;

        public ActualizarContratoForm(SupplyContract contrato)
        {
            InitializeComponent();
            cboStatus.DataSource = Enum.GetValues(typeof(ContractStatus));
            dtpSignedAt.Format = DateTimePickerFormat.Custom;
            dtpSignedAt.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            ManufacturerEventManager.Instance.Subscribe(this);

            _contrato = contrato ?? throw new ArgumentNullException(nameof(contrato));

            lblContrato.Text = $"Editando contrato {_contrato.ContractNumber}";
            LoadFields(_contrato);
            LoadManufacturers(_contrato.ManufacturerId);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ManufacturerEventManager.Instance.Unsubscribe(this);
            base.OnFormClosed(e);
        }

        public void OnManufacturersChanged()
        {
            if (InvokeRequired) { Invoke(new Action(OnManufacturersChanged)); return; }
            LoadManufacturers(_selectedManufacturerId);
        }

        private async void LoadManufacturers(int? preSelectId = null)
        {
            try
            {
                List<Manufacturer> list = await ApiService.Instance.GetAllManufacturersAsync();
                dgvFabricantes.Rows.Clear();
                _selectedManufacturerId = null;
                lblFabSeleccionado.Text = "Ninguno seleccionado";

                foreach (var m in list)
                {
                    int rowIdx = dgvFabricantes.Rows.Add(m.Id, m.Name, m.Country, m.AverageLeadTime);
                    if (preSelectId.HasValue && m.Id == preSelectId.Value)
                    {
                        dgvFabricantes.Rows[rowIdx].Selected = true;
                        _selectedManufacturerId = m.Id;
                        lblFabSeleccionado.Text = $"✔ {m.Name} ({m.Country})";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar fabricantes:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFabricantes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFabricantes.SelectedRows.Count == 0)
            {
                _selectedManufacturerId = null;
                lblFabSeleccionado.Text = "Ninguno seleccionado";
            }
            else
            {
                var row = dgvFabricantes.SelectedRows[0];
                _selectedManufacturerId = (int)row.Cells["colFabId"].Value;
                lblFabSeleccionado.Text = $"✔ {row.Cells["colFabName"].Value} ({row.Cells["colFabCountry"].Value})";
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_contrato == null) return;
            if (!ValidateFields()) return;

            var confirm = MessageBox.Show(
                $"¿Confirma actualizar el contrato {_contrato.ContractNumber}?",
                "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var request = new SupplyContractRequest
                {
                    ContractNumber = _contrato.ContractNumber,
                    TotalValue     = double.Parse(txtTotalValue.Text),
                    DurationMonths = int.Parse(txtDurationMonths.Text),
                    Status         = (ContractStatus)cboStatus.SelectedItem,
                    SignedAt       = dtpSignedAt.Value,
                    ManufacturerId = _selectedManufacturerId.Value
                };

                btnActualizar.Enabled = false;
                var updated = await ApiService.Instance.UpdateContractAsync(_contrato.ContractNumber, request);
                btnActualizar.Enabled = true;

                if (updated != null)
                {
                    MessageBox.Show("Contrato actualizado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SupplyContractEventManager.Instance.NotifyAll();
                    _contrato = updated;
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el contrato.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                btnActualizar.Enabled = true;
                MessageBox.Show($"Error al actualizar:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFields(SupplyContract c)
        {
            txtTotalValue.Text     = c.TotalValue.ToString();
            txtDurationMonths.Text = c.DurationMonths.ToString();
            cboStatus.SelectedItem = c.Status;
            dtpSignedAt.Value = c.SignedAt;
        }

        private bool ValidateFields()
        {
            if (!_selectedManufacturerId.HasValue)
            { MessageBox.Show("Debe seleccionar un fabricante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!double.TryParse(txtTotalValue.Text, out double tv) || tv <= 0)
            { MessageBox.Show("Valor total debe ser un número mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!int.TryParse(txtDurationMonths.Text, out int dm) || dm <= 0 || dm > 120)
            { MessageBox.Show("Duración debe ser un entero entre 1 y 120 meses.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (dtpSignedAt.Value > DateTime.Now)
            { MessageBox.Show("La fecha de firma no puede ser futura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return true;
        }
    }
}
