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
    public class RepositorioCuotas : IRepositorioCuotas
    {
        private readonly string cadenaConexion;
        public RepositorioCuotas()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }

        public void Agregar(Cuotas cuotas)
        {
            using (var conn = new SqlConnection(cadenaConexion))

            {
                string insertQuery = @"INSERT INTO Cuotas (Mes,Monto)
                    VALUES(@Mes,@Monto);
                    SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, cuotas);
                cuotas.IdCuotas = id;
            }
        }

        public void Borrar(int IdCuotas)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Cuotas 
                            WHERE IdCuotas=@IdCuotas";
                conn.Execute(deleteQuery, new { IdCuotas });
            }
        }

        public void Editar(Cuotas cuotas)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Cuotas SET Mes=@Mes,Monto=@Monto
                                   WHERE IdCuotas=@IdCuotas";
                conn.Execute(updateQuery, cuotas);
            }
        }

        public bool Existe(Cuotas cuotas)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (cuotas.IdCuotas == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Cuotas 
                            WHERE Mes=@Mes,Monto=@Monto";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, cuotas);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Cuotas
                    WHERE Mes=@Mes,Monto=@Monto AND IdCuotas<>@IdCuotas";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, cuotas);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Cuotas";
                cantidad = conn.ExecuteScalar<int>(selectQuery);
            }
            return cantidad;
        }

        public List<Cuotas> GetCuotas()
        {
            List<Cuotas> lista = new List<Cuotas>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdCuotas, Mes,Monto
                         FROM Cuotas ORDER BY Mes";
                lista = conn.Query<Cuotas>(selectQuery).ToList();
            }
            return lista;
        }

        public List<Cuotas> GetCuotasPorPagina(int cantidad, int pagina)
        {

            List<Cuotas> lista = new List<Cuotas>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdCuotas, Mes,Monto FROM Cuotas
                    ORDER BY IdCuotas
                    OFFSET @cantidadRegistros ROWS 
                    FETCH NEXT @cantidad ROWS ONLY";
                var cantidadRegistros = cantidad * (pagina - 1);
                lista = conn.Query<Cuotas>(selectQuery, new { cantidadRegistros, cantidad }).ToList();
            }
            return lista;
        }
    }
}
