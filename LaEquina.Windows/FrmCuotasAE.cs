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
    public partial class FrmCuotasAE : Form
    {
        private IServiciosCuotas _servicio;
        public FrmCuotasAE(IServiciosCuotas servicios)
        {
            InitializeComponent();
            _servicio = servicios;
        }

        private Cuotas cuotas;
        private bool esEdicion = false;
        public FrmCuotasAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (cuotas != null)
            {
                esEdicion = true;
                txtMes.Text = cuotas.Mes.ToString();
                txtMonto.Text=cuotas.Monto.ToString();  
            }
        }
        public Cuotas GetCuotas()
        {
            return cuotas;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cuotas == null)
                {
                    cuotas = new Cuotas();

                }
                cuotas.Mes= txtMes.Text;
                cuotas.Monto = int.Parse(txtMonto.Text);

                try
                {

                    if (!_servicio.Existe(cuotas))
                    {
                        _servicio.Guardar(cuotas);

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
                            cuotas = null;
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
                        cuotas = null;
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
            txtMes.Clear();
            txtMes.Focus();

            txtMonto.Clear();
            txtMonto.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtMes.Text))
            {
                valido = false;
                errorProvider1.SetError(txtMes, "Debe ingresar un Mes");

            }
            return valido;
        }

        internal void SetCuotas(Cuotas cuotas)
        {
            this.cuotas = cuotas;
        }

        private void FrmCuotasAE_Load(object sender, EventArgs e)
        {

        }
    }
 }

