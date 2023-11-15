using LaEsquina.datos.Repositorios;
using LaEsquina.Entidades;
using LaEsquina.servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Servicios
{
    public class ServiciosFechas : IServiciosFechas
    {
        private readonly RepositorioFechas _repositorio;
        public ServiciosFechas()
        {
            _repositorio = new RepositorioFechas();
        }
        public void Borrar(int idFechas)
        {
            try
            {
                _repositorio.Borrar(idFechas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Fecha fecha)
        {
            try
            {
                return _repositorio.Existe(fecha);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            try
            {
                return _repositorio.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Fecha> GetFechas()
        {
            try
            {
                return _repositorio.GetFechas();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Fecha> GetFechasCombo()
        {
            try
            {
                return _repositorio.GetFechasCombo();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Fecha GetFechasPorId(int IdFechas)
        {
            try
            {
                return _repositorio.GetFechaPorId(IdFechas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Fecha> GetFechasPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetFechasPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Fecha fecha)
        {
            try
            {
                if (fecha.IdFechas == 0)
                {
                    _repositorio.Agregar(fecha);

                }
                else
                {
                    _repositorio.Editar(fecha);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
