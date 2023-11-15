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
    public partial class FrmPartidosAE : Form
    {
        private IServiciosPartidos _servicio;
        public FrmPartidosAE(IServiciosPartidos servicio)
        {
            _servicio = servicio;
            InitializeComponent();
        }
        private Partidos partidos;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelpers.CargarComboEquipos(ref cboEquipo);
            ComboHelpers.CargarComboEquipos(ref cboEquipoB);
            ComboHelpers.CargarComboRondas(ref cboRondas);
            ComboHelpers.CargarComboTorneo(ref cboTorneo);

            if (partidos != null)
            {
                cboEquipo.SelectedValue = partidos.IdEquipo_A;
                cboEquipoB.SelectedValue = partidos.IdEquipo_B;
                cboRondas.SelectedValue = partidos.IdRondas;
                cboTorneo.SelectedValue = partidos.IdTorneo;
                     txtResultado.Text = partidos.Resultado.ToString(); 
                esEdicion = true;
            }
        }

        private void FrmPartidosAE_Load(object sender, EventArgs e)
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
                if (partidos == null)
                {
                    partidos = new Partidos();
                }
                partidos.Resultado = txtResultado.Text;

                partidos.equipos = (Equipos)cboEquipo.SelectedItem;
                partidos.IdEquipo_A = (int)cboEquipo.SelectedValue;

                partidos.equipos = (Equipos)cboEquipo.SelectedItem;
                partidos.IdEquipo_B = (int)cboEquipo.SelectedValue;

                partidos.rondas = (Rondas)cboRondas.SelectedItem;
                partidos.IdRondas = (int)cboRondas.SelectedValue;

                partidos.torneo = (Torneo)cboTorneo.SelectedItem;
                partidos.IdTorneo = (int)cboTorneo.SelectedValue;

                try
                {

                    if (!_servicio.Existe(partidos))
                    {
                        _servicio.Guardar(partidos);

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
                            partidos = null;
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
                        partidos = null;
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
            cboEquipo.SelectedIndex = 0;
            cboRondas.SelectedIndex = 0;
            cboTorneo.SelectedIndex = 0;
           

            cboEquipo.Focus();
            cboRondas.Focus();
            cboTorneo.Focus();
           
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboEquipo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboEquipo, "Debe seleccionar un Equipo");
            }
            if (cboRondas.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboRondas, "Debe seleccionar un Rondas");
            }
            if (cboTorneo.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTorneo, "Debe seleccionar un Equipo");
            }
            return valido;
        }
        public Partidos GetPartidos()
        {
            return partidos;
        }

        public void SetPartidos(Partidos partidos)
        {
            this.partidos=partidos;
        }

        private void btnAgregarEquipoA_Click(object sender, EventArgs e)
        {
            var _servicioEquipo= new ServiciosEquipos();
            FrmEquiposAE frm = new FrmEquiposAE(_servicioEquipo) { Text = "Agregar Equipo" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                var equipos = frm.GetEquipos();
                if (!_servicioEquipo.Existe(equipos))
                {
                    _servicioEquipo.Guardar(equipos);
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
            ComboHelpers.CargarComboEquipos(ref cboEquipo);
        }

        private void btnArgregarEquipoB_Click(object sender, EventArgs e)
        {
            var _servicioEquipo = new ServiciosEquipos();
            FrmEquiposAE frm = new FrmEquiposAE(_servicioEquipo) { Text = "Agregar Equipo" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                var equipos = frm.GetEquipos();
                if (!_servicioEquipo.Existe(equipos))
                {
                    _servicioEquipo.Guardar(equipos);
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
            ComboHelpers.CargarComboEquipos(ref cboEquipo);
        }

        private void BtnAgregarRondas_Click(object sender, EventArgs e)
        {
            var _servicioRondas = new ServiciosRondas();
            FrmRondasAE frm = new FrmRondasAE(_servicioRondas) { Text = "Agregar Rondas" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                var rondas = frm.GetRondas();
                if (!_servicioRondas.Existe(rondas))
                {
                    _servicioRondas.Guardar(rondas);
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
            ComboHelpers.CargarComboRondas(ref cboRondas);
        }

        private void btnAgregarTorneo_Click(object sender, EventArgs e)
        {
            var _servicioTorneo = new ServiciosTorneo();
            FrmTorneoAE frm = new FrmTorneoAE(_servicioTorneo) { Text = "Agregar Torneo" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                var torneo = frm.GetTorneo();
                if (!_servicioTorneo.Existe(torneo))
                {
                    _servicioTorneo.Guardar(torneo);
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
            ComboHelpers.CargarComboEquipos(ref cboEquipo);
        }
    }
}
