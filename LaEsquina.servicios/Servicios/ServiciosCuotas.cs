using LaEsquina.datos.Repositorios;
using LaEsquina.Entidades;
using LaEsquina.servicios.Interfaces;
using System;
using System.Collections.Generic;

namespace LaEsquina.servicios.Servicios
{
    public class ServiciosCuotas : IServiciosCuotas
    {
        private readonly RepositorioCuotas _repositorio;
        public ServiciosCuotas()
        {
            _repositorio = new RepositorioCuotas();
        }
        public void Borrar(int idCuotas)
        {
            try
            {
                _repositorio.Borrar(idCuotas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Cuotas cuotas)
        {
            try
            {
                return _repositorio.Existe(cuotas);
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

        public List<Cuotas> GetCuotas()
        {
            try
            {
                return _repositorio.GetCuotas();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cuotas> GetCuotasPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetCuotasPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Cuotas cuotas)
        {
            try
            {
                if (cuotas.IdCuotas == 0)
                {
                    _repositorio.Agregar(cuotas);

                }
                else
                {
                    _repositorio.Editar(cuotas);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
