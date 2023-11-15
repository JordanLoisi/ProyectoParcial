using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioReserva
    {
        void Agregar(Reserva reserva);
        void Borrar(int IdReserva);
        void Editar(Reserva reserva);
        bool Existe(Reserva reserva);
        bool EstaRelacionada(Reserva reserva);

        int GetCantidad(int? IdFecha);
        List<ReservaDTO> GetReservaPorPagina(int registrosPorPagina, int paginaActual, int? IdFecha);
        Reserva GetReservaPorId(int IdReserva);
        
    }
}
