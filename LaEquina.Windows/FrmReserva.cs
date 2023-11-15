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
    public partial class FrmReserva : Form
    {
        private readonly IServiciosReserva _servicio;
        private readonly IServiciosTurno _serviciosTurno;
        private readonly IServiciosCanchas _serviciosCancha;
        private readonly IServiciosMiembros _serviciosMiembro;
        private readonly IServiciosFechas _serviciosFecha;
        private List<ReservaDTO> lista;

        //Para paginación
        int paginaActual = 1;
        int registros = 0;
        int paginas = 0;
        int registrosPorPagina = 12;

        int? FechaFiltro = null;

        public FrmReserva()
        {
            InitializeComponent();
            _servicio = new ServiciosReserva();
            _serviciosTurno = new ServiciosTurno();
            _serviciosCancha = new ServiciosCanchas();
            _serviciosMiembro = new ServiciosMiembros();
            _serviciosFecha = new ServiciosFechas();
        }
        private void FrmReserva_Load(object sender, EventArgs e)
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
            {
                lista = _servicio.GetReservaPorPagina(registrosPorPagina, paginaActual, FechaFiltro);
                MostrarDatosEnGrilla();
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            foreach (var reserva in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
                GridHelper.SetearFila(r, reserva);
                GridHelper.AgregarFila(dataGridView1, r);
            }
            lblRegistros.Text = registros.ToString();
            lblPaginaActual.Text = paginaActual.ToString();
            lblPaginas.Text = paginas.ToString();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmReservaAE frm = new FrmReservaAE(_servicio) { Text = "Agregar Reserva" };
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
            ReservaDTO reservaDTO = (ReservaDTO)r.Tag;
            try
            {
                //TODO: Se debe controlar que no este relacionado
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                Reserva reserva = _servicio.GetReservaPorId(reservaDTO.IdReservas);
                if (!_servicio.EstaRelacionada(reserva))
                {
                    _servicio.Borrar(reserva.IdReserva);
                    GridHelper.QuitarFila(dataGridView1, r);
                    registros = _servicio.GetCantidad(null);
                    paginas = FromHelper.CalcularPaginas(registros, registrosPorPagina);
                    lblRegistros.Text = registros.ToString();
                    lblPaginas.Text = paginas.ToString();
                    
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
            ReservaDTO ReservaDto = (ReservaDTO)r.Tag;
            ReservaDTO ReservaDtoCopia = (ReservaDTO)ReservaDto.Clone();
            //Traer el objeto Ciudad
            Reserva reserva = _servicio.GetReservaPorId(ReservaDto.IdReservas);
            try
            {
                FrmReservaAE frm = new FrmReservaAE(_servicio) { Text = "Editar Torneo" };
                frm.SetReserva(reserva);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    GridHelper.SetearFila(r, ReservaDtoCopia);

                    return;
                }
                reserva = frm.GetReserva();
                if (reserva != null)
                {
                    //Crear el dto
                    ReservaDto.IdReservas = reserva.IdReserva;
                    ReservaDto.Horario = (_serviciosTurno.GetTurnoPorId(reserva.IdTurnos)).Horario;
                    ReservaDto.NombreCancha = (_serviciosCancha.GetCanchasPorId(reserva.IdCanchas)).Nombre;
                    ReservaDto.NombreMiembro = (_serviciosMiembro.GetMiembroPorId(reserva.IdMiembros)).Nombre;
                    ReservaDto.Dia = (_serviciosFecha.GetFechasPorId(reserva.IdFechas)).Dia;

                    GridHelper.SetearFila(r, ReservaDto);
                }


                else
                {
                    //Recupero la copia del dto
                    GridHelper.SetearFila(r, ReservaDtoCopia);

                }
            }

            catch (Exception ex)
            {
                GridHelper.SetearFila(r, ReservaDtoCopia);
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            tsbBuscar.BackColor = Color.White;
            FechaFiltro = null;
            RecargarGrilla();
        }












        ////private void tsbNuevo_Click(object sender, EventArgs e)
        ////{
        ////    frmPaisAE frm = new frmPaisAE(_servicio) { Text = "Agregar país" };
        ////    DialogResult dr = frm.ShowDialog(this);
        ////    RecargarGrilla();
        ////}

        //private void RecargarGrilla()
        //{
        //    try
        //    {
        //        //registros = _servicio.GetCantidad(null);
        //        paginas = FromHelper.CalcularPaginas(registros, registrosPorPagina);
        //        MostrarPaginado();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        ////private void tsbBorrar_Click(object sender, EventArgs e)
        ////{
        ////    if (dataGridView1.SelectedRows.Count == 0)
        ////    {
        ////        return;
        ////    }
        ////    var r = dataGridView1.SelectedRows[0];
        ////    Pais pais = (Pais)r.Tag;
        ////    try
        ////    {
        ////        //TODO: Se debe controlar que no este relacionado
        ////        DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
        ////            "Confirmar",
        ////            MessageBoxButtons.YesNo,
        ////            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        ////        if (dr == DialogResult.No) { return; }
        ////        _servicio.Borrar(pais.PaisId);
        ////        GridHelper.QuitarFila(dataGridView1, r);
        ////        //lblCantidad.Text = _servicio.GetCantidad().ToString();
        ////        MessageBox.Show("Registro borrado", "Mensaje",
        ////            MessageBoxButtons.OK, MessageBoxIcon.Information);
        ////    }
        ////    catch (Exception ex)
        ////    {

        ////        MessageBox.Show(ex.Message, "Error",
        ////            MessageBoxButtons.OK, MessageBoxIcon.Error);

        ////    }
        ////}


        ////private void tsbEditar_Click(object sender, EventArgs e)
        ////{
        ////    if (dataGridView1.SelectedRows.Count == 0)
        ////    {
        ////        return;
        ////    }
        ////    var r = dataGridView1.SelectedRows[0];
        ////    Pais pais = (Pais)r.Tag;
        ////    Pais paisCopia = (Pais)pais.Clone();
        ////    try
        ////    {
        ////        frmPaisAE frm = new frmPaisAE(_servicio) { Text = "Editar País" };
        ////        frm.SetPais(pais);
        ////        DialogResult dr = frm.ShowDialog(this);
        ////        if (dr == DialogResult.Cancel)
        ////        {
        ////            GridHelper.SetearFila(r, paisCopia);

        ////            return;
        ////        }
        ////        pais = frm.GetPais();
        ////        if (pais != null)
        ////        {
        ////            GridHelper.SetearFila(r, pais);

        ////        }
        ////        else
        ////        {
        ////            GridHelper.SetearFila(r, paisCopia);

        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        GridHelper.SetearFila(r, paisCopia);
        ////        MessageBox.Show(ex.Message, "Error",
        ////            MessageBoxButtons.OK, MessageBoxIcon.Error);

        ////    }

        ////}

        //private void btnSiguiente_Click(object sender, EventArgs e)
        //{
        //    if (paginaActual == paginas)
        //    {
        //        return;
        //    }
        //    paginaActual++;
        //    MostrarPaginado();
        //}

        //private void btnAnterior_Click(object sender, EventArgs e)
        //{
        //    if (paginaActual == 1)
        //    {
        //        return;
        //    }
        //    paginaActual--;
        //    MostrarPaginado();
        //}

        //private void btnUltimo_Click(object sender, EventArgs e)
        //{

        //    paginaActual = paginas;
        //    MostrarPaginado();
        //}



        //private void btnPrimero_Click(object sender, EventArgs e)
        //{
        //    paginaActual = 1;
        //    MostrarPaginado();
        //}

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

        //private void tsbActualizar_Click(object sender, EventArgs e)
        //{
        //    filtroOn = false;
        //    tsbBuscar.BackColor = Color.White;
        //    textoFiltro = null;
        //    RecargarGrilla();

        //}
    }
}

