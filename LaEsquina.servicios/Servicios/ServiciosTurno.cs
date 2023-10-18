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
    public class ServiciosTurno : IServiciosTurno
    {
        private readonly RepositorioTurnos _repositorio;
        public ServiciosTurno()
        {
            _repositorio = new RepositorioTurnos();
        }
        public void Borrar(int idTurnos)
        {
            try
            {
                _repositorio.Borrar(idTurnos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Turno turno)
        {
            try
            {
                return _repositorio.Existe(turno);
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

        public List<Turno> GetTurno()
        {
            try
            {
                return _repositorio.GetTurno();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Turno> GetTurnoPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetTurnoPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Turno turno)
        {
            try
            {
                if (turno.IdTurnos == 0)
                {
                    _repositorio.Agregar(turno);

                }
                else
                {
                    _repositorio.Editar(turno);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
