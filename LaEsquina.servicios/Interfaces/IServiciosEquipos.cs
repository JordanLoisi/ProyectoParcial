using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
    public interface IServiciosEquipos
    {
        void Guardar(Equipos equipos);
        void Borrar(int idEquipos);
        bool Existe(Equipos equipos);
        int GetCantidad();
        List<Equipos> GetEquipos();
        List<Equipos> GetEquiposPorPagina(int cantidad, int pagina);
        Equipos GetEquiposPorId(int idEquipos);
        List<Equipos> GetEquiposCombo();
    }
}
