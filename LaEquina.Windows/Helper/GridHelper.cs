using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaEquina.Windows.Helper
{
    public class GridHelper
    {
        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }
        public static DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;

        }
        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case Canchas canchas:
                    r.Cells[0].Value = canchas.Nombre;
                    break;
                case Categorias categorias:
                    r.Cells[0].Value = categorias.NombreCategoria;
                    break;
                case Rondas rondas:
                    r.Cells[0].Value = rondas.NombreDeRondas;
                    break;
                case Cuotas cuotas:
                    r.Cells[0].Value = cuotas.Mes;
                    r.Cells[1].Value = cuotas.Monto;
                    break;
                case Equipos equipos:
                    r.Cells[0].Value = equipos.NombreEquipos;
                    break;
                case Fecha fecha:
                    r.Cells[0].Value = fecha.Dia.ToShortDateString();
                    r.Cells[1].Value = fecha.Torneo;
                    break;
                case Turno turno:
                    r.Cells[0].Value = turno.Horario;
                    break;
                case TorneoDTO torneo:
                    r.Cells[0].Value = torneo.FechaInicio.ToShortDateString();
                    r.Cells[1].Value = torneo.FechaFin.ToShortDateString();
                    r.Cells[2].Value = torneo.NombreCategoria;
                    break;
                case MiembroDTO miembro:
                    r.Cells[0].Value = miembro.Nombre;
                    r.Cells[1].Value = miembro.Apellido;
                    r.Cells[2].Value = miembro.NombreEquipos;
                    break;
                case ReservaDTO reserva:
                    r.Cells[0].Value = reserva.Horario;
                    r.Cells[1].Value = reserva.NombreCancha;
                    r.Cells[2].Value = $"{reserva.Apellido.ToUpper()}, {reserva.NombreMiembro}";
                    r.Cells[3].Value = reserva.Dia.ToShortDateString();
                    break;
                case PartidosDTO partidos:
                    r.Cells[0].Value = partidos.NombreEquipo_A;
                    r.Cells[1].Value = partidos.NombreEquipo_B;
                    r.Cells[2].Value = partidos.NombreDeRondas;
                    r.Cells[3].Value = partidos.NombreCategoria;
                    r.Cells[4].Value = partidos.Resultado;
                    break;
                   
            }
            r.Tag = obj;
        }

            
        public static void AgregarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Add(r);
        }

        public static void QuitarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Remove(r);
        }
    }
}

