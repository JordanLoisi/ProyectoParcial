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
    public class ServiciosEquipos : IServiciosEquipos
    {
       private readonly RepositorioEquipos _repositorio;
      public ServiciosEquipos()
      {
          _repositorio = new RepositorioEquipos();
      }
         public void Borrar(int idEquipos)
        {
            try
            {
                _repositorio.Borrar(idEquipos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Equipos equipos)
        {
            try
            {
                return _repositorio.Existe(equipos);
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

        public List<Equipos> GetEquipos()
        {
            try
            {
                return _repositorio.GetEquipos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Equipos> GetEquiposPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetEquiposPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Equipos equipos)
        {
            try
            {
                if (equipos.IdEquipos == 0)
                {
                    _repositorio.Agregar(equipos);

                }
                else
                {
                    _repositorio.Editar(equipos);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
