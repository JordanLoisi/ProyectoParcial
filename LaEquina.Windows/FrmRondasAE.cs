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
    public partial class FrmRondasAE : Form
    {
        private IServiciosRondas _servicio;
        public FrmRondasAE(IServiciosRondas servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Rondas rondas;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (rondas != null)
            {
                esEdicion = true;
                txtNombreRondas.Text = rondas.NombreDeRondas;
            }
        }
        public FrmRondasAE()
        {
            InitializeComponent();
        }

        private void FrmRondasAE_Load(object sender, EventArgs e)
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
                if (rondas == null)
                {
                    rondas = new Rondas();

                }
                rondas.NombreDeRondas = txtNombreRondas.Text;
                try
                {

                    if (!_servicio.Existe(rondas))
                    {
                        _servicio.Guardar(rondas);

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
                            rondas = null;
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
                        rondas = null;
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }
        public Rondas GetRondas()
        {
            return rondas;
        }
        private void InicializarControles()
        {
            txtNombreRondas.Clear();
            txtNombreRondas.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombreRondas.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombreRondas, "Debe ingresar un nombre de país");

            }
            return valido;
        }
        internal void SetRondas(Rondas rondas)
        {
            this.rondas = rondas;
        }

    }
}
