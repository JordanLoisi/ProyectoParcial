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
    public partial class FrmPartidos : Form
    {
        private readonly IServiciosPartidos _servicio;
        private readonly IServiciosEquipos _serviciosEquipos;
        private readonly IServiciosRondas _serviciosRondas;
        private readonly IServiciosTorneo _serviciosTorneo;
        private readonly IServiciosCategorias _serviciosCategorias;
        
        private List<PartidosDTO> lista;

        //Para paginación
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;

        int? TorneoFiltro = null;
        private void FrmPartidos_Load(object sender, EventArgs e)
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
            lista = _servicio.GetPartidosPorPagina(registrosPorPagina, paginaActual, TorneoFiltro);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            foreach (var partidos in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, partidos);
                GridHelper.AgregarFila(dataGridView1, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
        }

        public FrmPartidos()
        {
            InitializeComponent();
            _servicio = new ServiciosPartidos();
            _serviciosEquipos = new ServiciosEquipos();
            _serviciosRondas = new ServiciosRondas();
            _serviciosTorneo = new ServiciosTorneo();
            _serviciosCategorias = new ServiciosCategorias(); 

            
            
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
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
            FrmPartidosAE frm = new FrmPartidosAE(_servicio) { Text = "Agregar Partidos" };
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
            PartidosDTO PartidosDTO = (PartidosDTO)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                Partidos partidos = _servicio.GetPartidosPorId(PartidosDTO.IdPartidos);
                if (!_servicio.EstaRelacionada(partidos))
                {
                    _servicio.Borrar(partidos.IdPartidos);
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
            PartidosDTO PartidosDto = (PartidosDTO)r.Tag;
            PartidosDTO PartidosDtoCopia = (PartidosDTO)PartidosDto.Clone();
            //Traer el objeto Ciudad
            Partidos partidos = _servicio.GetPartidosPorId(PartidosDto.IdPartidos);
            try
            {
                FrmPartidosAE frm = new FrmPartidosAE(_servicio) { Text = "Editar Torneo" };
                frm.SetPartidos(partidos);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, PartidosDtoCopia);

                    return;
                }
                partidos = frm.GetPartidos();
                if (partidos != null)
                {
                    //Crear el dto
                    PartidosDto.NombreEquipo_A = (_serviciosEquipos.GetEquiposPorId(partidos.IdEquipo_A)).NombreEquipos;
                    PartidosDto.IdPartidos = partidos.IdPartidos;
                    PartidosDto.NombreEquipo_B = (_serviciosEquipos.GetEquiposPorId(partidos.IdEquipo_B)).NombreEquipos;
                    PartidosDto.NombreDeRondas = (_serviciosRondas.GetRondasPorId(partidos.IdRondas)).NombreDeRondas;
                    PartidosDto.NombreCategoria = _serviciosCategorias.GetCategoriasPorId((_serviciosTorneo.GetTorneoPorId(partidos.IdTorneo)).IdCategoria).NombreCategoria;
                    PartidosDto.Resultado = partidos.Resultado.ToString();

                    GridHelper.SetearFila(r, PartidosDto);
                }


                else
                {
                    //Recupero la copia del dto
                    GridHelper.SetearFila(r, PartidosDtoCopia);

                }
            }

            catch (Exception ex)
            {
                GridHelper.SetearFila(r, PartidosDtoCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            tsbBuscar.BackColor = Color.White;
            TorneoFiltro = null;
            RecargarGrilla();
        }

        ////private void tsbBuscar_Click(object sender, EventArgs e)
        ////{
        ////    if (!filtroOn)
        ////    {
        ////        frmBuscarPorNombre frm = new frmBuscarPorNombre() { Text = "Buscar por Nombre de País" };
        ////        DialogResult dr = frm.ShowDialog(this);
        ////        if (dr == DialogResult.Cancel)
        ////        {
        ////            return;
        ////        }
        ////        try
        ////        {
        ////            textoFiltro = frm.GetTexto();
        ////            tsbBuscar.BackColor = Color.Orange;
        ////            filtroOn = true;
        ////            lista = _servicio.GetPaises(textoFiltro);
        ////            registros = _servicio.GetCantidad(textoFiltro);
        ////            paginas = FormHelper.CalcularPaginas(registros, registrosPorPagina);
        ////            MostrarDatosEnGrilla();
        ////        }
        ////        catch (Exception)
        ////        {

        ////            throw;
        ////        }

        ////    }
        ////    else
        ////    {
        ////        MessageBox.Show("Quite el filtro activo!!!", "Advertencia",
        ////            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        ////    }
        ////}

      
    }
}

