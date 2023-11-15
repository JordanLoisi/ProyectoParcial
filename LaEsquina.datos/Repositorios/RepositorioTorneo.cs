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
    public class RepositorioTorneo : IRepositorioTorneo
    {
        private readonly string cadenaConexion;
        public RepositorioTorneo()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }

        public void Agregar(Torneo torneo)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = @"INSERT INTO Torneo (FechaInicio,FechaFin, IdCategoria)
                    VALUES(@FechaInicio,@FechaFin, @IdCategoria); SELECT SCOPE_IDENTITY()";
                int id = conn.ExecuteScalar<int>(insertQuery, torneo);
                torneo.IdTorneo = id;

            }
        }

        public void Borrar(int IdTorneo)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Torneo 
                        WHERe IdTorneo=@IdTorneo";
                conn.Execute(deleteQuery, new { IdTorneo });
            }
        }

        public void Editar(Torneo torneo)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Torneo SET FechaInicio=@FechaInicio,FechaFin=@FechaFin,IdCategoria=@IdCategoria
                                   WHERE IdTorneo=@IdTorneo";
                conn.Execute(updateQuery, torneo);
            }
        }

        public bool EstaRelacionada(Torneo torneo)
        {
            int cantidadPartidos = 0;
            
           
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM Partidos WHERE IdTorneo=@IdTorneo;
                                        ";
                using (var resultado = conn.QueryMultiple(selectQuery, new { TorneoId = torneo.IdTorneo }))
                {
                    cantidadPartidos = resultado.Read<int>().First();
                    
                }
            }
            return cantidadPartidos > 0;
        }

        public bool Existe(Torneo torneo)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (torneo.IdTorneo == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Torneo
                        WHERE FechaInicio=@FechaInicio AND FechaFin=@FechaFin AND IdCategoria=@IdCategoria";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, torneo);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Torneo 
                            WHERE FechaInicio=@FechaInicio AND FechaFin=@FechaFin AND IdCategoria=@IdCategoria
                            AND IdTorneo!=@IdTorneo";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, torneo);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdCategoria)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (IdCategoria == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Torneo";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Torneo
                        WHERE IdCategoria=@IdCategoria";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { CategoriaId=IdCategoria });
                }
            }
            return cantidad;
        }

       

        public List<TorneoDTO> GetTorneoPorPagina(int cantidad, int paginaActual, int? IdCategoria)
        {
            List<TorneoDTO> lista = new List<TorneoDTO>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                if (IdCategoria == null)
                {
                    string selectQuery = @"SELECT t.IdTorneo, t.FechaInicio, t.FechaFin,c.NombreCategoria
                                FROM Torneo  t INNER JOIN Categorias c
                                ON t.IdCategoria=c.IdCategoria
                                ORDER BY c.NombreCategoria
                                OFFSET @cantidadRegistros ROWS 
                                FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    var registrosSateados = cantidad * (paginaActual - 1);

                    lista = conn.Query<TorneoDTO>(selectQuery, new
                    {
                        cantidadRegistros = registrosSateados,
                        cantidadPorPagina = cantidad
                    }).ToList();
                }
                else
                {
                    string selectQuery = @"SELECT IdTorneo, FechaInicio, FechaFin,IdCategoria
                                FROM Torneo INNER JOIN Categoria
                                ON Torneo.IdCategoria=Categoria.IdCategoria
                                WHERE Torneo.IdCategoria=@IdCategoria
                                ORDER BY Torneo.IdCategoria
                                OFFSET @cantidadRegistros ROWS 
                                FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    var registrosSateados = cantidad * (paginaActual - 1);

                    lista = conn.Query<TorneoDTO>(selectQuery, new
                    {
                        IdCategoria = IdCategoria.Value,
                        cantidadRegistros = registrosSateados,
                        cantidadPorPagina = cantidad
                    }).ToList();

                }
            }
            return lista;

        }

        public Torneo GetTorneoPorId(int IdTorneo)
        {
            Torneo torneo = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdTorneo, FechaInicio,FechaFin, IdCategoria
                    FROM Torneo WHERE IdTorneo=@IdTorneo";
                torneo = conn.QuerySingleOrDefault<Torneo>(selectQuery,
                    new { IdTorneo = IdTorneo });
            }
            return torneo;
        }

        public List<Torneo> GetTorneoCombo()
        {
            List<Torneo> lista;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdTorneo, FechaInicio,FechaFin,IdCategoria FROM Torneo
                         ORDER BY IdCategoria";
                lista = conn.Query<Torneo>(selectQuery).ToList();

            }
            return lista;
        }
    }
}
