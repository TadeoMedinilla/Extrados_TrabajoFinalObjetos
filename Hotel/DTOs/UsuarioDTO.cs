using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal class UsuarioDTO
    {
        public int? User_ID { get; set; }
        public string User_Mail { get; set; }
        public string User_Password { get; set; }

        public void SolicitarDatos()
        {
            Console.Write("Ingrese su mail de empleado:\t");
            this.User_Mail = Console.ReadLine();

            Console.Write("Ingrese su contraseña:\t");
            this.User_Password = Console.ReadLine();
        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"Usuario:{this.User_Mail} ");
        }
    }
}
