using LaEquina.Windows.Helper;
using LaEsquina.Entidades;
using LaEsquina.servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LaEquina.Windows
{
    public partial class FrmEquipos : Form
    {
        private readonly ServiciosEquipos _servicios;
        private List<Equipos> lista;

        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;
        private void FrmEquipos_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        public FrmEquipos()
        {
            InitializeComponent();
            _servicios = new ServiciosEquipos();
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

        private void MostrarPaginado()
        {
            lista = _servicios.GetEquiposPorPagina(registrosPorPagina, paginaActual);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            foreach (var equipos in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, equipos);
                GridHelper.AgregarFila(dataGridView1, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
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



        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmEquiposAE frm = new FrmEquiposAE(_servicios) { Text = "Agregar Equipos" };
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
            Equipos equipos = (Equipos)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _servicios.Borrar(equipos.IdEquipos);
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
            Equipos equipos = (Equipos)r.Tag;
            Equipos equiposCopia = (Equipos)equipos.Clone();
            try
            {
                FrmEquiposAE frm = new FrmEquiposAE(_servicios) { Text = "Editar EQUIPO" };
                frm.SetEquipos(equipos);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, equiposCopia);

                    return;
                }
                equipos = frm.GetEquipos();
                if (equipos != null)
                {
                    GridHelper.SetearFila(r, equipos);

                }
                else
                {
                    GridHelper.SetearFila(r, equiposCopia);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, equiposCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

