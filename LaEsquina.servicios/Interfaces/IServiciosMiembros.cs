using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.servicios.Interfaces
{
    public interface IServiciosMiembros
    {
        void Guardar(Miembro miembro);
        void Borrar(int IdMiembro);
        bool Existe(Miembro miembro);
        bool EstaRelacionada(Miembro miembros);

        List<MiembroDTO> GetMiembrosPorPagina(int registrosPorPagina, int paginaActual, int? IdEquipos);
        
        int GetCantidad(int? IdEquipos);
        Miembro GetMiembroPorId(int IdMiembros);

        List<Miembro> GetMiembrosCombo();
    }
}
