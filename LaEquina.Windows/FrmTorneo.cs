using LaEquina.Windows.Helper;
using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using LaEsquina.servicios.Interfaces;
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
    public partial class FrmTorneo : Form
    {
        private readonly IServiciosTorneo _servicio;
        private readonly IServiciosCategorias _serviciosCategorias;
        private List<TorneoDTO> lista;

        //Para paginación
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;

        int? CategoriaFiltro = null;

        public FrmTorneo()
        {
            InitializeComponent();
            _servicio = new ServiciosTorneo();
            _serviciosCategorias = new ServiciosCategorias();
        }


        private void FrmTorneo_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }


       

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            foreach (var torneo in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, torneo);
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
                registros = _servicio.GetCantidad(null);
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
            lista = _servicio.GetTorneoPorPagina(registrosPorPagina, paginaActual, CategoriaFiltro);
            MostrarDatosEnGrilla();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            //frmSeleccionarCategoria frm = new frmSeleccionarPais() { Text = "Seleccionar País" };
            //DialogResult dr = frm.ShowDialog(this);
            //if (dr == DialogResult.Cancel)
            //{
            //    return;
            //}
            //try
            //{
            //    var pais = frm.GetPais();
            //    paisFiltro = pais.PaisId;
            //    lista = _servicio.GetCiudades(pais.PaisId);
            //    tsbBuscar.BackColor = Color.Orange;
            //    registros = _servicio.GetCantidad(pais.PaisId);
            //    paginas = FormHelper.CalcularPaginas(registros, registrosPorPagina);

            //    MostrarDatosEnGrilla();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        

        private void tsbCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            FrmTorneoAE frm = new FrmTorneoAE(_servicio) { Text = "Agregar país" };
            DialogResult dr = frm.ShowDialog(this);
            RecargarGrilla();
        }

        private void tsbBorrar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            TorneoDTO torneo = (TorneoDTO)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                Torneo torneo1 = _servicio.GetTorneoPorId(torneo.IdTorneo);
                if (!_servicio.EstaRelacionada(torneo1))
                {
                    _servicio.Borrar(torneo.IdTorneo);
                    GridHelper.QuitarFila(dataGridView1, r);
                    registros = _servicio.GetCantidad(null);
                    paginas = FromHelper.CalcularPaginas(registros, registrosPorPagina);
                    lblRegistros.Text = registros.ToString();
                    lblPaginas.Text = paginas.ToString();
                    //lblCantidad.Text = _servicio.GetCantidad().ToString();
                    MessageBox.Show("Registro borrado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Torneo Relacionada!!!", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            TorneoDTO torneoDto = (TorneoDTO)r.Tag;
            TorneoDTO TorneoDtoCopia = (TorneoDTO)torneoDto.Clone();
            //Traer el objeto Ciudad
            Torneo torneo1 = _servicio.GetTorneoPorId(torneoDto.IdTorneo);
            try
            {
                FrmTorneoAE frm = new FrmTorneoAE(_servicio) { Text = "Editar Torneo" };
                frm.SetTorneo(torneo1);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, TorneoDtoCopia);

                    return;
                }
                torneo1 = frm.GetTorneo();
                if (torneo1 != null)
                {
                    //Crear el dto
                    torneoDto.IdTorneo = torneo1.IdTorneo;
                    torneoDto.FechaInicio = torneo1.FechaInicio;
                    torneoDto.FechaFin = torneo1.FechaFin;
                    torneoDto.NombreCategoria = (_serviciosCategorias.GetCategoriasPorId(torneo1.IdCategoria)).NombreCategoria;

                    GridHelper.SetearFila(r, torneoDto);
                }


                else
                {
                    //Recupero la copia del dto
                    GridHelper.SetearFila(r, TorneoDtoCopia);

                }
            }

            catch (Exception ex)
            {
                GridHelper.SetearFila(r, TorneoDtoCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbActualizar_Click_1(object sender, EventArgs e)
        {
            tsbBuscar.BackColor = Color.White;
            CategoriaFiltro = null;
            RecargarGrilla();
        }
    }
}

