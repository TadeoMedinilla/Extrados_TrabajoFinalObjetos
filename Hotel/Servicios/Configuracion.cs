using AutoMapper;
using Hotel.DTOs;
using Hotel.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios
{
    internal class Configuracion
    {
        public string DB_Connection { get; private set; }

        public IMapper mapper { get; set; }


        public Configuracion() 
        {
            this.DB_Connection = "DataBase = .; Initial Catalog = Hotel; Integrated Security = True; TrustServerCertificate=True;";
            this.mapper = SetMapperConfiguration();
        }

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

