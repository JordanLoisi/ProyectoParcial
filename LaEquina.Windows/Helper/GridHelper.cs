using LaEsquina.Entidades;
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

