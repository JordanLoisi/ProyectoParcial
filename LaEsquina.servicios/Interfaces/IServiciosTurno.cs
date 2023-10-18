using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
    public interface IServiciosTurno
    {
        void Guardar(Turno turno);
        void Borrar(int idTurnos);
        bool Existe(Turno turno);
        int GetCantidad();
        List<Turno> GetTurno();
        List<Turno> GetTurnoPorPagina(int cantidad, int pagina);
    }
}
