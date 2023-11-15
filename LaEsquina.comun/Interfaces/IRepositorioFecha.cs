using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioFecha
    {
        void Agregar(Fecha fecha);
        void Borrar(int IdFechas);
        void Editar(Fecha fechas);
        bool Existe(Fecha fecha);

        int GetCantidad();
        List<Fecha> GetFechas();
        List<Fecha> GetFechasPorPagina(int cantidad, int pagina);

        Fecha GetFechaPorId(int IdFechas);
    }
}
