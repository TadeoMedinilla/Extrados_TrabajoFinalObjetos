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

        private string InsertQuery = "INSERT INTO Hotel.dbo.Empleados \r\n\t\t\t(Emp_Nombre, Emp_Edad, Emp_Puesto, Emp_Mail)\r\nVALUES (@Emp_Nombre, @Emp_Edad, @Emp_Puesto, @Emp_Mail);";

        private string SelectQuery = "SELECT Emp_ID,\r\n\t\tEmp_Nombre,\r\n\t\tEmp_Edad,\r\n\t\tPuesto_Descripcion AS Puesto,\r\n\t\tEmp_Mail\r\nFROM Hotel.dbo.Empleados \r\nJOIN Hotel.dbo.Puesto ON Empleados.Emp_Puesto = Puesto.Puesto_ID;";
        private string SelectPuestoQuery = "SELECT Emp_ID,\r\n\t\tEmp_Nombre,\r\n\t\tEmp_Edad,\r\n\t\tPuesto_Descripcion AS Puesto,\r\n\t\tEmp_Mail\r\nFROM Hotel.dbo.Empleados \r\nJOIN Hotel.dbo.Puesto ON Empleados.Emp_Puesto = Puesto.Puesto_ID \r\nWHERE Emp_Puesto = @Emp_Puesto;";
        private string SelectFirstOrDefault = "SELECT Emp_ID,\r\n\t\tEmp_Nombre,\r\n\t\tEmp_Edad,\r\n\t\tPuesto_Descripcion AS Puesto,\r\n\t\tEmp_Mail\r\nFROM Hotel.dbo.Empleados \r\nJOIN Hotel.dbo.Puesto ON Empleados.Emp_Puesto = Puesto.Puesto_ID \r\nWHERE Emp_ID = @Emp_ID;";

        private string LogInSelect = "SELECT Emp_ID, Emp_Nombre, Emp_Puesto, Emp_Mail\r\nFROM Hotel.dbo.Empleados\r\nWHERE Emp_ID = @Emp_ID;";

        private string UpdateQuery = "UPDATE Hotel.dbo.Empleados SET Emp_Puesto = @Emp_Puesto WHERE Emp_ID = @Emp_ID;";


        public EmpleadoCRUD()
        {

        }

        //CRUD:
        public async Task Insertar(Empleado aInsertar)
            //Create. 
        {
            string sentencia = InsertQuery;

            await SQL_Executable(sentencia, aInsertar);

        }

        public async Task<List<Empleado>> Select()
            //Read all. 
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
            //Read one. 
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
            await SQL_Executable(UpdateQuery, aModificar);
        }
        
        public Empleado SelectEmpleado(Empleado Personal)
        {
            string sentencia = LogInSelect;

            emp = SQL_Select(sentencia, Personal);

            return emp;
        }
    }
}
