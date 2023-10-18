using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioRondas
    {
        void Agregar(Rondas rondas);
        void Borrar(int IdRondas);
        void Editar(Rondas rondas);
        bool Existe(Rondas rondas);

        int GetCantidad();
        List<Rondas> GetRondas();
        List<Rondas> GetRondasPorPagina(int cantidad, int pagina);
    }
}
