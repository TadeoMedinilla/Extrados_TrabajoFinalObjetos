using Hotel.DTOs;
using Hotel.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hotel
{
    internal class Aplicacion
    {
        private Consultas consulta { get; }
        private EmpleadoDTO Personal { get; set; }

        //DTOs

        private EmpleadoDTO Empleado { get; set; } = new EmpleadoDTO();
        private ClienteDTO Cliente { get; set; } = new ClienteDTO();
        private List<ClienteDTO> ClientesList { get; set; } = new List<ClienteDTO>();
        private ReservaDTO Reserva { get; set; } = new ReservaDTO();
        private List<ReservaDTO> ReservasList { get; set;} = new List<ReservaDTO>();    
        private CuartoDTO Cuarto { get; set; } = new CuartoDTO();
        private List<CuartoDTO> CuartosList { get; set; } = new List<CuartoDTO>();
        private UsuarioDTO User { get; set; } = new UsuarioDTO();

        public Aplicacion()
        {
            consulta = new Consultas();
        }

        public async Task IniciarAplicacion()
        {
            Personal = IniciarSesion();
            Console.WriteLine($"¡Bienvenido {Personal.Emp_Nombre}!");
            if (Personal.Emp_Puesto != 1) 
            {
                await MenuAAP();
            }
            else
            {
                await MenuAdmin();
            }
        }

        private EmpleadoDTO IniciarSesion()
        {
            while (true)
            {
                Console.Write("¡Bienvenido!\nIngrese su mail:\t");
                string mail = Console.ReadLine();
                
                Console.Write("Ingrese su contraseña:\t");
                string password = Console.ReadLine();
                
                Personal = consulta.LogIn(mail,password);
                
                if (Personal != null)
                {
                    break;
                }
            }
            return Personal;
        }

        private async Task MenuAAP()
        {
            bool interruptor1 = true;
            while (interruptor1)
            {
                Console.Write("\tMENU DE CONSULTAS:\n" +
                                         "A.\tConsultas sobre reservas.\n" +
                                         "B.\tConsultas sobre cuartos.\n" +
                                         "C.\tConsultas sobre clientes.\n" +
                                         "D.\tSalir.\n" +
                                         "Seleccione una opcion:\t");
                string Opcion = Console.ReadLine().ToUpper();
                switch (Opcion)
                {
                    case "A": // RESERVAS

                        await ConsultasAAPReservas();
                        break;

                    case "B": // CUARTOS

                        await ConsultasAAPCuartos();
                        break;

                    case "C": // CLIENTES

                        await ConsultasAAPClientes();
                        break;

                    case "D":

                        interruptor1 = false;
                        break;
                }
            }
            
        }

        private async Task ConsultasAAPCuartos()
        {
            bool interruptor = true;
            while (interruptor)
            {
                Console.Write("\tMENU DE CONSULTAS A CUARTOS\nA.\tListar cuartos.\n" +
                          "B.\tEstado de un cuarto.\n" +
                          "C.\tCambiar estado de un cuarto.\n" +
                          "D.\tInformacion de un cuarto.\n" +
                          "E.\tVolver.\n" +
                          "Seleccione una opcion:\t");
                string Opcion1 = Console.ReadLine().ToUpper();
                switch (Opcion1)
                {
                    case "A": //Listar Cuartos

                        CuartosList = await consulta.AAP_ListarCuartosDisponibles();
                        foreach (CuartoDTO cuarto in CuartosList)
                        {
                            cuarto.ImprimirDatos();
                        }
                        break;

                    case "B": //Estado de un cuarto

                        Console.Write("Ingrese el numero de cuarto que desea buscar:\t");
                        int CuartoID1 = Convert.ToInt16(Console.ReadLine());

                        Cuarto = consulta.AAP_EstadoCuarto(CuartoID1);
                        Cuarto.ImprimirDetalle();
                        break;

                    case "C": //Cambiar estado de un cuarto

                        Console.Write("Ingrese el numero de cuarto que desea modificar:\t");
                        int CuartoID2 = Convert.ToInt16(Console.ReadLine());

                        Console.Write("0. Disponible\n1.En Limpieza\nSeleccione el estado del cuarto:\t");
                        int Estado = Convert.ToInt16(Console.ReadLine());

                        await consulta.AAP_CambiarEstadoCuarto(CuartoID2, Estado);
                        break;

                    case "D": //Informacion de un cuarto.

                        Console.Write("Ingrese el numero de cuarto que desea buscar:\t");
                        int CuartoID3 = Convert.ToInt16(Console.ReadLine());

                        Cuarto = consulta.AAP_InfoCuarto(CuartoID3);
                        Cuarto.ImprimirDetalle();
                        break;
                    case "E":
                        
                        interruptor = false;
                        break;
                }
            }
            
        }

        private async Task ConsultasAAPReservas()
        {
            bool interruptor = true; 
            while (interruptor)
            {
                Console.Write("\tMENU DE CONSULTAS A RESERVAS\nA.\tIngresar nueva reserva.\n" +
                          "B.\tInfo de una reserva.\n" +
                          "C.\tListar reservas activas.\n" +
                          "D.\tCambiar estado de una reserva.\n" +
                          "E.\tVolver.\n" +
                          "Seleccione una opcion:\t");
                string Opcion = Console.ReadLine().ToUpper();
                switch (Opcion)
                {
                    case "A"://Ingresar nueva reserva

                        Reserva.SolicitarDatos();
                        await consulta.AAP_NuevaReserva(Reserva);
                        break;

                    case "B"://Info de una reserva

                        Console.Write("Ingrese el numero de reserva que desea buscar:\t");
                        int ReservaID1 = Convert.ToInt16(Console.ReadLine());

                        Reserva = consulta.AAP_InfoReserva(ReservaID1);
                        Reserva.ImprimirDetalle();
                        break;

                    case "C"://Listar reservas activas

                        ReservasList = await consulta.AAP_ListarReservasActivas();
                        foreach (ReservaDTO reserva in ReservasList)
                        {
                            reserva.ImprimirDatos();
                        }
                        break;

                    case "D"://Cambiar el estado de una reserva

                        Console.Write("Ingrese el numero de reserva que desea modificar:\t");
                        int ReservaID2 = Convert.ToInt16(Console.ReadLine());

                        Console.Write("0. Activa\n1.Cancelada\nSeleccione el estado del cuarto:\t");
                        int Estado = Convert.ToInt16(Console.ReadLine());

                        await consulta.AAP_CambiarEstadoReserva(ReservaID2, Estado);
                        break;
                    case "E":

                        interruptor = false;
                        break;
                }
            }
            
        }
        
        private async Task ConsultasAAPClientes()
        {
            bool interruptor = true;
            while (interruptor)
            {
                Console.Write("\tMENU DE CONSULTAS A CLIENTES\nA.\tIngresar nuevo cliente.\n" +
                          "B.\tInfo de un cliente.\n" +
                          "C.\tListar clientes.\n" +
                          "D.\tVolver\n" +
                          "Seleccione una opcion:\t");
                string Opcion = Console.ReadLine().ToUpper();
                switch (Opcion)
                {
                    case "A"://Nuevo cliente. 

                        Cliente.SolicitarDatos();
                        await consulta.AAP_NuevoCliente(Cliente);
                        break;

                    case "B"://Info Cliente.

                        Console.Write("Ingrese el numero de cliente que desea buscar:\t");
                        int ClienteID1 = Convert.ToInt16(Console.ReadLine());

                        Cliente = consulta.AAP_InfoCliente(ClienteID1);
                        Cliente.ImprimirDetalle();
                        break;

                    case "C"://Listar clientes 

                        ClientesList = await consulta.AAP_ListarClientes();
                        foreach (ClienteDTO cliente in ClientesList)
                        {
                            cliente.ImprimirDatos();
                        }
                        break;

                    case "D":

                        interruptor = false;
                        break;
                }
            }
            
        }

        private async Task MenuAdmin()
        {
            bool interruptor1 = true;
            while (interruptor1)
            {
                Console.Write("\tMENU DE CONSULTAS:\n" +
                                         "A.\tIngresar nuevo cuarto.\n" +
                                         "B.\tCambiar estado de un cuarto.\n" +
                                         "C.\tRegistrar nuevo empleado.\n" +
                                         "D.\tRegistrar nuevo usuario.\n" +
                                         "E.\tSalir.\n" +
                                         "Seleccione una opcion:\t");
                string Opcion = Console.ReadLine().ToUpper();
                switch (Opcion)
                {
                    case "A": // Ingresar nuevo cuarto.

                        Cuarto.SolicitarDatos();
                        await consulta.Admin_NuevoCuarto(Cuarto);
                        break;

                    case "B": // Cambiar estado de un cuarto.

                        Console.Write("Ingrese el numero de cuarto que desea modificar:\t");
                        int CuartoID = Convert.ToInt16(Console.ReadLine());

                        Console.Write("0. Disponible\n1. En Limpieza\n2. En renovacion\nSeleccione el estado del cuarto:\t");
                        int Estado = Convert.ToInt16(Console.ReadLine());

                        await consulta.Admin_CambiarEstadoCuarto(CuartoID,Estado);
                        break;

                    case "C": // Registrar nuevo empleado

                        Empleado.SolicitarDatos();
                        await consulta.Admin_NuevoEmpleado(Empleado);
                        break;

                    case "D": // Resgistrar nuevo usuario

                        User.SolicitarDatos();
                        await consulta.Admin_NuevoUser(User);
                        break;

                    case "E": //Salir

                        interruptor1 = false;
                        break;
                }
            }
        }
    }
}
