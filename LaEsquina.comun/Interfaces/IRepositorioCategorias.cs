using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioCategorias
    {
        void Agregar(Categorias categorias);
        void Borrar(int IdCategoria);
        void Editar(Categorias categoria);
        bool Existe(Categorias categoria);

        int GetCantidad();
        List<Categorias> GetCategorias();
        List<Categorias> GetCategoriasPorPagina(int cantidad, int pagina);
    }
}
