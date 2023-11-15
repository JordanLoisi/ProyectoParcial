using Dapper;
using LaEsquina.comun.Interfaces;
using LaEsquina.Entidades;
using LaEsquina.Entidades.dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.datos.Repositorios
{
    public class RepositorioMiembros : IRepositorioMiembros
    {
        private readonly string cadenaConexion;
        public RepositorioMiembros()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(Miembro miembro)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = @"INSERT INTO Miembros (Nombre,Apellido, IdEquipos)
                    VALUES(@Nombre,@Apellido, @IdEquipos); SELECT SCOPE_IDENTITY()";
                int id = conn.ExecuteScalar<int>(insertQuery, miembro);
                miembro.IdMiembros = id;

            }
        }

        public void Borrar(int IdMiembros)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Miembros 
                        WHERE IdMiembros=@IdMiembros";
                conn.Execute(deleteQuery, new { IdMiembros });
            }
        }

        public void Editar(Miembro miembro)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Miembros SET Nombre=@Nombre,Apellido=@Apellido,IdEquipos=@IdEquipos
                                   WHERE IdMiembros=@IdMiembros";
                conn.Execute(updateQuery, miembro);
            }
        }

        public bool EstaRelacionado(Miembro miembro)
        {
            int cantidadReserva = 0;


            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM Reserva WHERE IdMiembros=@IdMiembros;
                                        ";
                using (var resultado = conn.QueryMultiple(selectQuery, new { IdMiembros=miembro.IdMiembros}))
                {
                    cantidadReserva = resultado.Read<int>().First();

                }
            }
            return cantidadReserva > 0;
        }

        public bool Existe(Miembro miembro)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (miembro.IdMiembros == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Miembros
                        WHERE Nombre=@Nombre AND Apellido=@Apellido AND IdEquipos=@IdEquipos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, miembro);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Miembros
                            WHERE Nombre=@Nombre AND Apellido=@Apellido AND IdEquipos=@IdEquipos
                            AND IdMiembros!=@IdMiembros";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, miembro);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdEquipos)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (IdEquipos == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Miembros";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Miembros
                        WHERE IdEquipos=@IdEquipos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdEquipos = IdEquipos });
                }
            }
            return cantidad;
        }

        public List<MiembroDTO> GetMiembrosPorPagina(int cantidad, int paginaActual, int? IdEquipos)
        {
            List<MiembroDTO> lista = new List<MiembroDTO>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                if (IdEquipos == null)
                {
                    string selectQuery = @"SELECT m.IdMiembros, m.Nombre,m.Apellido,e.NombreEquipos
                                FROM Miembros m INNER JOIN Equipos e
                                ON m.IdEquipos=e.IdEquipos
                                ORDER BY m.IdEquipos
                                OFFSET @cantidadRegistros ROWS 
                                FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    var registrosSateados = cantidad * (paginaActual - 1);

                    lista = conn.Query<MiembroDTO>(selectQuery, new
                    {
                        cantidadRegistros = registrosSateados,
                        cantidadPorPagina = cantidad
                    }).ToList();
                }
                else
                {
                    string selectQuery = @"SELECT IdMiembros, Nombre,Apellido,IdEqipos
                                FROM Miembros INNER JOIN Equipos
                                ON Miembros.IdEquipos=Equipos.IdEquipos
                                 WHERE Miembros.IdEquipos=@IdEquipos
                                ORDER BY Miembros.IdEquipos
                                OFFSET @cantidadRegistros ROWS 
                                FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    var registrosSateados = cantidad * (paginaActual - 1);

                    lista = conn.Query<MiembroDTO>(selectQuery, new
                    {
                        IdEquipos = IdEquipos.Value,
                        cantidadRegistros = registrosSateados,
                        cantidadPorPagina = cantidad
                    }).ToList();

                }
            }
            return lista;
        }


        public Miembro GetMiembroPorId(int IdMiembro)
        {
            Miembro miembro = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdMiembros,Nombre,Apellido, IdEquipos
                    FROM Miembros WHERE IdMiembros=@IdMiembros";
                miembro = conn.QuerySingleOrDefault<Miembro>(selectQuery,
                    new { IdMiembros=IdMiembro });
            }
            return miembro;
        }

        public List<Miembro> GetMimebrosCombo()
        {
            List<Miembro> lista;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdMiembros, Nombre,Apellido , IdEquipos FROM Miembros
                         ORDER BY IdEquipos";
                lista = conn.Query<Miembro>(selectQuery).ToList();

            }
            return lista;

        }
    }
}
