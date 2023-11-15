using LaEsquina.comun.Interfaces;
using LaEsquina.datos.Repositorios;
using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using LaEsquina.servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Servicios
{
    public class ServiciosReserva : IServiciosReserva
    {
        private readonly IRepositorioReserva _repositorio;
        public ServiciosReserva()
        {
            _repositorio = new RepositorioReserva();
        }
        public void Borrar(int IdReserva)
        {
            try
            {
                _repositorio.Borrar(IdReserva);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Reserva reserva)
        {
             try
            {
                return _repositorio.EstaRelacionada(reserva);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Reserva reserva)
        {
            try
            {
                return _repositorio.Existe(reserva);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? IdFechas)
        {
            try
            {
                return _repositorio.GetCantidad(IdFechas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Reserva GetReservaPorId(int IdReserva)
        {
            try
            {
                return _repositorio.GetReservaPorId(IdReserva);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ReservaDTO> GetReservaPorPagina(int registrosPorPagina, int paginaActual, int? IdFechas)
        {
            try
            {
                var lista = _repositorio.GetReservaPorPagina(registrosPorPagina, paginaActual, IdFechas);
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Reserva reserva)
        {
            try
            {
                if (reserva.IdReserva == 0)
                {
                    _repositorio.Agregar(reserva);
                }
                else
                {
                    _repositorio.Editar(reserva);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
