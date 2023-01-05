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
    internal class EmpleadoCRUD : IGenericCRUD<Empleado>
    {
        private Configuracion configuracion { get; set; }
        private Empleado emp { get; set; }
        private List<Empleado> empList { get; set; }
        private EmpleadoDTO empDTO { get; set; }
        private List<EmpleadoDTO> empDTOList { get; set; }

        private string InsertQuery = "";
        
        private string SelectQuery = "";
        private string SelectFirstOrDefault = "";
        
        private string UpdateQuery = "";


        public EmpleadoCRUD(Configuracion config)
        {
            this.configuracion = config;
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

        public async Task Update(int ID)
            //No se va a utilizar
        {
            emp = BuscarPorID(ID);
            await SQL_Executable(UpdateQuery, emp);
        }



        //Metodos de ejecucion sobre la BD:
        /*
        [Todos los metodos privados trabajan y devuelven entidades originales.
        Hago uso de DTOs cuando necesito recibir algo del usuario o necesito mostrarle algo.]
         */
        protected Empleado SQL_QueryFirstOrDefault(string query, Empleado Buscar)
            //Para buscar el primer resultado.
        {
            string sentencia = query;
            Empleado aux_emp;
            
            using (var connection = new SqlConnection(configuracion.DB_Connection)) 
            {
                aux_emp = connection.QueryFirstOrDefault<Empleado>(sentencia, Buscar);
            };
            return aux_emp;
        }
        
        protected async Task<List<Empleado>> SQL_Query(string query)
            //Para hacer select de mas de un objeto de la BD
        {
            string sentencia = query;
            List<Empleado> aux_empList;
            
            using (var connection = new SqlConnection(configuracion.DB_Connection))
            {
                var ListaTask = await connection.QueryAsync<Empleado>(query);
                aux_empList = ListaTask.ToList();
            }
            return aux_empList;
        }
            
        protected async Task SQL_Executable(string query, Empleado aModificar)
        {
            string ejecutar = query;
            using (var connection = new SqlConnection(configuracion.DB_Connection))
            {
                await connection.ExecuteAsync(ejecutar, aModificar);
            }
        }


        //Metodos auxiliares:
        private Empleado SolicitarID()
        {
            Console.Write("Ingrese el ID del empleado que desea buscar:\t");
            int ID = Convert.ToInt16(Console.ReadLine());
            Empleado aux_emp = new Empleado();
            aux_emp.Emp_ID = ID;

            return aux_emp;
        }

        private Empleado SolicitarParametros()
        {
            Empleado aux_emp = new Empleado();

            Console.Write("Ingrese el nombre del empleado:\t");
            string Nombre = Console.ReadLine();

            Console.Write("Ingrese la edad del empleado:\t");
            int Edad = Convert.ToInt16(Console.ReadLine());

            Console.Write("Ingrese el puesto del empleado:\t");
            string Puesto = Console.ReadLine();

            Console.Write("Ingrese el mail del empleado:\t");
            string Mail = Console.ReadLine();

            aux_emp = AsignarParametros(Nombre, Edad, Puesto, Mail, aux_emp);

            return aux_emp;
        }
        
        private Empleado AsignarParametros(string Nombre, int Edad, string Puesto, string Mail, Empleado aux_emp)
        {
            aux_emp.Emp_Nombre = Nombre;
            aux_emp.Emp_Edad = Edad;
            aux_emp.Emp_Puesto = Puesto;
            aux_emp.Emp_Mail = Mail;
            
            return aux_emp;
        }

        public void ImprimirEmpleado(EmpleadoDTO empDTO)
            //Imprime un solo empleado.
        {
            Console.WriteLine(@$"Nombre: {empDTO.EmpDTO_Nombre}
                                Edad: {empDTO.EmpDTO_Edad}
                                Mail: {empDTO.EmpDTO_Mail}
                                Puesto: {empDTO.EmpDTO_Puesto}");
        }
    
        public void ImprimirListaEmpleados(List<EmpleadoDTO> Lista)
            //Imprime una lista de empleados
        {
            foreach (EmpleadoDTO empleado in Lista)
            {
                Console.WriteLine(@$"Nombre: {empleado.EmpDTO_Nombre}
                                Edad: {empleado.EmpDTO_Edad}
                                Mail: {empleado.EmpDTO_Mail}
                                Puesto: {empleado.EmpDTO_Puesto}");
            }
        }
    }
}
