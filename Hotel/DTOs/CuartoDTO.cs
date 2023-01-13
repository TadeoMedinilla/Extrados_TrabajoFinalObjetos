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
        public int Cuarto_ID { get; set; }
        
        public int Cuarto_Categoria { get; set; }
        public string Categoria { get; set; } //0. Cuarto normal 1. Cuarto VIP
        
        public int? Cuarto_Estado { get; set; }
        public string Estado { get; set; } // 0. Disponible 1. En limpieza 2. En renovacion

        public int? CuartoD_PrecioNoche { get; set; } // 
        public int? CuartoD_CamasCantidad { get; set; } //
        
        //SERVICIOS: 

        public int? CuartoD_Cochera { get; set; }
        public string Cochera { get; set; } // 0. Incluido 1. No incluido 

        public int? CuartoD_TV { get; set; } // 0. Incluido 1. No incluido
        public string TV { get; set; } // 0. Incluido 1. No incluido 

        public int? CuartoD_Desayuno { get; set; } // 0. Incluido 1. No incluido
        public string Desayuno { get; set; } // 0. Incluido 1. No incluido 

        public int? CuartoD_Servicio { get; set; }
        public string Servicio { get; set; } // 0. Incluido 1. No incluido 

        public int? CuartoD_Hidromasaje { get; set; }
        public string Hidromasaje { get; set; } // 0. Incluido 1. No incluido 


        public void SolicitarDatos()
        {
            Console.Write("Ingrese el numero del cuarto:\t");
            this.Cuarto_ID = Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Cuarto normal.\n 1.Cuarto VIP.\n Seleccione el tipo de cuarto:\t");
            this.Cuarto_Categoria = Convert.ToInt16(Console.ReadLine());

            Console.Write("Ingrese el precio por noche de la habitacion:\t");
            this.CuartoD_PrecioNoche = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese la cantidad de camas de la habitacion:\t");
            this.CuartoD_CamasCantidad = Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Si\n 1. No\n¿La habitacion tiene cochera? :\t");
            this.CuartoD_Cochera = Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Si\n 1. No\n¿La habitacion tiene TV? :\t");
            this.CuartoD_TV =  Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Si\n 1. No\n¿La habitacion incluye desayuno? :\t");
            this.CuartoD_Desayuno = Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Si\n 1. No\n¿La habitacion incluye servicio al cuarto? :\t");
            this.CuartoD_Servicio = Convert.ToInt16(Console.ReadLine());

            Console.Write("0. Si\n 1. No\n¿La habitacion incluye hidromasaje? :\t");
            this.CuartoD_Cochera = Convert.ToInt16(Console.ReadLine());
        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"Numero de cuarto: {this.Cuarto_ID}\t\t Categoria: {this.Categoria}\n" +
                              $"Precio por noche: {this.CuartoD_PrecioNoche}\t\t Estado: {this.Estado}\n");
        }

        public void ImprimirDetalle()
        {
            Console.WriteLine($"Numero de cuarto: {this.Cuarto_ID}\t\t Categoria: {this.Categoria}\n" +
                              $"Precio por noche: {this.CuartoD_PrecioNoche}\n" +
                              $"Cantidad de camas: {this.CuartoD_CamasCantidad}\n" +
                              $"Estado: {this.Estado}\n" +
                              $"\nServicios:\n" +
                              $"Cochera: {this.Cochera}\n" +
                              $"TV: {this.TV}\n" +
                              $"Desayuno: {this.Desayuno}\n" +
                              $"Servicio al cuarto: {this.Servicio}\n" +
                              $"Hidromasaje: {this.Hidromasaje}\n");                       
        }
    }
}
