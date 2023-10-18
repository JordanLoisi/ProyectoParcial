using LaEsquina.Entidades;
using LaEsquina.servicios.Interfaces;
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
    public partial class FrmEquiposAE : Form
    {
        private IServiciosEquipos _servicio;
        public FrmEquiposAE(IServiciosEquipos servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Equipos equipos;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (equipos != null)
            {
                esEdicion = true;
                txtNombreEquipos.Text = equipos.NombreEquipos.ToString();
            }
        }
        public Equipos GetEquipos()
        {
            return equipos;
        }
       
        private void FrmEquiposAE_Load(object sender, EventArgs e)
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
                if (equipos == null)
                {
                    equipos = new Equipos();

                }
                equipos.NombreEquipos = txtNombreEquipos.Text;

                try
                {

                    if (!_servicio.Existe(equipos))
                    {
                        _servicio.Guardar(equipos);

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
                            equipos = null;
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
                        equipos = null;
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
            txtNombreEquipos.Clear();
            txtNombreEquipos.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombreEquipos.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombreEquipos, "Debe ingresar un nombre de un EQUIPO");

            }
            return valido;
        }
        internal void SetEquipos(Equipos equipos)
        {
            this.equipos = equipos;
        }
    }
}
