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
    public class ServiciosTorneo : IServiciosTorneo
    {
        private readonly IRepositorioTorneo _repositorio;
        public ServiciosTorneo()
        {
            _repositorio = new RepositorioTorneo();
        }
        public void Borrar(int IdTorneo)
        {
            try
            {
                _repositorio.Borrar(IdTorneo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Torneo torneo)
        {
            try
            {
                return _repositorio.EstaRelacionada(torneo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Torneo torneo)
        {
            try
            {
                return _repositorio.Existe(torneo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? IdCategoria)
        {
            try
            {
                return _repositorio.GetCantidad(IdCategoria);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TorneoDTO> GetTorneoPorPagina(int registrosPorPagina, int paginaActual, int? IdCategoria)
        {
            try
            {
                var lista = _repositorio.GetTorneoPorPagina(registrosPorPagina, paginaActual, IdCategoria);
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Torneo GetTorneoPorId(int IdTorneo)
        {
            try
            {
                return _repositorio.GetTorneoPorId(IdTorneo);
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public void Guardar(Torneo torneo)
        {
            try
            {
                if (torneo.IdTorneo == 0)
                {
                    _repositorio.Agregar(torneo);
                }
                else
                {
                    _repositorio.Editar(torneo);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Torneo> GetTorneoCombo()
        {
            try
            {
                return _repositorio.GetTorneoCombo();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
