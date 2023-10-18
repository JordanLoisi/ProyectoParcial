using Dapper;
using LaEsquina.comun.Interfaces;
using LaEsquina.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaEsquina.datos.Repositorios
{
    public class RepositorioCanchas : IRepositorioCanchas
    {
        private readonly string cadenaConexion;
        public RepositorioCanchas()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(Canchas canchas)
        {
            using (var conn = new SqlConnection(cadenaConexion))

            {
                string insertQuery = @"INSERT INTO Canchas (Nombre)
                    VALUES(@Nombre);
                    SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, canchas);
                canchas.IdCanchas = id;
            }
        }
    

        public void Borrar(int IdCanchas)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Canchas 
                            WHERE IdCanchas=@IdCanchas";
                conn.Execute(deleteQuery, new { IdCanchas });
            }
        }

        public void Editar(Canchas canchas)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Canchas SET Nombre=@Nombre
                                   WHERE IdCanchas=@IdCanchas";
                conn.Execute(updateQuery, canchas);
            }
        }

        public bool Existe(Canchas canchas)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (canchas.IdCanchas == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Canchas 
                            WHERE Nombre=@Nombre";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, canchas);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Canchas
                    WHERE Nombre=@Nombre AND IdCanchas<>@IdCanchas";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, canchas);

                }
            }
            return cantidad > 0;
        }

        public List<Canchas> GetCanchas()
        {
            List<Canchas> lista = new List<Canchas>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdCanchas, Nombre
                         FROM Canchas ORDER BY Nombre";
                lista = conn.Query<Canchas>(selectQuery).ToList();
            }
            return lista;
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Canchas";
                cantidad = conn.ExecuteScalar<int>(selectQuery);
            }
            return cantidad;
        }

        public List<Canchas> GetCanchasPorPagina(int cantidad, int pagina)
        {
            List<Canchas> lista = new List<Canchas>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdCanchas, Nombre FROM Canchas
                    ORDER BY Nombre
                    OFFSET @cantidadRegistros ROWS 
                    FETCH NEXT @cantidad ROWS ONLY";
                var cantidadRegistros = cantidad * (pagina - 1);
                lista = conn.Query<Canchas>(selectQuery, new { cantidadRegistros, cantidad}).ToList();
            }
            return lista;
        }
    }
}
