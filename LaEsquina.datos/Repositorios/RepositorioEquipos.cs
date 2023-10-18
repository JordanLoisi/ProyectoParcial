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
    public class RepositorioEquipos : IRepositorioEquipos
    {
        private readonly string cadenaConexion;
        public RepositorioEquipos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(Equipos equipos)
        {
            using (var conn = new SqlConnection(cadenaConexion))

            {
                string insertQuery = @"INSERT INTO Equipos (NombreEquipos)
                    VALUES(@NombreEquipos);
                    SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, equipos);
                equipos.IdEquipos = id;
            }
        }

        public void Borrar(int IdEquipos)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Equipos 
                            WHERE IdEquipos=@IdEquipos";
                conn.Execute(deleteQuery, new { IdEquipos });
            }
        }

        public void Editar(Equipos equipos)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Equipos SET NombreEquipos=@NombreEquipos
                                   WHERE IdEquipos=@IdEquipos";
                conn.Execute(updateQuery, equipos);
            }
        }

        public bool Existe(Equipos equipos)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (equipos.IdEquipos == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Equipos
                            WHERE NombreEquipos=@NombreEquipos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, equipos);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Equipos
                    WHERE NombreEquipos=@NombreEquipos AND IdEquipos<>@IdEquipos";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, equipos);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Equipos";
                cantidad = conn.ExecuteScalar<int>(selectQuery);
            }
            return cantidad;
        }

        public List<Equipos> GetEquipos()
        {
            List<Equipos> lista = new List<Equipos>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdEquipos, NombreEquipos
                         FROM Equipos ORDER BY NombreEquipos";
                lista = conn.Query<Equipos>(selectQuery).ToList();
            }
            return lista;
        }

        public List<Equipos> GetEquiposPorPagina(int cantidad, int pagina)
        {
            List<Equipos> lista = new List<Equipos>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdEquipos, NombreEquipos FROM Equipos
                    ORDER BY NombreEquipos
                    OFFSET @cantidadRegistros ROWS 
                    FETCH NEXT @cantidad ROWS ONLY";
                var cantidadRegistros = cantidad * (pagina - 1);
                lista = conn.Query<Equipos>(selectQuery, new { cantidadRegistros, cantidad }).ToList();
            }
            return lista;
        }
    }
}
