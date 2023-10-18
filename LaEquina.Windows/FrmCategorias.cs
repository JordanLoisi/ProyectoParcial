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
    public partial class FrmCategorias : Form
    {
        private readonly ServiciosCategorias _servicio;
        private List<Categorias> lista;

        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;
        private void FrmCategorias_Load(object sender, EventArgs e)
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

            lista = _servicio.GetCategoriasPorPagina(registrosPorPagina, paginaActual);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            foreach (var categoria in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, categoria);
                GridHelper.AgregarFila(dataGridView1, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
        }

        public FrmCategorias()
        {
            InitializeComponent();
            _servicio = new ServiciosCategorias();
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
            FrmCategoriasAE frm = new FrmCategoriasAE(_servicio) { Text = "Agregar Categoria" };
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
            Categorias categorias = (Categorias)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _servicio.Borrar(categorias.IdCategoria);
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
            Categorias categorias = (Categorias)r.Tag;
            Categorias CategoriasCopia = (Categorias)categorias.Clone();
            try
            {
                FrmCategoriasAE frm = new FrmCategoriasAE(_servicio) { Text = "Editar Categoria" };
                frm.SetCategorias(categorias);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, CategoriasCopia);

                    return;
                }
                categorias = frm.GetCategorias();
                if (categorias != null)
                {
                    GridHelper.SetearFila(r, categorias);

                }
                else
                {
                    GridHelper.SetearFila(r, CategoriasCopia);

                }
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, CategoriasCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

