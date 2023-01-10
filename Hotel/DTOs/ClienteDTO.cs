using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal class ClienteDTO
    {
        public int CliDTO_ID { get; }
        public string CliDTO_Nombre { get; set; }
        public string CliDTO_Mail { get; set; }

        public void SolicitarDatos()
        {
            Console.Write("Ingrese el nombre del cliente:\t");
            this.CliDTO_Nombre = Console.ReadLine();

            Console.Write("Ingrese el mail del cliente:\t");
            this.CliDTO_Mail = Console.ReadLine();

        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"Nombre: {this.CliDTO_Nombre}\t\t ID Cliente: {this.CliDTO_ID}\n" +
                              $"Mail: {this.CliDTO_Mail}\n");
        }
    }
}
