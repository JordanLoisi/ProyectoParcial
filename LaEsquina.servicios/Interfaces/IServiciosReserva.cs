using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
    public interface IServiciosReserva
    {
        void Guardar(Reserva reserva);
        void Borrar(int IdReserva);
        bool Existe(Reserva reserva);
        bool EstaRelacionada(Reserva reserva);

        List<ReservaDTO> GetReservaPorPagina(int registrosPorPagina, int paginaActual, int? IdFechas);
        //List<Torneo> GetCiudades(int? paisId);
        int GetCantidad(int? IdFechas);
        Reserva GetReservaPorId(int IdReserva);
    }
}
