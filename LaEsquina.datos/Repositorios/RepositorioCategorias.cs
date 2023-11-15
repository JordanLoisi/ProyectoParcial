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
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly string cadenaConexion;
        public RepositorioCategorias()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(Categorias categorias)
        {
            using (var conn = new SqlConnection(cadenaConexion))

            {
                string insertQuery = @"INSERT INTO Categorias (NombreCategoria)
                    VALUES(@NombreCategoria);
                    SELECT SCOPE_IDENTITY()";
                int id = conn.QuerySingle<int>(insertQuery, categorias);
                categorias.IdCategoria = id;
            }
        }

        public void Borrar(int IdCategoria)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Categorias
                            WHERE IdCategoria=@IdCategoria";
                conn.Execute(deleteQuery, new { IdCategoria });
            }
        }

        public void Editar(Categorias categoria)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Categorias SET NombreCategoria=@NombreCategoria
                                   WHERE IdCategoria=@IdCategoria";
                conn.Execute(updateQuery, categoria);
            }
        }

        public bool Existe(Categorias categoria)
        {
            var cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (categoria.IdCategoria == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Categorias 
                            WHERE NombreCategoria=@NombreCategoria";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, categoria);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Categorias
                    WHERE NombreCategoria=@NombreCategoria AND IdCategoria<>@IdCategoria";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, categoria);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = "SELECT COUNT(*) FROM Categorias";
                cantidad = conn.ExecuteScalar<int>(selectQuery);
            }
            return cantidad;
        }

        public Categorias GetCategoriaPorId(int categoriaId)
        {
            Categorias categorias = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdCategoria, NombreCategoria
                    FROM Categorias WHERE IdCategoria=@CategoriaId";
                categorias = conn.QuerySingleOrDefault<Categorias>(selectQuery,
                    new { CategoriaId= categoriaId });
            }
            return categorias;
        }

        public List<Categorias> GetCategorias()
        {
            List<Categorias> lista = new List<Categorias>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdCategoria, NombreCategoria
                         FROM Categorias ORDER BY NombreCategoria";
                lista = conn.Query<Categorias>(selectQuery).ToList();
            }
            return lista;
        }

        public List<Categorias> GetCategoriasPorPagina(int cantidad, int pagina)
        {
            List<Categorias> lista = new List<Categorias>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdCategoria, NombreCategoria FROM Categorias
                    ORDER BY NombreCategoria
                    OFFSET @cantidadRegistros ROWS 
                    FETCH NEXT @cantidad ROWS ONLY";
                var cantidadRegistros = cantidad * (pagina - 1);
                lista = conn.Query<Categorias>(selectQuery, new { cantidadRegistros, cantidad }).ToList();
            }
            return lista;
        }
    }
}
