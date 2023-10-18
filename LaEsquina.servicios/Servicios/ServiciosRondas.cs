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
    public class ServiciosRondas : IServiciosRondas
    {
        private readonly RepositorioRondas _repositorio;
        public ServiciosRondas()
        {
            _repositorio = new RepositorioRondas();
        }
        public void Borrar(int IdRondas)
        {
            try
            {
                _repositorio.Borrar(IdRondas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Rondas rondas)
        {
            try
            {
                return _repositorio.Existe(rondas);
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

        public List<Rondas> GetRondas()
        {
            try
            {
                return _repositorio.GetRondas();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Rondas> GetRondasPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetRondasPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Rondas rondas)
        {
            try
            {
                if (rondas.IdRondas == 0)
                {
                    _repositorio.Agregar(rondas);

                }
                else
                {
                    _repositorio.Editar(rondas);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
