using Dapper;
using Hotel.DTOs;
using Hotel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios.CRUDs
{
    internal class EmpleadoCRUD : SQL_Methods<Empleado>, IGenericCRUD<Empleado>
    {
        private Empleado emp { get; set; }
        private List<Empleado> empList { get; set; }

        //Querys:

        private string InsertQuery = "";

        private string SelectQuery = "";
        private string SelectFirstOrDefault = "";

        private string UpdateQuery = "";


        public EmpleadoCRUD()
        {

        }

        //CRUD:
        public async Task Insertar(Empleado aInsertar)
            //Create
        {
            string sentencia = InsertQuery;

            await SQL_Executable(sentencia, aInsertar);

        }

        public async Task<List<Empleado>> Select()
            //Read all
        {
            string sentencia = SelectQuery;
            empList = await SQL_Query(sentencia);

            /* [ Esto lo realizo en la capa de servicios ]
            if (empList.Count != 0)
            {
                foreach (Empleado emp in empList)
                {
                    empDTO = configuracion.mapper.Map<Empleado, EmpleadoDTO>(emp);
                    empDTOList.Add(empDTO);
                }
            }
            return empDTOList; */
            return empList;
        }

        public Empleado BuscarPorID(int ID)
            //Read one
        {
            Empleado aux_emp = new Empleado();
            aux_emp.Emp_ID = ID;

            string sentencia = SelectFirstOrDefault;

            emp = SQL_QueryFirstOrDefault(sentencia, aux_emp);

            //empDTO = configuracion.mapper.Map<Empleado, EmpleadoDTO>(emp); [ Esta parte la hago en la capa de servicio ] 

            return emp;
        }

        public async Task Update(Empleado aModificar)
            //No se va a utilizar. 
        {
            emp = BuscarPorID(ID);
            await SQL_Executable(UpdateQuery, emp);
        }

    }
}
