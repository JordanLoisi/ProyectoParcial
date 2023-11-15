using LaEsquina.Entidades;
using LaEsquina.servicios.Interfaces;
using LaEsquina.servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaEquina.Windows.Helper
{
    public class ComboHelpers
    {
        public static void CargarComboEquipos(ref ComboBox combo)
        {
            IServiciosEquipos serviciosEquipos = new ServiciosEquipos();
            var lista = serviciosEquipos.GetEquiposCombo();
            var defaultEquipos = new Equipos()
            {
                IdEquipos = 0,
                NombreEquipos = "Seleccione Equipo"
            };
            lista.Insert(0, defaultEquipos);
            combo.DataSource = lista;
            combo.DisplayMember = "NombreEquipos";
            combo.ValueMember = "IdEquipos";
            combo.SelectedIndex = 0;
        }

        public static void CargarComboCanchas(ref ComboBox cbocanchas)
        {
            IServiciosCanchas serviciosCanchas = new ServiciosCanchas();
            var lista = serviciosCanchas.GetCachasCombo();
            var defaultCanchas = new  Canchas()
            {
                IdCanchas = 0,
                Nombre = 0,
            };
            lista.Insert(0, defaultCanchas);
            cbocanchas.DataSource = lista;
            cbocanchas.DisplayMember = "Nombre";
            cbocanchas.ValueMember = "IdCanchas";
            cbocanchas.SelectedIndex = 0;
        }

        public static void CargarComboFechas(ref ComboBox cboFecha)
        {
            IServiciosFechas serviciosFechas = new ServiciosFechas();
            var lista = serviciosFechas.GetFechasCombo();
            var defaultFechas = new Fecha()
            {
                IdFechas = 0,
                Dia = new DateTime (01,01,0001),
                
            };
            lista.Insert(0, defaultFechas);
            cboFecha.DataSource = lista;
            cboFecha.DisplayMember = "Dia";

            cboFecha.ValueMember = "IdFechas";
            cboFecha.SelectedIndex = 0;
        }

        public static void CargarComboMiembros(ref ComboBox cboMiembro)
        {
            IServiciosMiembros serviciosMiembros = new ServiciosMiembros();
            var lista = serviciosMiembros.GetMiembrosCombo();
            var defaultMiembros = new Miembro()
            {
                IdMiembros = 0,
                Nombre= "Seleccione Miembros",
                
            };
            lista.Insert(0, defaultMiembros);
            cboMiembro.DataSource = lista;
            cboMiembro.DisplayMember = "Nombre";

            cboMiembro.ValueMember = "IdMiembros";
            cboMiembro.SelectedIndex = 0;
        }

        public static void CargarComboRondas(ref ComboBox cboRondas)
        {
            IServiciosRondas serviciosRondas = new ServiciosRondas();
            var lista = serviciosRondas.GetRondasCombo();
            var defaultRondas = new Rondas()
            {
                IdRondas = 0,
                NombreDeRondas = "Seleccione Rondas"
            };
            lista.Insert(0, defaultRondas);
            cboRondas.DataSource = lista;
            cboRondas.DisplayMember = "NombreDeRondas";

            cboRondas.ValueMember = "IdRondas";
            cboRondas.SelectedIndex = 0;
        }

        public static void CargarComboTorneo(ref ComboBox cboTorneo)
        {
            IServiciosTorneo serviciosTorneo = new ServiciosTorneo();
            var lista = serviciosTorneo.GetTorneoCombo();
            var defaultTorneo = new Torneo()
            {
                IdTorneo = 0,
                FechaInicio = new DateTime (0001,1,1)
            };
            lista.Insert(0, defaultTorneo);
            cboTorneo.DataSource = lista;
            cboTorneo.DisplayMember = "FechaInicio";

            cboTorneo.ValueMember = "IdTorneo";
            cboTorneo.SelectedIndex = 0;
        }

        public static void CargarComboTurno(ref ComboBox cboTurno)
        {
            IServiciosTurno serviciosTurno = new ServiciosTurno();
            var lista = serviciosTurno.GetTurnoCombo();
            var defaultTurno = new Turno()
            {
                IdTurnos = 0,
                //Horario= new TimeSpan ()
            };
            lista.Insert(0, defaultTurno);
            cboTurno.DataSource = lista;
            cboTurno.DisplayMember = "Horario";

            cboTurno.ValueMember = "IdTurnos";
            cboTurno.SelectedIndex = 0;
        }
    }
}
