using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PCEClient.Models;
using PCEClient.Services;

namespace PCEClient.Forms
{
    public partial class CrearContratoForm : Form, IManufacturerObserver
    {
        private int? _selectedManufacturerId = null;

        public CrearContratoForm()
        {
            InitializeComponent();
            cboStatus.DataSource = Enum.GetValues(typeof(ContractStatus));
            dtpSignedAt.Format = DateTimePickerFormat.Custom;
            dtpSignedAt.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpSignedAt.Value = DateTime.Now;
            ManufacturerEventManager.Instance.Subscribe(this);
            LoadManufacturers();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ManufacturerEventManager.Instance.Unsubscribe(this);
            base.OnFormClosed(e);
        }

        public void OnManufacturersChanged()
        {
            if (InvokeRequired) { Invoke(new Action(OnManufacturersChanged)); return; }
            LoadManufacturers();
        }

        private async void LoadManufacturers()
        {
            try
            {
                btnRefrescarFab.Enabled = false;
                List<Manufacturer> list = await ApiService.Instance.GetAllManufacturersAsync();
                btnRefrescarFab.Enabled = true;

                dgvFabricantes.Rows.Clear();
                _selectedManufacturerId = null;
                lblFabSeleccionado.Text = "Ninguno seleccionado";
                UpdateCrearButton();

                foreach (var m in list)
                    dgvFabricantes.Rows.Add(m.Id, m.Name, m.Country, m.AverageLeadTime);
            }
            catch (Exception ex)
            {
                btnRefrescarFab.Enabled = true;
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
            UpdateCrearButton();
        }

        private void btnRefrescarFab_Click(object sender, EventArgs e) => LoadManufacturers();

        private void UpdateCrearButton() => btnCrear.Enabled = _selectedManufacturerId.HasValue;

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                var request = new SupplyContractRequest
                {
                    ContractNumber = txtContractNumber.Text.Trim(),
                    TotalValue     = double.Parse(txtTotalValue.Text),
                    DurationMonths = int.Parse(txtDurationMonths.Text),
                    Status         = (ContractStatus)cboStatus.SelectedItem,
                    SignedAt       = dtpSignedAt.Value,
                    ManufacturerId = _selectedManufacturerId.Value
                };

                btnCrear.Enabled = false;
                var created = await ApiService.Instance.CreateContractAsync(request);
                btnCrear.Enabled = _selectedManufacturerId.HasValue;

                MessageBox.Show($"Contrato creado: {created.ContractNumber}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SupplyContractEventManager.Instance.NotifyAll();
                ClearFields();
            }
            catch (Exception ex)
            {
                btnCrear.Enabled = _selectedManufacturerId.HasValue;
                MessageBox.Show($"Error al crear contrato:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateFields()
        {
            if (!_selectedManufacturerId.HasValue)
            { MessageBox.Show("Debe seleccionar un fabricante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrWhiteSpace(txtContractNumber.Text))
            { MessageBox.Show("El número de contrato no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtContractNumber.Text.Trim(), "^[A-Z0-9-]+$"))
            { MessageBox.Show("El número de contrato solo permite mayúsculas, dígitos y guiones.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (txtContractNumber.Text.Trim().Length < 3 || txtContractNumber.Text.Trim().Length > 20)
            { MessageBox.Show("El número de contrato debe tener entre 3 y 20 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!double.TryParse(txtTotalValue.Text, out double tv) || tv <= 0)
            { MessageBox.Show("Valor total debe ser un número mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (!int.TryParse(txtDurationMonths.Text, out int dm) || dm <= 0 || dm > 120)
            { MessageBox.Show("Duración debe ser un entero entre 1 y 120 meses.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (dtpSignedAt.Value > DateTime.Now)
            { MessageBox.Show("La fecha de firma no puede ser futura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return true;
        }

        private void ClearFields()
        {
            txtContractNumber.Clear();
            txtTotalValue.Clear();
            txtDurationMonths.Clear();
            cboStatus.SelectedIndex = 0;
            dtpSignedAt.Value = DateTime.Now;
        }
    }
}
