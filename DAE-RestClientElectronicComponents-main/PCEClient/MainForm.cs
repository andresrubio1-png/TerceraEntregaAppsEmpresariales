using System;
using System.Windows.Forms;
using PCEClient.Forms;

namespace PCEClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowChildForm(Form childForm)
        {
            childForm.Show();
            childForm.Focus();
        }

        // ── Archivo ────────────────────────────────────────────────────────
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        // ── Fabricante ─────────────────────────────────────────────────────
        private void crearFabricanteToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new CrearFabricanteForm());

        private void buscarFabricanteToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new BuscarFabricanteForm());

        private void buscarFabricantePorNombreToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new BuscarFabricantePorNombreForm());

        private void eliminarFabricanteToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new EliminarFabricanteForm());

        private void actualizarFabricanteToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new ActualizarFabricanteForm());

        private void listarFabricantesToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new ListarFabricantesForm());

        // ── Componente Pasivo ──────────────────────────────────────────────
        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new CrearComponenteForm());

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new BuscarComponenteForm());

        private void buscarPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new BuscarComponentePorNombreForm());

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var selector = new SeleccionarComponentePorNombreForm("Seleccionar Componente a Eliminar"))
            {
                if (selector.ShowDialog(this) == DialogResult.OK && selector.SelectedComponent != null)
                    ShowChildForm(new EliminarComponenteForm(selector.SelectedComponent));
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var selector = new SeleccionarComponentePorNombreForm("Seleccionar Componente a Actualizar"))
            {
                if (selector.ShowDialog(this) == DialogResult.OK && selector.SelectedComponent != null)
                    ShowChildForm(new ActualizarComponenteForm(selector.SelectedComponent));
            }
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new ListarComponentesForm());

        private void listarPorFiltroToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new ListarPorFiltroForm());

        // ── Contratos ──────────────────────────────────────────────────────
        private void crearContratoToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new CrearContratoForm());

        private void buscarContratoToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new BuscarContratoForm());

        private void listarContratosToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new ListarContratosForm());

        private void listarContratosPorFiltroToolStripMenuItem_Click(object sender, EventArgs e)
            => ShowChildForm(new ListarContratosPorFiltroForm());

        private void actualizarContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var selector = new SeleccionarContratoForm("Seleccionar Contrato a Actualizar"))
            {
                if (selector.ShowDialog(this) == DialogResult.OK && selector.SelectedContract != null)
                    ShowChildForm(new ActualizarContratoForm(selector.SelectedContract));
            }
        }

        private void eliminarContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var selector = new SeleccionarContratoForm("Seleccionar Contrato a Eliminar"))
            {
                if (selector.ShowDialog(this) == DialogResult.OK && selector.SelectedContract != null)
                    ShowChildForm(new EliminarContratoForm(selector.SelectedContract));
            }
        }

        // ── Ayuda ──────────────────────────────────────────────────────────
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var f = new AcercaDeForm()) f.ShowDialog(this);
        }
    }
}
