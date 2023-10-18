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
    public partial class FrmCategoriasAE : Form
    {
        private IServiciosCategorias _servicio;

        public FrmCategoriasAE(IServiciosCategorias servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private Categorias categorias;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (categorias != null)
            {
                esEdicion = true;
                txtNombreCategorias.Text = categorias.NombreCategoria;
            }
        }
        public Categorias GetCategorias()
        {
            return categorias;
        }

        private void FrmCategoriasAE_Load(object sender, EventArgs e)
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
                if (categorias == null)
                {
                    categorias = new Categorias();

                }
                categorias.NombreCategoria = txtNombreCategorias.Text;

                try
                {

                    if (!_servicio.Existe(categorias))
                    {
                        _servicio.Guardar(categorias);

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
                            categorias = null;
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
                        categorias = null;
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
            txtNombreCategorias.Clear();
            txtNombreCategorias.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombreCategorias.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombreCategorias, "Debe ingresar un nombre de país");

            }
            return valido;
        }
        internal void SetCategorias(Categorias categorias)
        {
            this.categorias = categorias;
        }
    }
}
