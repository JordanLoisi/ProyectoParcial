using LaEsquina.Entidades.dto;
using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
    public interface IServiciosPartidos
    {
        void Guardar(Partidos partidos);
        void Borrar(int IdPartidos);
        bool Existe(Partidos partidos);
        bool EstaRelacionada(Partidos  partidos);

        List<PartidosDTO> GetPartidosPorPagina(int registrosPorPagina, int paginaActual, int? IdTorneo);

        int GetCantidad(int? IdTorneo);
        Partidos GetPartidosPorId(int IdPartidos);
    }
}
