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
    public partial class FrmFechaAE : Form
    {
        private IServiciosFechas _servicio;
        public FrmFechaAE(IServiciosFechas servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Fecha fecha;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (fecha != null)
            {
                esEdicion = true;
                
            }
        }
        public Fecha GetFecha()
        {
            return fecha;
        }

        private void FrmFechaAE_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (fecha == null)
                {
                    fecha = new Fecha();

                }
                fecha.Dia= dateTimePicker1.Value.Date;

                try
                {

                    if (!_servicio.Existe(fecha))
                    {
                        _servicio.Guardar(fecha);

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
                            fecha = null;
                            

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
                        fecha = null;
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
            if (dateTimePicker1.Value.Day > DateTime.Now.Day)
            {
                valido = false;
                errorProvider1.SetError(dateTimePicker1, "Debe ingresar una Fecha");

            }
            return valido;
        }

        internal void SetFechas(Fecha fecha)
        {
            this.fecha = fecha;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
