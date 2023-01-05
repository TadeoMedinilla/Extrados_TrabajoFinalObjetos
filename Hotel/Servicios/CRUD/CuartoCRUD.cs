using Hotel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios.CRUDs
{
    internal class CuartoCRUD : SQL_Methods<Cuarto>, IGenericCRUD<Cuarto>
    {
        private Cuarto cuarto { get; set; }
        private List<Cuarto> cuartoList { get; set; }

        //Querys:

        private string InsertQuery = "";

        private string SelectQuery = "";
        private string SelectFirstOrDefault = "";

        private string UpdateQuery = "";


        public CuartoCRUD() { }

        //CRUD:
        public async Task Insertar(Cuarto aInsertar)
        {
            string sentencia = InsertQuery;

            await SQL_Executable(sentencia, aInsertar);
        }

        public async Task<List<Cuarto>> Select()
        {
            string sentencia = SelectQuery;

            cuartoList = await SQL_Query(sentencia);

            return cuartoList;
        }

        public Cuarto BuscarPorID(int ID)
        {
            Cuarto aux_cuarto = new Cuarto();
            aux_cuarto.Cuarto_ID = ID;

            string sentencia = SelectFirstOrDefault;

            cuarto = SQL_QueryFirstOrDefault(sentencia, aux_cuarto);

            return cuarto;
        }

        public async Task Update(int ID)
        {
            cuarto = BuscarPorID(ID);
            await SQL_Executable(UpdateQuery, cuarto);
        }
    }
}
