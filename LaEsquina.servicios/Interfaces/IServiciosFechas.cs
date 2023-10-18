using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
   public interface IServiciosFechas
    {
        void Guardar(Fecha fecha);
        void Borrar(int idFechas);
        bool Existe(Fecha fecha);
        int GetCantidad();
        List<Fecha> GetFechas();
        List<Fecha> GetFechasPorPagina(int cantidad, int pagina);
    }
}
