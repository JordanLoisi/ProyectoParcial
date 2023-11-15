using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioPartidos
    {
        void Agregar(Partidos partidos);
        void Borrar(int IdPartidos);
        void Editar(Partidos partidos);
        bool Existe(Partidos partidos);

        bool EstaRelacionada(Partidos partidos);

        int GetCantidad(int? IdTorneo);
        List<PartidosDTO> GetPartidosPorPagina(int registrosPorPagina, int paginaActual, int? IdTorneo);
        Partidos GetPartidosPorId(int IdPartidos);
       
    }
}
