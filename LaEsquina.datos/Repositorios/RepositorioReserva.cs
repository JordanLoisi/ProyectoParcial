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
    public class RepositorioReserva : IRepositorioReserva
    {
        private readonly string cadenaConexion;
        public RepositorioReserva()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

        }
        public void Agregar(Reserva reserva)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string insertQuery = @"INSERT INTO Reserva (IdTurnos,IdCanchas, IdMiembros,IdFechas)
                    VALUES(@IdTurnos,@IdCanchas,@IdMiembros, @IdFechas); SELECT SCOPE_IDENTITY()";
                int id = conn.ExecuteScalar<int>(insertQuery, reserva);
                reserva.IdReserva= id;

            }
        }

        public void Borrar(int IdReserva)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string deleteQuery = @"DELETE FROM Reserva 
                        WHERE IdReservas=@IdReserva";
                conn.Execute(deleteQuery, new { IdReserva });
            }
        }

        public void Editar(Reserva reserva)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string updateQuery = @"UPDATE Torneo SET IdTurnos=@IdTurnos,IdCanchas=@IdCanchas,IdMiembros=@IdMiembros, IdFechas=@IdFechas
                                   WHERE IdReserva=@IdReserva";
                conn.Execute(updateQuery, reserva);
            }
        }

        public bool EstaRelacionada(Reserva reserva)
        {
            int cantidadTurno = 0;


            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT COUNT(*) FROM Reserva WHERE IdReservas=@IdReserva;
                                        ";
                using (var resultado = conn.QueryMultiple(selectQuery, new { IdReserva = reserva.IdReserva }))
                {
                    cantidadTurno = resultado.Read<int>().First();

                }
            }
            return cantidadTurno > 0;
        }

        public bool Existe(Reserva reserva)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (reserva.IdReserva == 0)
                {
                    selectQuery = @"SELECT COUNT(*) FROM Reserva
                        WHERE IdTurnos=@IdTurnos and IdCanchas=@IdCanchas and IdMiembros=@IdMiembros and IdFechas=@IdFechas";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, reserva);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Reserva
                            WHERE IdTurnos=@IdTurnos,IdCanchas=@IdCanchas,IdMiembros=@IdMiembros, IdFechas=@IdFechas
                            AND IdReservas!=@IdReserva";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, reserva);

                }
            }
            return cantidad > 0;
        }

        public int GetCantidad(int? IdFecha)
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery;
                if (IdFecha == null)
                {
                    selectQuery = "SELECT COUNT(*) FROM Reserva";
                    cantidad = conn.ExecuteScalar<int>(selectQuery);
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*) FROM Reserva
                        WHERE IdFecha=@IdFecha";
                    cantidad = conn.ExecuteScalar<int>(selectQuery, new { IdFecha=IdFecha });
                }
            }
            return cantidad;
        }

        public List<ReservaDTO> GetReservaPorPagina(int cantidad, int paginaActual, int? IdFecha)
        {
            List<ReservaDTO> lista = new List<ReservaDTO>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                if (IdFecha == null)
                {
                    string selectQuery = @"SELECT r.IdReservas,t.Horario,c.Nombre as NombreCancha,m.Nombre as NombreMiembro,m.Apellido,f.Dia
                                FROM Reserva r INNER JOIN Turno t
                                ON r.IdTurnos=t.IdTurnos
                                INNER JOIN Canchas c on r.IdCanchas= c.IdCanchas
                                INNER JOIN Miembros m on r.IdMiembros= m.IdMiembros
                                INNER JOIN Fecha f on r.IdFechas= f.IdFechas
                                ORDER BY f.Dia
                                OFFSET @cantidadRegistros ROWS 
                                FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    var registrosSateados = cantidad * (paginaActual - 1);

                    lista = conn.Query<ReservaDTO>(selectQuery, new
                    {
                        cantidadRegistros = registrosSateados,
                        cantidadPorPagina = cantidad
                    }).ToList();
                }
                else
                {
                    string selectQuery = @"SELECT IdReserva,IdTurnos,IdCanchas,IdMiembros,IdFechas
                                FROM Reserva INNER JOIN Turno
                                ON Reserva.IdTurnos=Turno.IdTurnos
                                INNER JOIN Canchas on Reserva.IdCanchas= Canchas.IdCanchas
                                INNER JOIN Miembros on Reserva.IdMiembros= Miembros.IdMiembros
                                INNER JOIN Fechas on Reserva.IdFecha= Fecha.IdFechas
                                Where
                                ORDER BY Reserva.IdReserva
                                OFFSET @cantidadRegistros ROWS 
                                FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    var registrosSateados = cantidad * (paginaActual - 1);

                    lista = conn.Query<ReservaDTO>(selectQuery, new
                    {
                        IdFecha =IdFecha.Value,
                        cantidadRegistros = registrosSateados,
                        cantidadPorPagina = cantidad
                    }).ToList();

                }
            }
            return lista;
        }

        public Reserva GetReservaPorId(int IdReserva)
        {
            Reserva reserva = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string selectQuery = @"SELECT IdReservas,IdTurnos,IdCanchas,IdMiembros,IdFechas
                    FROM Reserva WHERE IdReservas=@IdReservas";
                reserva = conn.QuerySingleOrDefault<Reserva>(selectQuery,
                    new { IdReservas= IdReserva });
            }
            return reserva;
        }
    }
}
