using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.comun.Interfaces
{
    public interface IRepositorioMiembros
    {
        void Borrar(int IdMiembro);
        void Editar(Miembro miembro);
        bool Existe(Miembro miembro);
        bool EstaRelacionado(Miembro miembro);
        
        int GetCantidad(int? IdEquipos);
        
        List<MiembroDTO> GetMiembrosPorPagina(int registrosPorPagina, int paginaActual, int? IdEquipos);
        void Agregar(Miembro miembro);
        Miembro GetMiembroPorId(int IdMiembro);
        List<Miembro> GetMimebrosCombo();
    }
}
