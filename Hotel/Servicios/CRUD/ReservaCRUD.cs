using Hotel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios.CRUDs
{
    internal class ReservaCRUD : SQL_Methods<Reserva>, IGenericCRUD<Reserva>
    {
        private Reserva res { get; set; } = new Reserva();
        private List<Reserva> resList { get; set; } = new List<Reserva> ();

        //Querys:

        private string InsertQuery = "INSERT INTO Hotel.dbo.Reservas (Res_CliID,Res_CuartoID, Res_CheckIn, Res_CheckOut, Res_Estado)\r\nVALUES (@Res_CliID, @Res_CuartoID, @Res_CheckIn, @Res_CheckOut, @Res_Estado);";

        private string SelectQuery = "SELECT  Res_ID, Cliente.Cli_Nombre AS Cliente,\r\n\t\tRes_CliID, Res_CuartoID,\r\n\t\tRes_CheckIn, Res_CheckOut,\r\n\t\tEstadoRes_Descripcion AS Estado\r\nFROM Hotel.dbo.Reservas \r\nJOIN Hotel.dbo.Cliente ON Reservas.Res_CliID = Cliente.Cli_ID\r\nJOIN Hotel.dbo.EstadoReserva ON Reservas.Res_Estado = EstadoRes_ID\r\nWHERE Reservas.Res_Estado = 0; ";
        private string SelectFirstOrDefault = "SELECT  Res_ID, Cliente.Cli_Nombre AS Cliente,\r\n\t\tRes_CliID, Res_CuartoID,\r\n\t\tRes_CheckIn, Res_CheckOut,\r\n\t\tEstadoRes_Descripcion AS Estado\r\nFROM Hotel.dbo.Reservas \r\nJOIN Hotel.dbo.Cliente ON Reservas.Res_CliID = Cliente.Cli_ID\r\nJOIN Hotel.dbo.EstadoReserva ON Reservas.Res_Estado = EstadoRes_ID\r\nWHERE Reservas.Res_ID = @Res_ID ; ";

        private string UpdateQuery = "UPDATE Hotel.dbo.Reservas SET Res_Estado = @Res_Estado WHERE Res_ID = @Res_ID;";

        public ReservaCRUD()
        {

        }

        //CRUD:
        public async Task Insertar(Reserva aInsertar)
        {
            string sentencia = InsertQuery;

            await SQL_Executable(sentencia, aInsertar);
        }

        public async Task<List<Reserva>> Select()
        {
            string sentencia = SelectQuery;

            resList = await SQL_Query(sentencia);

            return resList;
        }

        public Reserva BuscarPorID(int ID)
        {
            Reserva aux_res = new Reserva();
            aux_res.Res_ID = ID;

            string sentencia = SelectFirstOrDefault;

            res = SQL_QueryFirstOrDefault(sentencia, aux_res);

            return res;
        }

        public async Task Update(Reserva aModificar)
            //Modifica el estado de una reserva. 
        {
            string sentencia = UpdateQuery;

            await SQL_Executable(sentencia, aModificar);
        }


    }
}
