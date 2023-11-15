using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioTorneo
    {
        void Agregar(Torneo torneo);
        void Borrar(int IdTorneo);
        void Editar(Torneo torneo);
        bool Existe(Torneo torneo);
        bool EstaRelacionada(Torneo torneo);

        int GetCantidad(int? IdCategoria);
        List<TorneoDTO> GetTorneoPorPagina(int registrosPorPagina, int paginaActual, int? IdCategoria);
        Torneo GetTorneoPorId(int IdTorneo);
        List<Torneo> GetTorneoCombo();
    }
}
