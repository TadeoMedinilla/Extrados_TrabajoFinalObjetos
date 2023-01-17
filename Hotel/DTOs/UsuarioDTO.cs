using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal class UsuarioDTO : IDataTransferObject
    {
        /*
          ¡ERROR!

        LOS DTOs SOLO TRANSPORTAN DATOS, NO DEBEN SOLICITARLOS NI IMPRIMIRLOS
        CREAR CLASES APARTE EN SERVICIOS PARA REALIZAR LA IMPRESION Y SOLICITUD DE DATOS.

        */
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

        public void ImprimirDetalle()
        {
            throw new NotImplementedException();
        }
    }
}
