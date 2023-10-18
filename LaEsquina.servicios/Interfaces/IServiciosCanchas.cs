using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
    public interface IServiciosCanchas
    {
        void Guardar(Canchas canchas);
        void Borrar(int idCanchas);
        bool Existe(Canchas canchas);
        int GetCantidad();
        List<Canchas> GetCanchas();
        List<Canchas> GetCanchasPorPagina(int cantidad, int pagina);
    }
}
