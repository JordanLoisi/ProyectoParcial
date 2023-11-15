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
    public partial class FrmTorneoAE : Form
    {
        private IServiciosTorneo _servicio;
        public FrmTorneoAE(IServiciosTorneo servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Torneo torneo;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (torneo != null)
            {
                esEdicion = true;

            }
        }
        public Torneo GetTorneo()
        {
            return torneo;
        }
        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmTorneoAE_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (torneo == null)
                {
                    torneo = new Torneo();

                }
                torneo.FechaInicio = dateTimePicker1.Value.Date;
                torneo.FechaFin = dateTimePicker1.Value.Date;
                //torneo.categorias = txtCategoria.Text; 

                try
                {

                    if (!_servicio.Existe(torneo))
                    {
                        _servicio.Guardar(torneo);

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
                            torneo = null;
                            InitializeControles();


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
                        torneo = null;
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void InitializeControles()
        {
            txtCategoria.Clear();
            txtCategoria.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (dateTimePicker1.Value.Day > DateTime.Now.Day)
            {
                valido = false;
                errorProvider1.SetError(dateTimePicker1, "La FechaInicio es requerida");
            }
            if (dateTimePicker2.Value.Day > DateTime.Now.Day)
            {
                valido = false;
                errorProvider1.SetError(dateTimePicker2, "La FechaFin es requerida");
            }
            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCategoria, "La Catgegoria es requerida");
            }
            return valido;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        internal void SetTorneo(Torneo torneo)
        {
            this.torneo = torneo;
        }
    }
}
