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
        private List<Cuarto> CuartoList { get; set; } 
        private CuartoDTO CuartoDTO { get; set; } = new CuartoDTO();
        private CuartoCRUD CuartoCRUD { get; set; } = new CuartoCRUD(); 

        private Cliente Cliente { get; set; } = new Cliente();
        private List<Cliente> ClienteList { get; set; }
        private ClienteDTO ClienteDTO { get; set; } = new ClienteDTO();
        private ClienteCRUD ClienteCRUD { get; set; } = new ClienteCRUD();

        private Reserva Reserva { get; set; } = new Reserva();
        private List<Reserva> ReservaList { get; set; } 
        private ReservaDTO ReservaDTO { get; set; } = new ReservaDTO();
        private ReservaCRUD ReservaCRUD { get; set; } = new ReservaCRUD();

        private Empleado Empleado { get; set; } = new Empleado();
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

        public void AAP_InfoCuarto(int CuartoID)
            //Muestra informacion de un Cuarto. 
        {
            Cuarto = CuartoCRUD.BuscarPorID(CuartoID);

            CuartoDTO = mapper.mapper.Map<Cuarto, CuartoDTO>(Cuarto);

            CuartoDTO.ImprimirDetalle();
        }

        public void AAP_EstadoCuarto(int CuartoID)
            //Muestra el estado de un cuarto. 
        {
            Cuarto = CuartoCRUD.BuscarPorID(CuartoID);
            
            CuartoDTO = mapper.mapper.Map<Cuarto,CuartoDTO>(Cuarto);

            Console.WriteLine($"El cuarto {CuartoDTO.Cuarto_ID} está: {CuartoDTO.Estado}");
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

        public async Task AAP_ListarCuartos()
            //Imprime una lista de cuartos. 
        {
            CuartoList = await CuartoCRUD.Select();

            ImprimirCuartos(CuartoList);

            /*foreach (Cuarto cuarto in CuartoList)
            {
                CuartoDTO = mapper.mapper.Map<Cuarto, CuartoDTO>(cuarto);

                CuartoDTO.ImprimirDatos();
            }*/
        }

        public async Task AAP_ListarCuartosDisponibles()
            //Imprime una lista de los cuartos disponibles. 
        {
            CuartoList = await CuartoCRUD.SelectDisponibles();

            ImprimirCuartos(CuartoList);
        }

        private void ImprimirCuartos(List<Cuarto> cuartoList)
            //Ayuda a imprimir una lista de cuartos. [Metodo auxiliar] 
        {
            foreach (Cuarto cuarto in cuartoList)
            {
                CuartoDTO = mapper.mapper.Map<Cuarto, CuartoDTO>(cuarto);

                CuartoDTO.ImprimirDatos();
            }
        }


        

        //CONSULTAS CLIENTES:
        public async Task AAP_NuevoCliente()
            //Inserta un nuevo cliente. 
        {
            ClienteDTO.SolicitarDatos();

            Cliente = mapper.mapper.Map<ClienteDTO,Cliente>(ClienteDTO);

            await ClienteCRUD.Insertar(Cliente);
        }

        public void AAP_InfoCliente(int ClienteID)
            //Muesta la info de un nuevo cliente. 
        {
            Cliente = ClienteCRUD.BuscarPorID(ClienteID);

            ClienteDTO = mapper.mapper.Map<Cliente, ClienteDTO>(Cliente);

            ClienteDTO.ImprimirDatos();
        }

        public async Task AAP_ListarClientes()
            //Imprime una lista de clientes. 
        {
            ClienteList = await ClienteCRUD.Select();

            foreach (Cliente cliente in ClienteList)
            {
                ClienteDTO = mapper.mapper.Map<Cliente,ClienteDTO>(cliente);

                ClienteDTO.ImprimirDatos();
            }
        }


        //CONSULTAS RESERVAS:
        // ¡Solo falta probar!

        public async Task AAP_NuevaReserva()
            //Inserta una nueva reserva. 
        {
            ReservaDTO.SolicitarDatos();

            Reserva = mapper.mapper.Map<ReservaDTO, Reserva>(ReservaDTO);

            await ReservaCRUD.Insertar(Reserva);
        }

        public void AAP_InfoReserva(int ReservaID)
            //Muesta info detallada de una reserva. 
        {
            Reserva = ReservaCRUD.BuscarPorID(ReservaID);

            ReservaDTO = mapper.mapper.Map<Reserva, ReservaDTO>(Reserva);

            ReservaDTO.ImprimirDatos();
        }

        public async void AAP_ImprimirReservasActivas()
            //Imprime las reservas activas. 
        {
            ReservaList = await ReservaCRUD.Select();

            foreach (Reserva reserva in ReservaList)
            {
                ReservaDTO = mapper.mapper.Map<Reserva, ReservaDTO>(reserva);
                
                ReservaDTO.ImprimirDatos();
            }
        }

        public async Task AAP_CambiarEstadoReserva(int ReservaID, int Estado)
            //Cancela la reserva seleccionada. 
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

        public async Task Admin_NuevoCuarto()
            //Inserta un nuevo Cuarto. 
        {
            CuartoDTO.SolicitarDatos();
            
            Cuarto = mapper.mapper.Map<CuartoDTO, Cuarto>(CuartoDTO);

            await CuartoCRUD.Insertar(Cuarto);
        }

        public async Task Admin_CambiarEstadoCuarto(int ID, int Estado)
            //Cambia el estado del cuarto, los estados son:
            //[ 0. Disponible; 1. En limpieza; 2. En renovacion ]. 
        {
            await AAP_CambiarEstadoCuarto(ID, Estado);
        }

        public async Task Admin_NuevoEmpleado()
            //Ingresa un nuevo empleado. 
        {
            EmpleadoDTO.SolicitarDatos();

            Empleado = mapper.mapper.Map<EmpleadoDTO,Empleado>(EmpleadoDTO);

            await EmpleadoCRUD.Insertar(Empleado);
        }

        public async Task Admin_NuevoUser()
            //Ingresa un nuevo usuario. 
        {
            UserDTO.SolicitarDatos();

            User = mapper.mapper.Map<UsuarioDTO, Usuario>(UserDTO);

            await UserCRUD.Insertar(User);
        }
    }
}
