using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
    public interface IServiciosTorneo
    {
        void Guardar(Torneo torneo);
        void Borrar(int IdTorneo);
        bool Existe(Torneo torneo);
        bool EstaRelacionada(Torneo torneo);
        
        List<TorneoDTO> GetTorneoPorPagina(int registrosPorPagina, int paginaActual, int? IdCategoria);

        
        int GetCantidad(int? IdCategoria);
        Torneo GetTorneoPorId(int IdTorneo);
        List<Torneo> GetTorneoCombo();
    }
}
