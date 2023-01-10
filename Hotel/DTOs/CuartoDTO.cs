using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal class CuartoDTO
    {
        public int CuartoDTO_ID { get; set; }
        
        public int CuartoDTO_Categoria { get; set; }
        public string Categoria
        {
            get
            {
                switch (this.CuartoDTO_Estado)
                {
                    case 0:
                        this.Categoria = "Cuarto NORMAL.";
                        break;
                    case 1:
                        this.Categoria = "Cuarto VIP.";
                        break;
                }
                return this.Categoria;
            }
            set { }
        } //0. Cuarto normal 1. Cuarto VIP
        
        public int? CuartoDTO_Estado { get; set; }
        public string Estado
        {
            get
            {
                switch (this.CuartoDTO_Estado)
                {
                    case 0:
                        this.Estado = "DISPONIBLE.";
                        break;
                    case 1:
                        this.Estado = "EN LIMPIEZA.";
                        break;
                    case 2:
                        this.Estado = "EN RENOVACION.";
                        break;
                }
                return this.Estado; 
            }
            set { }
        } // 0. Disponible 1. En limpieza 2. En renovacion
        
        public int? CuartoDTO_Precio { get; set; } // 
        public int? CuartoDTO_CamasCantidad { get; set; } //
        
        //SERVICIOS: 

        public int? CuartoDTO_Cochera { get; set; }
        public string Cochera 
        { 
            get
            {
                switch (this.CuartoDTO_Cochera)
                {
                    case 0:
                        this.Cochera = "INCLUIDO";
                        break;
                    case 1:
                        this.Cochera = "NO INCLUIDO";
                        break;
                }
                return this.Cochera;
            }
            set { }
        } // 0. Incluido 1. No incluido 

        public int? CuartoDTO_TV { get; set; } // 0. Incluido 1. No incluido
        public string TV 
        {
            get
            {
                switch (this.CuartoDTO_TV)
                {
                    case 0:
                        this.Cochera = "INCLUIDO";
                        break;
                    case 1:
                        this.Cochera = "NO INCLUIDO";
                        break;
                }
                return this.TV;
            }
            set { }
        } // 0. Incluido 1. No incluido 

        public int? CuartoDTO_Desayuno { get; set; } // 0. Incluido 1. No incluido
        public string Desayuno 
        {
            get
            {
                switch (this.CuartoDTO_Desayuno)
                {
                    case 0:
                        this.Cochera = "INCLUIDO";
                        break;
                    case 1:
                        this.Cochera = "NO INCLUIDO";
                        break;
                }
                return this.Desayuno;
            }
            set { }
        } // 0. Incluido 1. No incluido 

        public int? CuartoDTO_Servicio { get; set; }
        public string Servicio 
        {
            get
            {
                switch (this.CuartoDTO_Servicio)
                {
                    case 0:
                        this.Cochera = "INCLUIDO";
                        break;
                    case 1:
                        this.Cochera = "NO INCLUIDO";
                        break;
                }
                return this.Servicio;
            }
            set { }
        } // 0. Incluido 1. No incluido 

        public int? CuartoDTO_Hidromasaje { get; set; }
        public string Hidromasaje 
        {
            get
            {
                switch (this.CuartoDTO_Hidromasaje)
                {
                    case 0:
                        this.Cochera = "INCLUIDO";
                        break;
                    case 1:
                        this.Cochera = "NO INCLUIDO";
                        break;
                }
                return this.Hidromasaje;
            }
            set { }
        } // 0. Incluido 1. No incluido 


        public void SolicitarDatos()
        {
            Console.Write("Ingrese el numero del cuarto:\t");
            this.CuartoDTO_ID = Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Cuarto normal.\n 1.Cuarto VIP.\n Seleccione el tipo de cuarto:\t");
            this.CuartoDTO_Categoria = Convert.ToInt16(Console.ReadLine());

            Console.Write("Ingrese el precio por noche de la habitacion:\t");
            this.CuartoDTO_Precio = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese la cantidad de camas de la habitacion:\t");
            this.CuartoDTO_CamasCantidad = Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Si\n 1. No\n¿La habitacion tiene cochera? :\t");
            this.CuartoDTO_Cochera = Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Si\n 1. No\n¿La habitacion tiene TV? :\t");
            this.CuartoDTO_TV =  Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Si\n 1. No\n¿La habitacion incluye desayuno? :\t");
            this.CuartoDTO_Desayuno = Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Si\n 1. No\n¿La habitacion incluye servicio al cuarto? :\t");
            this.CuartoDTO_Servicio = Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Si\n 1. No\n¿La habitacion incluye hidromasaje? :\t");
            this.CuartoDTO_Cochera = Convert.ToInt16(Console.ReadLine());
        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"Numero de cuarto: {this.CuartoDTO_ID}\t\t Categoria: {this.Categoria}\n" +
                              $"Precio por noche: {this.CuartoDTO_Precio}\n" +
                              $"Cantidad de camas: {this.CuartoDTO_CamasCantidad}\n" +
                              $"Estado: {this.Estado}\n" +
                              $"Servicios:\n" +
                              $"Cochera: {this.Cochera}\n" +
                              $"TV: {this.TV}\n" +
                              $"Desayuno: {this.Desayuno}\n" +
                              $"Servicio al cuarto: {this.Servicio}\n" +
                              $"Hidromasaje: {this.Hidromasaje}\n");                       
        }
    }
}
