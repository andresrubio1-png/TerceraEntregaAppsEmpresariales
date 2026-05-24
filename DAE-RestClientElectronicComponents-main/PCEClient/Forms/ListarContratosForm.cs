using System;
using System.Windows.Forms;
using PCEClient.Services;

namespace PCEClient.Forms
{
    public partial class ListarContratosForm : Form, ISupplyContractObserver
    {
        public ListarContratosForm()
        {
            InitializeComponent();
            SupplyContractEventManager.Instance.Subscribe(this);
            LoadData();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SupplyContractEventManager.Instance.Unsubscribe(this);
            base.OnFormClosed(e);
        }

        public void OnContractsChanged()
        {
            if (InvokeRequired) { Invoke(new Action(OnContractsChanged)); return; }
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var list = await ApiService.Instance.GetAllContractsAsync();
                dgvContratos.Rows.Clear();
                foreach (var c in list)
                {
                    dgvContratos.Rows.Add(
                        c.ContractNumber,
                        c.TotalValue,
                        c.DurationMonths,
                        c.Status,
                        c.SignedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                        c.ManufacturerId,
                        c.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                lblCount.Text = $"Total: {list.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar contratos:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e) => LoadData();
    }
}
