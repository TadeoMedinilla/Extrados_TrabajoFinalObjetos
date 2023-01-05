using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios
{
    internal class SQL_Methods<T> where T : class
    {
        private Configuracion configuracion = new Configuracion();

        protected async Task<List<T>> SQL_Query(string query)
        {
            string sentencia = query;
            List<T> aux_List;

            using (var connection = new SqlConnection(configuracion.DB_Connection))
            {
                var ListaTask = await connection.QueryAsync<T>(query);
                aux_List = ListaTask.ToList();
            }
            return aux_List;
        }

        protected T SQL_QueryFirstOrDefault(string query, T Buscar)
        {
            string sentencia = query;
            T aux;

            using (var connection = new SqlConnection(configuracion.DB_Connection))
            {
                aux = connection.QueryFirstOrDefault<T>(sentencia, Buscar);
            };
            return aux;
        }

        protected async Task SQL_Executable(string query, T aModificar)
        {
            string ejecutar = query;

            using (var connection = new SqlConnection(configuracion.DB_Connection))
            {
                await connection.ExecuteAsync(ejecutar, aModificar);
            }
        }

    }
}
