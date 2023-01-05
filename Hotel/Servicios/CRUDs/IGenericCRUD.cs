using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios.CRUDs
{
    internal interface IGenericCRUD<T> where T : class
    {
        //CRUD:
        public Task Insertar(T aInsertar);

        public Task<List<T>> Select();

        public T BuscarPorID(int ID);

        public Task Update(int ID);

        //Metodos de ejecucion sobre BD:

        //protected T SQL_QueryFirstOrDefault(string query, T Buscar);

        //protected Task<List<T>> SQL_Query(string query);

        //protected Task SQL_executable(string query, T aModificar);

    }
}
