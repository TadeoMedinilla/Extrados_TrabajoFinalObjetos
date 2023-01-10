using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal class UsuarioDTO
    {
        public int? UserDTO_ID { get; set; }
        public string UserDTO_Mail { get; set; }
        public string UserDTO_Password { get; set; }

        public void SolicitarDatos()
        {
            Console.Write("Ingrese su mail de empleado:\t");
            this.UserDTO_Mail = Console.ReadLine();

            Console.Write("Ingrese su contraseña:\t");
            this.UserDTO_Password = Console.ReadLine();
        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"Usuario:{this.UserDTO_Mail} ");
        }
    }
}
