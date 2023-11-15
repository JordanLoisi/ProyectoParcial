using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
    public interface IServiciosRondas
    {
        void Guardar(Rondas rondas);
        void Borrar(int IdRondas);
        bool Existe(Rondas rondas);
        int GetCantidad();
        List<Rondas> GetRondas();
        List<Rondas> GetRondasPorPagina(int cantidad, int pagina);
        Rondas GetRondasPorId(int IdRondas);
        List<Rondas> GetRondasCombo();
    }
}
