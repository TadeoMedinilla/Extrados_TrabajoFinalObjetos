using Hotel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal class ClienteDTO
    {
        public int Cli_ID { get; set; }
        public string Cli_Nombre { get; set; }
        public string Cli_Mail { get; set; }

        public void SolicitarDatos()
        {
            Console.Write("Ingrese el nombre del cliente:\t");
            this.Cli_Nombre = Console.ReadLine();

            Console.Write("Ingrese el mail del cliente:\t");
            this.Cli_Mail = Console.ReadLine();

        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"Nombre: {this.Cli_Nombre}\nID Cliente: {this.Cli_ID}\n" +
                              $"Mail: {this.Cli_Mail}\n");
        }

        
    }
}
