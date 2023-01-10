using Hotel.DTOs;
using Hotel.Entidades;
using Hotel.Servicios.CRUDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios
{
    internal class Consultas
    {
        private Mapper mapper { get; }

        private Cuarto Cuarto { get; set; }
        private CuartoDTO CuartoDTO { get; set; }
        private CuartoCRUD CuartoCRUD { get; set; }

        private Cliente Cliente { get; set; }
        private ClienteDTO ClienteDTO { get; set; }
        private ClienteCRUD ClienteCRUD { get; set; }

        private Reserva Reserva { get; set; }
        private ReservaDTO ReservaDTO { get; set; }
        private ReservaCRUD ReservaCRUD { get; set; }



        /*Metodos para AAP:
         
         - Hacer metodo notificaciones: Para avisarle al AAP que se caen las reservas de ciertos cuartos. 
          
         - Ver estado de los cuartos
         - Ver cuartos disponibles
         - Cargar cliente nuevo
         - Ingresar reserva, Cancelar reserva.
         - Cambiar estado de cuarto a: En limpieza o Disponible.         
         */

        public void AAP_InfoCuarto(int CuartoID)
            //Muestra informacion de un Cuarto. 
        {
            Cuarto = CuartoCRUD.BuscarPorID(CuartoID);

            CuartoDTO = mapper.mapper.Map<Cuarto, CuartoDTO>(Cuarto);

            CuartoDTO.ImprimirDatos();
        }

        public void AAP_EstadoCuarto(int CuartoID)
            //Muestra el estado de un cuarto. 
        {
            Cuarto = CuartoCRUD.BuscarPorID(CuartoID);
            
            CuartoDTO = mapper.mapper.Map<Cuarto,CuartoDTO>(Cuarto);

            Console.WriteLine($"El cuarto {CuartoDTO.CuartoDTO_ID} está: {CuartoDTO.Estado}");
        }

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

        public async Task AAP_NuevaReserva()
            //Inserta una nueva reserva. 
        {
            ReservaDTO.SolicitarDatos();

            Reserva = mapper.mapper.Map<ReservaDTO, Reserva>(ReservaDTO);

            await ReservaCRUD.Insertar(Reserva);
        }


        /*Metodos para el administrador: 
         
        - Agregar nuevo cuarto
        - Cambiar estado de cuarto a: en limpieza, en renovacion, en limpieza o disponible 
        - Cargar nuevo empleado
        - Crear nuevo usuario         
         */
    }
}
