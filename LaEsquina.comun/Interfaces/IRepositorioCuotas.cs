using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioCuotas
    {
        void Agregar(Cuotas cuotas);
        void Borrar(int IdCuotas);
        void Editar(Cuotas cuotas);
        bool Existe(Cuotas cuotas);

        int GetCantidad();
        List<Cuotas> GetCuotas();
        List<Cuotas> GetCuotasPorPagina(int cantidad, int pagina);
    }
}
