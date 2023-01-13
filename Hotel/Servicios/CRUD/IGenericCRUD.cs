using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios.CRUDs
{
    internal interface IGenericCRUD<T> where T : class
    {
        public Task Insertar(T aInsertar);

        public Task<List<T>> Select();

        public T BuscarPorID(int ID);

        public Task Update(T aModificar);
    }
}
