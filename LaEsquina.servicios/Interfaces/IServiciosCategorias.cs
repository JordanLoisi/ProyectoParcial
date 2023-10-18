using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
    public interface IServiciosCategorias
    {
        void Guardar(Categorias categorias);
        void Borrar(int IdCategoria);
        bool Existe(Categorias categorias);
        int GetCantidad();
        List<Categorias> GetCategorias();
        List<Categorias> GetCategoriasPorPagina(int cantidad, int pagina);
    }
}
