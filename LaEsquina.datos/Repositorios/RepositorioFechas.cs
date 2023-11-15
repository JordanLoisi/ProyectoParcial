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
    public class RepositorioFechas : IRepositorioFecha
    {
        private readonly string cadenaConexion;
        public RepositorioFechas()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(Fecha fecha)
        {
            using (var conn = new SqlConnection(cadenaConexion))

            {
                string insertQuery = @"INSERT INTO Fecha (Dia,Torneo)
                    VALUES(@Dia,@Torneo);
                    SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, fecha);
                fecha.IdFechas = id;
            }
        }

        public void Borrar(int IdFechas)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Fecha
                            WHERE IdFechas=@IdFechas";
                conn.Execute(deleteQuery, new { IdFechas });
            }
        }

        public void Editar(Fecha fechas)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Fecha SET Dia=@Dia,Torneo=@Torneo
                                   WHERE IdFechas=@IdFechas";
                conn.Execute(updateQuery, fechas);
            }
        }

        public bool Existe(Fecha fecha)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (fecha.IdFechas == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Fecha
                            WHERE Dia=@Dia AND Torneo=@Torneo";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, fecha);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Fecha
                    WHERE Dia=@Dia,Torneo=@Torneo AND IdFechas<>@IdFechas";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, fecha);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Fecha";
                cantidad = conn.ExecuteScalar<int>(selectQuery);
            }
            return cantidad;
        }

        public Fecha GetFechaPorId(int IdFechas)
        {
            Fecha fecha = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdFechas, Dia
                    FROM Fecha WHERE IdFechas=@IdFechas";
                fecha = conn.QuerySingleOrDefault<Fecha>(selectQuery,
                    new { IdFechas = IdFechas });
            }
            return fecha;
        }

        public List<Fecha> GetFechas()
        {
            List<Fecha> lista = new List<Fecha>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdFechas, Dia,Torneo
                         FROM Fecha ORDER BY Dia";
                lista = conn.Query<Fecha>(selectQuery).ToList();
            }
            return lista;
        }

        public List<Fecha> GetFechasCombo()
        {
            List<Fecha> lista;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdFechas, Dia FROM Fecha WHere Torneo=0
                         ORDER BY Dia";
                lista = conn.Query<Fecha>(selectQuery).ToList();

            }
            return lista;
        }

        public List<Fecha> GetFechasPorPagina(int cantidad, int pagina)
        {
            List<Fecha> lista = new List<Fecha>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdFechas, Dia,Torneo FROM Fecha
                    ORDER BY Dia
                    OFFSET @cantidadRegistros ROWS 
                    FETCH NEXT @cantidad ROWS ONLY";
                var cantidadRegistros = cantidad * (pagina - 1);
                lista = conn.Query<Fecha>(selectQuery, new { cantidadRegistros, cantidad }).ToList();
            }
            return lista;
        }
    }
}
