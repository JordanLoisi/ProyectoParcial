using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioCanchas
    {
        void Agregar(Canchas canchas);
        void Borrar(int IdCanchas);
        void Editar(Canchas canchas);
        bool Existe(Canchas canchas);
        
        int GetCantidad();
        List<Canchas> GetCanchas();
        List<Canchas> GetCanchasPorPagina(int cantidad, int pagina);
    }
}
