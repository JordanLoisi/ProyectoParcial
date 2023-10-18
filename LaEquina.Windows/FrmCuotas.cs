using LaEquina.Windows.Helper;
using LaEsquina.Entidades;
using LaEsquina.servicios.Interfaces;
using LaEsquina.servicios.Servicios;
using Microsoft.Win32;
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
    public partial class FrmCuotas : Form
    {
        public FrmCuotas()
        {
            InitializeComponent();
            _servicios = new ServiciosCuotas();
        }

        private readonly IServiciosCuotas _servicios;
        private List<Cuotas> lista;


        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;

        bool filtroOn = false;
        string textoFiltro = null;
        private void FrmCuotas_Load(object sender, EventArgs e)
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
            lista = _servicios.GetCuotasPorPagina(registrosPorPagina, paginaActual);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            foreach (var cuotas in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, cuotas);
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            {
                FrmCuotasAE frm = new FrmCuotasAE(_servicios) { Text = "Agregar Cuotas" };
                DialogResult dr = frm.ShowDialog(this);
                RecargarGrilla();
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            Cuotas cuotas = (Cuotas)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _servicios.Borrar(cuotas.IdCuotas);
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
            Cuotas cuotas = (Cuotas)r.Tag;
            Cuotas cuotasCopia = (Cuotas)cuotas.Clone();
            try
            {
                FrmCuotasAE frm = new FrmCuotasAE(_servicios) { Text = "Editar Cuotas" };
                frm.SetCuotas(cuotas);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, cuotasCopia);

                    return;
                }
                cuotas = frm.GetCuotas();
                if (cuotas != null)
                {
                    GridHelper.SetearFila(r, cuotas);

                }
                else
                {
                    GridHelper.SetearFila(r, cuotasCopia);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, cuotasCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

