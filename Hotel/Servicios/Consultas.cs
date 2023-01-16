using Hotel.DTOs;
using Hotel.Entidades;
using Hotel.Servicios.CRUDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios
{
    internal class Consultas
    {
        private Mapper mapper { get; } = new Mapper();

        private Cuarto Cuarto { get; set; } = new Cuarto();
        private List<Cuarto> CuartoList { get; set; } = new List<Cuarto>();
        private CuartoDTO CuartoDTO { get; set; } = new CuartoDTO();
        private List<CuartoDTO> CuartoDTOList { get; set; } = new List<CuartoDTO>();
        private CuartoCRUD CuartoCRUD { get; set; } = new CuartoCRUD(); 

        private Cliente Cliente { get; set; } = new Cliente();
        private List<Cliente> ClienteList { get; set; } = new List<Cliente>();
        private ClienteDTO ClienteDTO { get; set; } = new ClienteDTO();
        private List<ClienteDTO> ClienteDTOList { get; set; } = new List<ClienteDTO>();
        private ClienteCRUD ClienteCRUD { get; set; } = new ClienteCRUD();

        private Reserva Reserva { get; set; } = new Reserva();
        private List<Reserva> ReservaList { get; set; } = new List<Reserva>(); 
        private ReservaDTO ReservaDTO { get; set; } = new ReservaDTO();
        private List<ReservaDTO> ReservaDTOList { get; set; } = new List<ReservaDTO>();
        private ReservaCRUD ReservaCRUD { get; set; } = new ReservaCRUD();

        private Empleado Empleado { get; set; } = new Empleado();
        private List<Empleado> EmpleadoList { get; set; } = new List<Empleado>(); 
        private EmpleadoDTO EmpleadoDTO { get; set; } = new EmpleadoDTO();
        private EmpleadoCRUD EmpleadoCRUD { get; set; } = new EmpleadoCRUD();

        private Usuario User { get; set; } = new Usuario();
        private UsuarioDTO UserDTO { get; set; } = new UsuarioDTO();
        private UsuarioCRUD UserCRUD { get; set; } = new UsuarioCRUD();


        /*Metodos para AAP:
         
         - Hacer metodo notificaciones: Para avisarle al AAP que se caen las reservas de ciertos cuartos. 
          
         - Ver estado de los cuartos
         - Ver cuartos disponibles
         - Cargar cliente nuevo
         - Ingresar reserva, Cancelar reserva.
         - Cambiar estado de cuarto a: En limpieza o Disponible.         
         */

        
        //CONSULTAS CUARTOS: 
        // ¡¡SOLO FALTA PROBAR!!

        public CuartoDTO AAP_InfoCuarto(int CuartoID)
            //Muestra informacion de un Cuarto. 
        {
            Cuarto = CuartoCRUD.BuscarPorID(CuartoID);

            CuartoDTO = mapper.mapper.Map<Cuarto, CuartoDTO>(Cuarto);

            return CuartoDTO;
            //CuartoDTO.ImprimirDetalle();
        }

        public CuartoDTO AAP_EstadoCuarto(int CuartoID)
            //Muestra el estado de un cuarto. 
        {
            Cuarto = CuartoCRUD.BuscarPorID(CuartoID);
            
            CuartoDTO = mapper.mapper.Map<Cuarto,CuartoDTO>(Cuarto);

            return CuartoDTO;
            //Console.WriteLine($"El cuarto {CuartoDTO.Cuarto_ID} está: {CuartoDTO.Estado}");
        }

        public async Task AAP_CambiarEstadoCuarto(int ID, int Estado)
            //Cambia el estado del cuarto, los estados son:
            //[ 0. Disponible; 1. En limpieza ]. 
        {
            CuartoDTO.Cuarto_ID = ID;
            CuartoDTO.Cuarto_Estado = Estado;

            Cuarto = mapper.mapper.Map<CuartoDTO, Cuarto>(CuartoDTO);

            await CuartoCRUD.Update(Cuarto);
        }

        public async Task<List<CuartoDTO>> AAP_ListarCuartos()
            //Devuelve una lista de cuartos. 
        {
            CuartoList = await CuartoCRUD.Select();

            CuartoDTOList = ConvertirListaCuartos(CuartoList);

            return CuartoDTOList;
        }

        public async Task<List<CuartoDTO>> AAP_ListarCuartosDisponibles()
            //Devuelve una lista de los cuartos disponibles. 
        {
            CuartoList = await CuartoCRUD.SelectDisponibles();

            CuartoDTOList = ConvertirListaCuartos(CuartoList);

            return CuartoDTOList;
        }

        private List<CuartoDTO> ConvertirListaCuartos(List<Cuarto> cuartoList)
            //Ayuda a convertir una lista de cuartos. [Metodo auxiliar]. 
        {
            foreach (Cuarto cuarto in cuartoList)
            {
                CuartoDTO = mapper.mapper.Map<Cuarto, CuartoDTO>(cuarto);

                CuartoDTOList.Add(CuartoDTO);
            }
            return CuartoDTOList;
        }


        

        //CONSULTAS CLIENTES:
        public async Task AAP_NuevoCliente(ClienteDTO NuevoCliente)
            //Inserta un nuevo cliente. 
        {
            Cliente = mapper.mapper.Map<ClienteDTO,Cliente>(NuevoCliente);

            await ClienteCRUD.Insertar(Cliente);
        }

        public ClienteDTO AAP_InfoCliente(int ClienteID)
            //Muesta la info de un nuevo cliente. 
        {
            Cliente = ClienteCRUD.BuscarPorID(ClienteID);

            ClienteDTO = mapper.mapper.Map<Cliente, ClienteDTO>(Cliente);

            return ClienteDTO;
        }

        public async Task<List<ClienteDTO>> AAP_ListarClientes()
            //Imprime una lista de clientes. 
        {
            ClienteList = await ClienteCRUD.Select();

            ClienteDTOList = ConvertirListaClientes(ClienteList);

            return ClienteDTOList;
        }
        
        private List<ClienteDTO> ConvertirListaClientes(List<Cliente> Clientes)
            //Ayuda a convertir una lista de clientes. [ Metodo auxiliar ]. 
        {
            foreach (Cliente cliente in Clientes)
            {
                ClienteDTO = mapper.mapper.Map<Cliente, ClienteDTO>(cliente);
                ClienteDTOList.Add(ClienteDTO);
            }
            
            return ClienteDTOList;
        }


        //CONSULTAS RESERVAS:
        // ¡Solo falta probar!

        public async Task AAP_NuevaReserva(ReservaDTO NuevaReserva)
            //Inserta una nueva reserva. 
        {
            Reserva = mapper.mapper.Map<ReservaDTO, Reserva>(NuevaReserva);

            await ReservaCRUD.Insertar(Reserva);
        }

        public ReservaDTO AAP_InfoReserva(int ReservaID)
            //Muesta info detallada de una reserva. 
        {
            Reserva = ReservaCRUD.BuscarPorID(ReservaID);

            ReservaDTO = mapper.mapper.Map<Reserva, ReservaDTO>(Reserva);

            return ReservaDTO;
        }

        public async Task<List<ReservaDTO>> AAP_ListarReservasActivas()
            //Devuelve una lista de las reservas activas. 
        {
            ReservaList = await ReservaCRUD.Select();

            foreach (Reserva reserva in ReservaList)
            {
                ReservaDTO = mapper.mapper.Map<Reserva, ReservaDTO>(reserva);
                
                ReservaDTOList.Add(ReservaDTO);
            }
            
            return ReservaDTOList;
        }

        public async Task AAP_CambiarEstadoReserva(int ReservaID, int Estado)
        //Cancela la reserva seleccionada.
        //[ 0. Activa; 1. Cancelada ].
        {
            ReservaDTO.Res_ID = ReservaID;
            ReservaDTO.Res_Estado = Estado;

            Reserva = mapper.mapper.Map<ReservaDTO, Reserva>(ReservaDTO);
            
            await ReservaCRUD.Update(Reserva);
        }

        

        /*Metodos para el administrador: 
         
        - Agregar nuevo cuarto
        - Cambiar estado de cuarto a: en limpieza, en renovacion, en limpieza o disponible 
        - Cargar nuevo empleado
        - Crear nuevo usuario         
         */

        public async Task Admin_NuevoCuarto(CuartoDTO NuevoCuarto)
            //Inserta un nuevo Cuarto. 
        {
            Cuarto = mapper.mapper.Map<CuartoDTO, Cuarto>(NuevoCuarto);

            await CuartoCRUD.Insertar(Cuarto);
        }

        public async Task Admin_CambiarEstadoCuarto(int ID, int Estado)
            //Cambia el estado del cuarto, los estados son:
            //[ 0. Disponible; 1. En limpieza; 2. En renovacion ]. 
        {
            await AAP_CambiarEstadoCuarto(ID, Estado);
        }

        public async Task Admin_NuevoEmpleado(EmpleadoDTO NuevoEmpleado)
            //Ingresa un nuevo empleado. 
        {
            Empleado = mapper.mapper.Map<EmpleadoDTO,Empleado>(NuevoEmpleado);

            await EmpleadoCRUD.Insertar(Empleado);
        }

        public async Task Admin_NuevoUser(UsuarioDTO NuevoUser)
            //Ingresa un nuevo usuario. 
        {
            User = mapper.mapper.Map<UsuarioDTO, Usuario>(NuevoUser);

            await UserCRUD.Insertar(User);
        }
    
        public void Admin_CambiarContraseña()
        {

        }


        /// <summary>
        /// Permite el inicio de sesion para el posterior uso de la aplicacion
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        /// <returns>EmpleadoDTO</returns>
        public EmpleadoDTO LogIn(string mail, string password) //Listo.
        {
            User.User_Mail = mail;
            User.User_Password = password;

            User = UserCRUD.SelectUsuario(User);

            if (User != null)
            {
                Empleado.Emp_ID = User.User_ID;

                Empleado = EmpleadoCRUD.SelectEmpleado(Empleado);

                EmpleadoDTO = mapper.mapper.Map<Empleado, EmpleadoDTO>(Empleado);
            }
            else
            {
                EmpleadoDTO = null;
            }

            return EmpleadoDTO;
        }
    }
}
