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
    public partial class FrmCanchasAE : Form
    {
        private IServiciosCanchas _servicio;
        public FrmCanchasAE(IServiciosCanchas servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Canchas canchas;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (canchas != null)
            {
                esEdicion = true;
                txtNombreCanchas.Text = canchas.Nombre.ToString();
            }
        }
        public Canchas GetCanchas()
        {
            return canchas;
        }
        private void FrmCanchasAE_Load(object sender, EventArgs e)
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
                if (canchas == null)
                {
                    canchas = new Canchas();

                }
                canchas.Nombre = int.Parse(txtNombreCanchas.Text);

                try
                {

                    if (!_servicio.Existe(canchas))
                    {
                        _servicio.Guardar(canchas);

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
                            canchas = null;
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
                        canchas = null;
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
            txtNombreCanchas.Clear();
            txtNombreCanchas.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombreCanchas.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombreCanchas, "Debe ingresar un nombre de una cancha");

            }
            return valido;
        }

        internal void SetCanchas(Canchas canchas)
        {
            this.canchas = canchas;
        }
    }
}
