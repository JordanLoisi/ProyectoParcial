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
    public class ServiciosPartidos : IServiciosPartidos
    {
        private readonly IRepositorioPartidos _repositorio;
        public ServiciosPartidos()
        {
            _repositorio = new RepositorioPartidos();
        }
        public void Borrar(int IdPartidos)
        {
            try
            {
                _repositorio.Borrar(IdPartidos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Partidos partidos)
        {
            try
            {
                return _repositorio.EstaRelacionada(partidos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Partidos partidos)
        {
            try
            {
                return _repositorio.Existe(partidos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? IdTorneo)
        {

            try
            {
                return _repositorio.GetCantidad(IdTorneo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Partidos GetPartidosPorId(int IdPartidos)
        {
            try
            {
                return _repositorio.GetPartidosPorId(IdPartidos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PartidosDTO> GetPartidosPorPagina(int registrosPorPagina, int paginaActual, int? IdTorneo)
        {
            try
            {
                var lista = _repositorio.GetPartidosPorPagina(registrosPorPagina, paginaActual, IdTorneo);
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Partidos partidos)
        {
            try
            {
                if (partidos.IdPartidos == 0)
                {
                    _repositorio.Agregar(partidos);
                }
                else
                {
                    _repositorio.Editar(partidos);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
