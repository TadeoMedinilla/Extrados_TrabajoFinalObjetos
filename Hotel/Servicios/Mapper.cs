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

        private IMapper SetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(configuration =>
            {
                //Aqui creo los mapeos que necesite.
                configuration.CreateMap<Empleado, EmpleadoDTO>();
                configuration.CreateMap<EmpleadoDTO, Empleado>();

            });
            return configuration.CreateMapper();
        }
    }
}
