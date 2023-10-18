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
    public partial class FrmTurno : Form
    {
        private readonly ServiciosTurno _servicios;
        private List<Turno> lista;

        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;
        private void FrmTurno_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            try
            {
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
            lista = _servicios.GetTurnoPorPagina(registrosPorPagina, paginaActual);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            foreach (var turno in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, turno );
                GridHelper.AgregarFila(dataGridView1, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
        }

        public FrmTurno()
        {
            InitializeComponent();
            _servicios = new ServiciosTurno();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmTurnoAE frm = new FrmTurnoAE(_servicios) { Text = "Agregar país" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }










        ////private void tsbBorrar_Click(object sender, EventArgs e)
        ////{
        ////}


        ////private void tsbEditar_Click(object sender, EventArgs e)
        ////{
        

        ////}

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

        private void tsbBorrar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            Turno turno = (Turno)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _servicios.Borrar(turno.IdTurnos);
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
            Turno turno = (Turno)r.Tag;
            Turno turnoCopia = (Turno)turno.Clone();
            try
            {
                FrmTurnoAE frm = new FrmTurnoAE(_servicios) { Text = "Editar País" };
                frm.SetTurno(turno);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, turnoCopia);

                    return;
                }
                turno = frm.GetTurno();
                if (turno != null)
                {
                    GridHelper.SetearFila(r, turno);

                }
                else
                {
                    GridHelper.SetearFila(r, turnoCopia);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, turnoCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}




