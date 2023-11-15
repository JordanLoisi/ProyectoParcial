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
    public partial class FrmMiembrosAE : Form
    {

        private IServiciosMiembros _servicio;
        public FrmMiembrosAE(IServiciosMiembros servicio)
        {
            _servicio = servicio;
            InitializeComponent();
        }
        private Miembro miembro;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ComboHelpers.CargarComboEquipos(ref cboEquipos);
            if (miembro != null)
            {
                txtNombre.Text = miembro.Nombre;
                txtApellido.Text = miembro.Apellido;
                cboEquipos.SelectedValue = miembro.IdEquipos;
                esEdicion = true;
            }
        }
        public FrmMiembrosAE()
        {
            InitializeComponent();
        }

        private void FrmMiembrosAE_Load(object sender, EventArgs e)
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
                if (miembro == null)
                {
                    miembro = new Miembro();
                }
                miembro.Nombre = txtNombre.Text;
                miembro.Apellido = txtApellido.Text;
                miembro.Equipos = (Equipos)cboEquipos.SelectedItem;
                miembro.IdEquipos = (int)cboEquipos.SelectedValue;

                try
                {

                    if (!_servicio.Existe(miembro))
                    {
                        _servicio.Guardar(miembro);

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
                            miembro = null;
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
                        miembro = null;
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboEquipos.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboEquipos, "Debe seleccionar un Equipo");
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "El nombre es requerido");
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "El Apellido es requerido");
            }

            return valido;
        }

        private void InicializarControles()
        {
            cboEquipos.SelectedIndex = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtApellido.Focus();
            txtNombre.Focus();
            cboEquipos.Focus();
        }
        public Miembro GetMiembro()
        {
            return miembro;
        }

        public void SetMiembro(Miembro miembro)
        {
            this.miembro=miembro;
        }

        private void btnAgregarEquipos_Click(object sender, EventArgs e)
        {
            var _servicioEquipos = new ServiciosEquipos();
            FrmEquiposAE frm = new FrmEquiposAE(_servicioEquipos) { Text = "Agregar Equipo" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                var equipo = frm.GetEquipos();
                if (!_servicioEquipos.Existe(equipo))
                {
                    _servicioEquipos.Guardar(equipo);
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
            ComboHelpers.CargarComboEquipos(ref cboEquipos);
        }
    }
}
