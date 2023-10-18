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
    public partial class FrmTurnoAE : Form
    {
        private IServiciosTurno _servicio;
        public FrmTurnoAE(IServiciosTurno servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Turno turno;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (turno != null)
            {
                esEdicion = true;

             
            }
        }
        private void FrmTurnoAE_Load(object sender, EventArgs e)
        {

        }
        public Turno GetTurno()
        {
            return turno;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (turno == null)
                {
                    turno = new Turno();

                }
                turno.Horario = new TimeSpan(dateTimePicker1.Value.Hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);

                try
                {

                    if (!_servicio.Existe(turno))
                    {
                        _servicio.Guardar(turno);

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
                            turno = null;
                           

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
                        turno = null;
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
            if (dateTimePicker1.Value.Hour>DateTime.Now.Hour)
            {
                valido = false;
                errorProvider1.SetError(dateTimePicker1, "Debe ingresar un Turno");

            }
            return valido;
        }

        internal void SetTurno(Turno turno)
        {
            this.turno = turno;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

