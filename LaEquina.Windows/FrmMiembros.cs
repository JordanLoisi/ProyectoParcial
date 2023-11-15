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
    public partial class FrmMiembros : Form
    {
        private readonly IServiciosMiembros _servicio;
        private readonly IServiciosEquipos _serviciosEquipo;
        private List<MiembroDTO> lista;

        //Para paginación
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;

        int? EquipoFiltro = null;
        
        public FrmMiembros()
        {
            InitializeComponent();
            _servicio = new ServiciosMiembros();
            _serviciosEquipo = new ServiciosEquipos();
        }

        private void FrmMiembros_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
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

        private void MostrarPaginado()
        {
            lista = _servicio.GetMiembrosPorPagina(registrosPorPagina, paginaActual, EquipoFiltro);
            MostrarDatosEnGrilla();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            foreach (var miembro in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, miembro);
                GridHelper.AgregarFila(dataGridView1, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            {
                FrmMiembrosAE frm = new FrmMiembrosAE(_servicio) { Text = "Agregar Miembros" };
                DialogResult dr = frm.ShowDialog(this);
                RecargarGrilla();
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

        private void tsbCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            MiembroDTO miembro = (MiembroDTO)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                Miembro miembro1 = _servicio.GetMiembroPorId(miembro.IdMiembros);
                if (!_servicio.EstaRelacionada(miembro1))
                {
                    _servicio.Borrar(miembro.IdMiembros);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dataGridView1.SelectedRows[0];
            MiembroDTO miembroDto = (MiembroDTO)r.Tag;
            MiembroDTO MiembroCopia = (MiembroDTO)miembroDto.Clone();
            
            Miembro miembro = _servicio.GetMiembroPorId(miembroDto.IdMiembros);
            try
            {
                    FrmMiembrosAE frm = new FrmMiembrosAE(_servicio) { Text = "Editar Miembro" };
                frm.SetMiembro(miembro);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, MiembroCopia);

                    return;
                }
                miembro = frm.GetMiembro();
                if (miembro != null)
                {
                    //Crear el dto
                    miembroDto.IdMiembros = miembro.IdMiembros;
                    miembroDto.Nombre = miembro.Nombre;
                    miembroDto.Apellido = miembro.Apellido;
                    miembroDto.NombreEquipos = (_serviciosEquipo.GetEquiposPorId(miembro.IdEquipos)).NombreEquipos;

                    GridHelper.SetearFila(r, miembroDto);
                }


                else
                {
                    //Recupero la copia del dto
                    GridHelper.SetearFila(r, MiembroCopia);

                }
                }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, MiembroCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            tsbBuscar.BackColor = Color.White;
            EquipoFiltro = null;
            RecargarGrilla();
        }

       
    }
}

