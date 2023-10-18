using LaEquina.Windows.Helper;
using LaEsquina.Entidades;
using LaEsquina.servicios.Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaEquina.Windows
{
    public partial class FrmFechas : Form
    {

        private void FrmFechas_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
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
            lista = _servicios.GetFechasPorPagina(registrosPorPagina, paginaActual);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            foreach (var fecha in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, fecha);
                GridHelper.AgregarFila(dataGridView1, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
        }

        public FrmFechas()
        {
            InitializeComponent();
            _servicios = new ServiciosFechas();
        }

        
        private readonly ServiciosFechas _servicios;
        private List<Fecha> lista;

        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmFechaAE frm = new FrmFechaAE(_servicios) { Text = "Agregar fecha" };
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
            Fecha fecha = (Fecha)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _servicios.Borrar(fecha.IdFechas);
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
                Fecha fecha = (Fecha)r.Tag;
            Fecha fechaCopia = (Fecha)fecha.Clone();
            try
            {
                FrmFechaAE frm = new FrmFechaAE(_servicios) { Text = "Editar Fecha" };
                frm.SetFechas(fecha);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, fechaCopia);

                    return;
                }
                fecha = frm.GetFecha();
                if (fecha != null)
                {
                    GridHelper.SetearFila(r, fecha);

                }
                else
                {
                    GridHelper.SetearFila(r, fechaCopia);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, fechaCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

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

     
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
        }

      
    }

}

