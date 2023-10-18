using LaEquina.Windows.Helper;
using LaEsquina.Entidades;
using LaEsquina.servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LaEquina.Windows
{
    public partial class FrmCanchas : Form
    {
        public FrmCanchas()
        {
            InitializeComponent();
            _servicio = new ServiciosCanchas();
        }
        private readonly ServiciosCanchas _servicio;
        private List<Canchas> lista;

        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;

        //bool filtroOn = false;
        //string textoFiltro = null;



        private void FrmCanchas_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            foreach (var canchas in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, canchas);
                GridHelper.AgregarFila(dataGridView1, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
        }

        private void RecargarGrilla()
        {
            try
            {
                //registros = _servicio.GetCantidad(null);
                paginas = FromHelper.CalcularPaginas(registros, registrosPorPagina);
                MostrarPaginado();
            }
            catch (Exception)
            {

                throw;
            }
        }



        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual == paginas)
            {
                return;
            }
            paginaActual++;
            MostrarPaginado();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual == 1)
            {
                return;
            }
            paginaActual--;
            MostrarPaginado();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {

            paginaActual = paginas;
            MostrarPaginado();
        }

        private void MostrarPaginado()
        {
            lista = _servicio.GetCanchasPorPagina(registrosPorPagina, paginaActual);
            MostrarDatosEnGrilla();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmCanchasAE frm = new FrmCanchasAE(_servicio) { Text = "Agregar cancha" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            Canchas canchas = (Canchas)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _servicio.Borrar(canchas.IdCanchas);
                GridHelper.QuitarFila(dataGridView1, r);
                //lblCantidad.Text = _servicio.GetCantidad().ToString();
                MessageBox.Show("Registro borrado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            Canchas canchas = (Canchas)r.Tag;
            Canchas canchasCopia = (Canchas)canchas.Clone();
            try
            {
                FrmCanchasAE frm = new FrmCanchasAE(_servicio) { Text = "Editar cancha" };
                frm.SetCanchas(canchas);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, canchasCopia);

                    return;
                }
                canchas = frm.GetCanchas();
                if (canchas != null)
                {
                    GridHelper.SetearFila(r, canchas);

                }
                else
                {
                    GridHelper.SetearFila(r, canchasCopia);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, canchasCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void tsbCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Clic(object sender, EventArgs e)
        {

        }
    }
}
