using LaEquina.Windows.Helper;
using LaEsquina.Entidades;
using LaEsquina.servicios.Interfaces;
using LaEsquina.servicios.Servicios;
using System;
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
    public partial class FrmReservaAE : Form
    {

        private IServiciosReserva _servicio;
        public FrmReservaAE(IServiciosReserva servicio)
        {
            _servicio = servicio;
            InitializeComponent();
        }
        private Reserva reserva;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelpers.CargarComboTurno(ref cboTurno);
            ComboHelpers.CargarComboCanchas(ref cbocanchas);
            ComboHelpers.CargarComboMiembros(ref cboMiembro);
            ComboHelpers.CargarComboFechas(ref cboFecha);

            if (reserva != null)
            {
                cboTurno.SelectedValue = reserva.turno;
                cbocanchas.SelectedValue = reserva.canchas;
                cboMiembro.SelectedValue = reserva.miembro;
                cboFecha.SelectedValue = reserva.fecha;
                esEdicion = true;
            }
        }
        public FrmReservaAE()
        {
            InitializeComponent();
        }

        private void FrmReservaAE_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (reserva == null)
                {
                    reserva = new Reserva();
                }
                reserva.turno = (Turno)cboTurno.SelectedItem;
                reserva.IdTurnos = (int)cboTurno.SelectedValue;

                reserva.canchas = (Canchas)cbocanchas.SelectedItem;
                reserva.IdCanchas = (int)cbocanchas.SelectedValue;

                reserva.miembro = (Miembro)cboMiembro.SelectedItem;
                reserva.IdMiembros = (int)cboMiembro.SelectedValue;

                reserva.fecha = (Fecha)cboFecha.SelectedItem;
                reserva.IdFechas = (int)cboFecha.SelectedValue;

                try
                {

                    if (!_servicio.Existe(reserva))
                    {
                        _servicio.Guardar(reserva);

                        if (!esEdicion)
                        {
                            MessageBox.Show("Registro agregado",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?",
                                "Pregunta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.OK;

                            }
                            reserva = null;
                            InicializarControles();

                        }
                        else
                        {
                            MessageBox.Show("Registro editado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Registro duplicado",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reserva = null;
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        }

        private void InicializarControles()
        {
            cboTurno.SelectedIndex = 0;
            cbocanchas.SelectedIndex = 0;
            cboMiembro.SelectedIndex = 0;
            cboFecha.SelectedIndex = 0;

            cboFecha.Focus();
            cbocanchas.Focus();
            cboMiembro.Focus();
            cboTurno.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboTurno.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTurno, "Debe seleccionar un Equipo");
            }
            if (cbocanchas.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbocanchas, "Debe seleccionar un Equipo");
            }
            if (cboMiembro.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboMiembro, "Debe seleccionar un Equipo");
            }
            if (cboFecha.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboFecha, "Debe seleccionar un Equipo");
            }
            return valido;

        }
        public Reserva GetReserva()
        {
            return reserva;
        }

        public void SetReserva(Reserva reserva)
        {
            this.reserva = reserva;
        }

        private void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            var _servicioTurno = new ServiciosTurno();
            FrmTurnoAE frm = new FrmTurnoAE(_servicioTurno) { Text = "Agregar Turno" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                var turno = frm.GetTurno();
                if (!_servicioTurno.Existe(turno))
                {
                    _servicioTurno.Guardar(turno);
                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ComboHelpers.CargarComboTurno(ref cboTurno);
        }

        private void btnArgregarCanchas_Click(object sender, EventArgs e)
        {
            var _servicioCanchas = new ServiciosCanchas();
            FrmCanchasAE frm = new FrmCanchasAE(_servicioCanchas) { Text = "Agregar Cancha" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                var canchas = frm.GetCanchas();
                if (!_servicioCanchas.Existe(canchas))
                {
                    _servicioCanchas.Guardar(canchas);
                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ComboHelpers.CargarComboCanchas(ref cbocanchas);
        }

        private void BtnAgregarMiembro_Click(object sender, EventArgs e)
        {
            var _servicioMiembros = new ServiciosMiembros();
            FrmMiembrosAE frm = new FrmMiembrosAE(_servicioMiembros) { Text = "Agregar Miembro" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                var miembro = frm.GetMiembro();
                if (!_servicioMiembros.Existe(miembro))
                {
                    _servicioMiembros.Guardar(miembro);
                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ComboHelpers.CargarComboMiembros(ref cboMiembro);
        }

        private void btnAgregarFecha_Click(object sender, EventArgs e)
        {
            var _servicioFechas = new ServiciosFechas();
            FrmFechaAE frm = new FrmFechaAE(_servicioFechas) { Text = "Agregar Fechas" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                var fecha = frm.GetFecha();
                if (!_servicioFechas.Existe(fecha))
                {
                    _servicioFechas.Guardar(fecha);
                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro existente",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ComboHelpers.CargarComboFechas(ref cboFecha);
        }
    }
}
