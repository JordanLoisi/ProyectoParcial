using Dapper;
using LaEsquina.comun.Interfaces;
using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.datos.Repositorios
{
    public class RepositorioTurnos : IRepositorioTurnos
    {
        private readonly string cadenaConexion;
        public RepositorioTurnos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(Turno turno)
        {
            using (var conn = new SqlConnection(cadenaConexion))

            {
                string insertQuery = @"INSERT INTO Turno (Horario)
                    VALUES(@Horario);
                    SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, turno);
                turno.IdTurnos = id;
            }
        }

        public void Borrar(int IdTurnos)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Turno 
                            WHERE IdTurnos=@IdTurnos";
                conn.Execute(deleteQuery, new { IdTurnos });
            }
        }

        public void Editar(Turno turno)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Turno SET Horario=@Horario
                                   WHERE IdTurnos=@IdTurnos";
                conn.Execute(updateQuery, turno);
            }
        }

        public bool Existe(Turno turno)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (turno.IdTurnos == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Turno
                            WHERE Horario=@Horario";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, turno);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Turno
                    WHERE Horario=@Horario AND IdTurnos<>@IdTurnos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, turno);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Turno";
                cantidad = conn.ExecuteScalar<int>(selectQuery);
            }
            return cantidad;
        }

        public List<Turno> GetTurno()
        {
            List<Turno> lista = new List<Turno>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdTurnos, Horario
                         FROM Turno ORDER BY Horario";
                lista = conn.Query<Turno>(selectQuery).ToList();
            }
            return lista;
        }

        public List<Turno> GetTurnoCombo()
        {
            List<Turno> lista;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdTurnos, Horario FROM Turno
                         ORDER BY Horario";
                lista = conn.Query<Turno>(selectQuery).ToList();

            }
            return lista;
        }

        public Turno GetTurnoPorId(int IdTurno)
        {
            Turno turno = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdTurnos, Horario
                    FROM Torneo WHERE IdTorneo=@IdTorneo";
                turno = conn.QuerySingleOrDefault<Turno>(selectQuery,
                    new { IdTurnos = IdTurno });
            }
            return turno;
        }

        public List<Turno> GetTurnoPorPagina(int cantidad, int pagina)
        {
            List<Turno> lista = new List<Turno>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdTurnos, Horario FROM Turno
                    ORDER BY Horario
                    OFFSET @cantidadRegistros ROWS 
                    FETCH NEXT @cantidad ROWS ONLY";
                var cantidadRegistros = cantidad * (pagina - 1);
                lista = conn.Query<Turno>(selectQuery, new { cantidadRegistros, cantidad }).ToList();
            }
            return lista;
        }
    }
}
