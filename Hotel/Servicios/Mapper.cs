using AutoMapper;
using Hotel.DTOs;
using Hotel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios
{
    internal class Mapper 
    {
        public IMapper mapper { get; set; }

        public Mapper() 
        {
            mapper = SetMapperConfiguration();
        }

        private IMapper SetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(configuration =>
            {
                //Aqui creo los mapeos que necesite.

                configuration.CreateMap<ClienteDTO, Cliente>();
                configuration.CreateMap<Cliente, ClienteDTO>();
                
                configuration.CreateMap<CuartoDTO, Cuarto>();
                configuration.CreateMap<Cuarto,CuartoDTO>();
                
                configuration.CreateMap<Empleado, EmpleadoDTO>();
                configuration.CreateMap<EmpleadoDTO, Empleado>();

                configuration.CreateMap<ReservaDTO, Reserva>();
                configuration.CreateMap<Reserva, ReservaDTO>();

                configuration.CreateMap<UsuarioDTO, Usuario>();
                configuration.CreateMap<Usuario, UsuarioDTO>();

            });
            return configuration.CreateMapper();
        }
    }
}
