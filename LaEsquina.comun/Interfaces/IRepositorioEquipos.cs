using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioEquipos
    {
        void Agregar(Equipos equipos);
        void Borrar(int IdEquipos);
        void Editar(Equipos equipos);
        bool Existe(Equipos equipos);

        int GetCantidad();
        List<Equipos> GetEquipos();
        List<Equipos> GetEquiposPorPagina(int cantidad, int pagina);

    }
}
