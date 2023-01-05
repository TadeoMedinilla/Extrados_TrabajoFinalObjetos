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
        private Reserva res { get; set; }
        private List<Reserva> resList { get; set; }

        //Querys:

        private string InsertQuery = "";

        private string SelectQuery = "";
        private string SelectFirstOrDefault = "";

        private string UpdateQuery = "";

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

        public async Task Update(int ID)
        {
            res = BuscarPorID(ID);

            await SQL_Executable(UpdateQuery, res);
        }
    }
}
