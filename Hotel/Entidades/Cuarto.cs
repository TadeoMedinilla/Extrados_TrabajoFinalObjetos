using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entidades
{
    internal class Cuarto
    {
        public int Cuarto_ID { get; set; }
        
        public int Cuarto_Categoria { get; set; }
        public string Categoria { get; set; }
        
        public int Cuarto_Estado { get; set; }
        public string Estado { get; set; }
        
        public int CuartoD_PrecioNoche { get; set; }
        public int CuartoD_CamasCantidad { get; set; }

        public int CuartoD_Cochera { get; set; }
        public string Cochera { get; set; }

        public int CuartoD_TV { get; set; }
        public string TV { get; set; }

        public int CuartoD_Desayuno { get; set; }
        public string Desayuno { get; set; }

        public int CuartoD_Servicio { get; set; }
        public string Servicio { get; set; }

        public int CuartoD_Hidromasaje { get; set; }
        public string Hidromasaje { get; set; }


    }
}
