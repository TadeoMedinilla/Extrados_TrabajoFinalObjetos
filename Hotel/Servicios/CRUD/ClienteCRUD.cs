
using Dapper;
using Hotel.DTOs;
using Hotel.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios.CRUDs
{
    internal class ClienteCRUD : SQL_Methods<Cliente>, IGenericCRUD<Cliente>
    {

        private Cliente cli { get; set; }
        private List<Cliente> cliList { get; set; }

        //Querys:
        private string InsertQuery = "INSERT INTO Cliente (Cli_Nombre, Cli_Mail) VALUES (@Cli_Nombre, @Cli_Mail);";

        private string SelectQuery = "SELECT Cli_ID, Cli_Nombre, Cli_Mail FROM Cliente;";
        private string SelectFirstOrDefault = "SELECT Cli_ID, Cli_Nombre, Cli_Mail FROM Cliente WHERE Cli_ID = @Cli_ID;";

        private string UpdateQuery = ""; //No se usa.

        public ClienteCRUD()
        {

        }

        //CRUD:

        public async Task Insertar(Cliente aInsertar)
            //Create 
        {
            string sentencia = InsertQuery;

            await SQL_Executable(sentencia, aInsertar);
        }

        public async Task<List<Cliente>> Select()
            //Read all 
        {
            string sentencia = SelectQuery;
            cliList = await SQL_Query(sentencia);

            return cliList;
        }

        public Cliente BuscarPorID(int ID)
            //Read One 
        {
            Cliente aux_cli = new Cliente();
            aux_cli.Cli_ID = ID;

            string sentencia = SelectFirstOrDefault;

            cli = SQL_QueryFirstOrDefault(sentencia, aux_cli);

            return cli;
        }

        public Task Update(int ID, int Estado)
        {
            throw new NotImplementedException();
        }

        //Metodos de ejecucion sobre la BD: 
        /*
        [Todos los metodos privados trabajan y devuelven entidades originales.
        Hago uso de DTOs cuando necesito recibir algo del usuario o necesito mostrarle algo.]
         */

        /*
        private async Task<List<Cliente>> SQL_Query(string query)
            //Para realizar busquedas de mas de un cliente 
        {
            string sentencia = query;
            List<Cliente> aux_CliList = new List<Cliente>();

            using (var connection = new SqlConnection(configuracion.DB_Connection))
            {
                var ListaTask = await connection.QueryAsync<Cliente>(sentencia);
                aux_CliList= ListaTask.ToList();
            };

            return aux_CliList;
        }

        private Cliente SQL_QueryFirstOrDefault(string query, Cliente Buscar)
            //Para buscar un unico cliente en la BD
        {
            string sentencia = query;
            Cliente aux_cli = new Cliente();

            using (var connection = new SqlConnection(configuracion.DB_Connection))
            {
                aux_cli = connection.QueryFirstOrDefault(sentencia,Buscar);
            };
            return aux_cli;
        }

        private async Task SQL_Executable(string query, Cliente aModificar)
        {
            string sentencia = query;

            using (var connection = new SqlConnection(configuracion.DB_Connection))
            {
                await connection.ExecuteAsync(sentencia, aModificar);
            };
        }
        */


        //Metodos auxiliares:
    }
}
