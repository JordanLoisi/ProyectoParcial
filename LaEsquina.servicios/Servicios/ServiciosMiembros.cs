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
    public class ServiciosMiembros : IServiciosMiembros
    {
        private readonly IRepositorioMiembros _repositorio;
        public ServiciosMiembros()
        {
            _repositorio = new RepositorioMiembros();
        }
        public void Borrar(int IdMiembro)
        {
            try
            {
                _repositorio.Borrar(IdMiembro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Miembro miembros)
        {
            try
            {
                return _repositorio.EstaRelacionado(miembros);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Miembro miembro)
        {
            try
            {
                return _repositorio.Existe(miembro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad(int? IdEquipos)
        {
            try
            {
                return _repositorio.GetCantidad(IdEquipos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Miembro GetMiembroPorId(int IdMiembros)
        {
            try
            {
                return _repositorio.GetMiembroPorId(IdMiembros);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Miembro> GetMiembrosCombo()
        {
            try
            {
                return _repositorio.GetMimebrosCombo();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MiembroDTO> GetMiembrosPorPagina(int registrosPorPagina, int paginaActual, int? IdEquipos)
        {
            try
            {
                var lista = _repositorio.GetMiembrosPorPagina(registrosPorPagina, paginaActual, IdEquipos);
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Miembro miembro)
        {
            try
            {
                if (miembro.IdMiembros == 0)
                {
                    _repositorio.Agregar(miembro);
                }
                else
                {
                    _repositorio.Editar(miembro);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
