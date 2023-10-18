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
    public class RepositorioRondas : IRepositorioRondas
    {
        private readonly string cadenaConexion;
        public RepositorioRondas()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(Rondas rondas)
        {
            using (var conn = new SqlConnection(cadenaConexion))

            {
                string insertQuery = @"INSERT INTO Rondas (NombreDeRondas)
                    VALUES(@NombreDeRondas);
                    SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, rondas);
                rondas.IdRondas = id;
            }
        }

        public void Borrar(int IdRondas)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Rondas
                            WHERE IdRondas=@IdRondas";
                conn.Execute(deleteQuery, new { IdRondas });
            }
        }

        public void Editar(Rondas rondas)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Rondas SET NombreDeRondas=@NombreDeRondas
                                   WHERE IdRondas=@IdRondas";
                conn.Execute(updateQuery, rondas);
            }
        }

        public bool Existe(Rondas rondas)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (rondas.IdRondas == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Rondas 
                            WHERE NombreDeRondas=@NombreDeRondas";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, rondas);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Rondas
                    WHERE NombreDeRondas=@NombreDeRondas AND IdRondas<>@IdRondas";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, rondas);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Rondas";
                cantidad = conn.ExecuteScalar<int>(selectQuery);
            }
            return cantidad;
        }

        public List<Rondas> GetRondas()
        {
            List<Rondas> lista = new List<Rondas>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdRondas, NombreDeRondas
                         FROM Rondas ORDER BY NombreDeRondas";
                lista = conn.Query<Rondas>(selectQuery).ToList();
            }
            return lista;
        }

        public List<Rondas> GetRondasPorPagina(int cantidad, int pagina)
        {
            List<Rondas> lista = new List<Rondas>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdRondas, NombreDeRondas FROM Rondas
                    ORDER BY NombreDeRondas
                    OFFSET @cantidadRegistros ROWS 
                    FETCH NEXT @cantidad ROWS ONLY";
                var cantidadRegistros = cantidad * (pagina - 1);
                lista = conn.Query<Rondas>(selectQuery, new { cantidadRegistros, cantidad }).ToList();
            }
            return lista;
        }
    }
}
