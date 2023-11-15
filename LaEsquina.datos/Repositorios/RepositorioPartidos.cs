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
    public class RepositorioPartidos : IRepositorioPartidos
    {
        private readonly string cadenaConexion;
        public RepositorioPartidos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(Partidos partidos)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = @"INSERT INTO Partidos (IdEquipos_A,IdEquipo_B,IdRondas,IdTorneo,Resultado)
                    VALUES(@IdEquipo_A,@IdEquipo_B,@IdRondas,@IdTorneo,@Resultado); SELECT SCOPE_IDENTITY()";
                int id = conn.ExecuteScalar<int>(insertQuery, partidos);
                partidos.IdPartidos = id;

            }
        }

        public void Borrar(int IdPartidos)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Partidos
                        WHERe IdPartidos=@IdPartidos";
                conn.Execute(deleteQuery, new { IdPartidos });
            }
        }

        public void Editar(Partidos partidos)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Partidos SET IdEquipos_A=@IdEquipo_A,IdEquipo_B=@IdEquipo_B,IdRondas=@IdRondas,IdTorneo=@IdTorneo,Resultado=@Resultado
                                   WHERE IdPartidos=@IdPartidos";
                conn.Execute(updateQuery, partidos);
            }
        }

        public bool EstaRelacionada(Partidos partidos)
        {
            int cantidadTorneo = 0;


            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM Partidos WHERE IdPartidos=@IdPartidos;
                                        ";
                using (var resultado = conn.QueryMultiple(selectQuery, new { IdPartidos = partidos.IdPartidos }))
                {
                    cantidadTorneo = resultado.Read<int>().First();

                }
            }
            return cantidadTorneo > 0;
        }

        public bool Existe(Partidos partidos)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (partidos.IdPartidos == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Partidos
                        WHERE IdEquipos_A=@IdEquipo_A and IdEquipo_B=@IdEquipo_B and IdRondas=@IdRondas and IdTorneo=@IdTorneo and Resultado=@Resultado";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, partidos);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Partidos
                            WHERE IdEquipos_A=@IdEquipo_A and IdEquipo_B=@IdEquipo_B and IdRondas=@IdRondas and IdTorneo=@IdTorneo and Resultado=@Resultado
                            AND IdPartidos!=@IdPartidos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, partidos);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdTorneo)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (IdTorneo == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Partidos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Partidos
                        WHERE IdTorneo=@IdTorneo";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdTorneo=IdTorneo });
                }
            }
            return cantidad;
        }

        public Partidos GetPartidosPorId(int IdPartidos)
        {
            Partidos partidos = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdPartidos,IdEquipos_A,IdEquipo_B,IdRondas,IdTorneo,Resultado
                    FROM Partidos WHERE IdPartidos=@IdPartidos";
                partidos = conn.QuerySingleOrDefault<Partidos>(selectQuery,
                    new { IdPartidos=IdPartidos });
            }
            return partidos;
        }

        public List<PartidosDTO> GetPartidosPorPagina(int cantidad, int paginaActual, int? IdTorneo)
        {
            List<PartidosDTO> lista = new List<PartidosDTO>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                if (IdTorneo == null)
                {
                    string selectQuery = @"SELECT p.IdPartidos,e.NombreEquipos as NombreEquipo_A,eq.NombreEquipos as NombreEquipo_B,r.NombreDeRondas ,c.NombreCategoria ,Resultado
                                FROM Partidos p 
                             Inner Join Equipos e on p.IdEquipos_A = e.IdEquipos 
							 inner join Equipos eq on p.IdEquipo_B = eq.IdEquipos 
                                INNER JOIN Rondas r  on p.IdRondas= r.IdRondas
                                INNER JOIN Torneo t  on p.IdTorneo= t.IdTorneo
                                INNER JOIN Categorias c on t.IdCategoria=c.IdCategoria 
                                ORDER BY c.NombreCategoria
                                OFFSET @cantidadRegistros ROWS 
                                FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    var registrosSateados = cantidad * (paginaActual - 1);

                    lista = conn.Query<PartidosDTO>(selectQuery, new
                    {
                        cantidadRegistros = registrosSateados,
                        cantidadPorPagina = cantidad
                    }).ToList();
                }
                else
                {
                    string selectQuery = @"SELECT p.IdPartidos,e.IdEquipos_A,e.IdEquipo_B,r.IdRondas,t.IdRondas,Resultado
                                FROM Partidos  t INNER JOIN Equipos e
                                ON p.IdEquipos=e.IdEquipos
                                INNER JOIN Rondas r  on p.IdRondas= r.IdRondas
                                INNER JOIN Torneo t  on p.IdTorneo= t.IdTorneo
                                WHERE
                                ORDER BY t.NombreCategoria
                                OFFSET @cantidadRegistros ROWS 
                                FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    var registrosSateados = cantidad * (paginaActual - 1);

                    lista = conn.Query<PartidosDTO>(selectQuery, new
                    {
                        IdTorneo = IdTorneo.Value,
                        cantidadRegistros = registrosSateados,
                        cantidadPorPagina = cantidad
                    }).ToList();

                }
            }
            return lista;
        }
    }
}
