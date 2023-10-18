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
    public class ServiciosCanchas : IServiciosCanchas
    {
        private readonly RepositorioCanchas _repositorio;
        public ServiciosCanchas()
        {
            _repositorio = new RepositorioCanchas();
        }
        public void Borrar(int idCanchas)
        {
            try
            {
                _repositorio.Borrar(idCanchas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Canchas canchas)
        {
            try
            {
                return _repositorio.Existe(canchas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Canchas> GetCanchas()
        {
            try
            {
                return _repositorio.GetCanchas();
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

        public List<Canchas> GetCanchasPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetCanchasPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Canchas canchas)
        {
            try
            {
                if (canchas.IdCanchas == 0)
                {
                    _repositorio.Agregar(canchas);

                }
                else
                {
                    _repositorio.Editar(canchas);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
