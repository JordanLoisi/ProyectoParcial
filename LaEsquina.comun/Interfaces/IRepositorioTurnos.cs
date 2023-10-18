using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioTurnos
    {
        void Agregar(Turno turno);
        void Borrar(int IdTurnos);
        void Editar(Turno turno);
        bool Existe(Turno turno);

        int GetCantidad();
        List<Turno> GetTurno();
        List<Turno> GetTurnoPorPagina(int cantidad, int pagina);
    }
}
