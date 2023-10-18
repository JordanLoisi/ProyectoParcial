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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void Canchas_Click(object sender, EventArgs e)
        {
            FrmCanchas frm = new FrmCanchas();
            frm.ShowDialog();
        }

        private void CategoriasButton_Click(object sender, EventArgs e)
        {
            FrmCategorias frm = new FrmCategorias();
            frm.ShowDialog();
        }

        private void MiembrosButton_Click(object sender, EventArgs e)
        {
            FrmMiembros frm = new FrmMiembros();
            frm.ShowDialog();
        }

        private void Reservabutton2_Click(object sender, EventArgs e)
        {
            FrmReserva frm = new FrmReserva();
            frm.ShowDialog();
        }

        private void EquiposButton_Click(object sender, EventArgs e)
        {
            FrmEquipos frm = new FrmEquipos();
            frm.ShowDialog();
        }

        private void TorneoButton_Click(object sender, EventArgs e)
        {
            FrmTorneo frm = new FrmTorneo();
            frm.ShowDialog();
        }

       

        private void Turnobutton_Click(object sender, EventArgs e)
        {
            FrmTurno frm = new FrmTurno();
                frm.ShowDialog();
        }

        private void PartidosButton_Click(object sender, EventArgs e)
        {
            FrmPartidos frm = new FrmPartidos();
            frm.ShowDialog();
        }

        private void RondasButton_Click(object sender, EventArgs e)
        {
            FrmRondas frm = new FrmRondas();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCuotas_Click(object sender, EventArgs e)
        {
            FrmCuotas frm = new FrmCuotas();
            frm.ShowDialog();
        }

        private void FechaButton_Click_1(object sender, EventArgs e)
        {

            FrmFechas frm = new FrmFechas();
            frm.ShowDialog();
        }
    }
}
