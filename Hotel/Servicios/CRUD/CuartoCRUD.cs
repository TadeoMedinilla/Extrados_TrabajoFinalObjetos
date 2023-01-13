﻿using Hotel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios.CRUDs
{
    internal class CuartoCRUD : SQL_Methods<Cuarto>, IGenericCRUD<Cuarto>
    {
        private Cuarto cuarto { get; set; }
        private List<Cuarto> cuartoList { get; set; }

        //Querys:

        private string InsertCuartoQuery = "INSERT INTO Hotel.dbo.Cuarto ( Cuarto_ID, Cuarto_Categoria, Cuarto_Estado) VALUES (@Cuarto_ID, @Cuarto_Categoria, @Cuarto_Estado);";
        private string InsertCuartoDetalleQuery = "INSERT INTO Hotel.dbo.CuartoDetalle \r\n\t\t\t( CuartoD_ID, CuartoD_PrecioNoche,\r\n\t\t\tCuartoD_CamasCantidad, CuartoD_Cochera,\r\n\t\t\tCuartoD_TV, CuartoD_Desayuno, \r\n\t\t\tCuartoD_ServicioCuarto, CuartoD_Hidromasaje) \r\nVALUES (@Cuarto_ID, @CuartoD_PrecioNoche, \r\n\t\t@CuartoD_CamasCantidad, @CuartoD_Cochera,\r\n\t\t@CuartoD_TV, @CuartoD_Desayuno,\r\n\t\t@CuartoD_ServicioCuarto, @CuartoD_Hidromasaje);";

        private string SelectQuery = "SELECT  Cuarto_ID, \r\n\t\tCat_Descripcion AS Categoria,\r\n\t\tEstado_Descripcion AS Estado,\r\n\t\tCuartoD_CamasCantidad,\r\n\t\tCuartoD_PrecioNoche\r\nFROM Hotel.dbo.Cuarto\r\nJOIN Hotel.dbo.Categoria ON Cuarto.Cuarto_Categoria = Categoria.Cat_ID\r\nJOIN Hotel.dbo.Estado ON Cuarto.Cuarto_Estado = Estado.Estado_ID\r\nJOIN Hotel.dbo.CuartoDetalle ON Cuarto.Cuarto_ID = CuartoDetalle.CuartoD_ID";
        private string SelectDisponiblesQuery = "SELECT  Cuarto_ID, \r\n\t\tCat_Descripcion AS Categoria,\r\n\t\tEstado_Descripcion AS Estado,\r\n\t\tCuartoD_CamasCantidad,\r\n\t\tCuartoD_PrecioNoche\r\nFROM Hotel.dbo.Cuarto\r\nJOIN Hotel.dbo.Categoria ON Cuarto.Cuarto_Categoria = Categoria.Cat_ID\r\nJOIN Hotel.dbo.Estado ON Cuarto.Cuarto_Estado = Estado.Estado_ID\r\nJOIN Hotel.dbo.CuartoDetalle ON Cuarto.Cuarto_ID = CuartoDetalle.CuartoD_ID WHERE Cuarto_Estado = 0;";
        //Buscar la forma de hacerlo dinamico y generico.
        private string SelectFirstOrDefault = "SELECT  Cuarto_ID, \r\n\t\tCat_Descripcion AS Categoria,\r\n\t\tCuartoD_CamasCantidad,\r\n\t\tCuartoD_PrecioNoche,\r\n\t\tEstado_Descripcion AS Estado,\t\t\r\n\t\tServSit_Descripcion AS Cochera,\r\n\t\tServSit_Descripcion AS TV,\r\n\t\tServSit_Descripcion AS Desayuno,\r\n\t\tServSit_Descripcion AS Servicio,\r\n\t\tServSit_Descripcion AS Hidromasaje\r\nFROM Hotel.dbo.Cuarto\r\nJOIN hotel.dbo.Categoria ON Cuarto.Cuarto_Categoria = Categoria.Cat_ID\r\nJOIN Hotel.dbo.Estado ON Cuarto.Cuarto_Estado = Estado.Estado_ID\r\nJOIN Hotel.dbo.CuartoDetalle ON Cuarto.Cuarto_ID = CuartoDetalle.CuartoD_ID \r\nJOIN Hotel.dbo.ServicioSituacion ON CuartoDetalle.CuartoD_Cochera = ServSit_ID \r\nAND CuartoDetalle.CuartoD_TV = ServicioSituacion.ServSit_ID\r\nAND CuartoDetalle.CuartoD_Desayuno = ServicioSituacion.ServSit_ID\r\nAND CuartoDetalle.CuartoD_ServicioCuarto = ServicioSituacion.ServSit_ID\r\nAND CuartoDetalle.CuartoD_Hidromasaje = ServicioSituacion.ServSit_ID\r\nWHERE Cuarto.Cuarto_ID = @Cuarto_ID;";


        private string UpdateQuery = "UPDATE Hotel.dbo.Cuarto SET Cuarto_Estado = @Cuarto_Estado WHERE Cuarto_ID = @Cuarto_ID;";
        

        public CuartoCRUD() { }

        //CRUD:
        public async Task Insertar(Cuarto aInsertar)
            //Inserta un nuevo cuarto en las tablas Cuarto y CuartoDetalle. 
        {
            string sentenciaCuarto = InsertCuartoQuery;

            await SQL_Executable(sentenciaCuarto, aInsertar);

            string sentenciaCuartoDetalle = InsertCuartoDetalleQuery;

            await SQL_Executable(sentenciaCuartoDetalle, aInsertar);
        }

        public async Task<List<Cuarto>> Select()
            //Devuelve una lista de cuartos con la sig info detallada:
            //[ Categoria, Estado, Cantidad de camas, Precio por noche ]. 
        {
            string sentencia = SelectQuery;

            cuartoList = await SQL_Query(sentencia);

            return cuartoList;
        }

        public async Task<List<Cuarto>> SelectDisponibles()
            //Buscar la forma de poder pasar por parametro un objeto para que pueda buscar los diferentes 
            //estados sin necesidad de crear diferentes metodos. 
        {
            string sentencia = SelectDisponiblesQuery;

            cuartoList = await SQL_Query(sentencia);

            return cuartoList;
        }

        public Cuarto BuscarPorID(int ID)
            //Devuelve informacion detallada de un cuarto solicitado. 
        {
            Cuarto aux_cuarto = new Cuarto();
            aux_cuarto.Cuarto_ID = ID;

            string sentencia = SelectFirstOrDefault;

            cuarto = SQL_QueryFirstOrDefault(sentencia, aux_cuarto);

            return cuarto;
        }

        public async Task Update(int ID)
            //No se utiliza. 
        {
            cuarto = BuscarPorID(ID);
            await SQL_Executable(UpdateQuery, cuarto);
        }

        public async Task UpdateEstado(int ID, int Estado)
        {
            cuarto.Cuarto_ID = ID;
            cuarto.Cuarto_Estado = Estado;
            await SQL_Executable(UpdateQuery, cuarto);
        }

        public async Task UpdateTo_EnLimpieza(int ID)
            //Actualiza el estado de un cuarto a 'En limpieza'. 
        {
            cuarto = BuscarPorID(ID);
            await SQL_Executable(EnLimpiezaQuery, cuarto);
        }

        public async Task UpdateTo_Disponible(int ID)
            //Actualiza el estado de un cuarto a 'Disponible'. 
        {
            cuarto = BuscarPorID(ID);
            await SQL_Executable(DisponibleQuery, cuarto);
        }

        public async Task UpdateTo_EnRenovacion(int ID)
            //Actualiza el estado de un cuarto a 'En renovacion'. 
        {
            cuarto = BuscarPorID(ID);
            await SQL_Executable(EnRenovacionQuery, cuarto);
        }
    }
}
