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
    public class ServiciosCategorias : IServiciosCategorias
    {
        private readonly RepositorioCategorias _repositorio;
        public ServiciosCategorias()
        {
            _repositorio = new RepositorioCategorias();
        }
        public void Borrar(int IdCategoria)
        {
            try
            {
                _repositorio.Borrar(IdCategoria);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Categorias categorias)
        {
            try
            {
                return _repositorio.Existe(categorias);
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

        public List<Categorias> GetCategorias()
        {

            try
            {
                return _repositorio.GetCategorias();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Categorias> GetCategoriasPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetCategoriasPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Categorias categorias)
        {

            try
            {
                if (categorias.IdCategoria == 0)
                {
                    _repositorio.Agregar(categorias);

                }
                else
                {
                    _repositorio.Editar(categorias);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
