using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
    public interface IServiciosCuotas
    {
        void Guardar(Cuotas cuotas);
        void Borrar(int idCuotas);
        bool Existe(Cuotas cuotas);
        int GetCantidad();
        List<Cuotas> GetCuotas();
        List<Cuotas> GetCuotasPorPagina(int cantidad, int pagina);
    }
}
