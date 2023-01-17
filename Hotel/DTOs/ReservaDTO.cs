using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal class ReservaDTO : IDataTransferObject
    {
        /*
          ¡ERROR!

        LOS DTOs SOLO TRANSPORTAN DATOS, NO DEBEN SOLICITARLOS NI IMPRIMIRLOS
        CREAR CLASES APARTE EN SERVICIOS PARA REALIZAR LA IMPRESION Y SOLICITUD DE DATOS.

        */

        public int Res_ID { get; set; }
        
        public int Res_CliID { get; set; }
        public string Cliente { get; set; }
        
        public int Res_CuartoID { get; set; }
       
        public string Res_CheckIn { get; set; }
        public string Res_CheckOut { get; set; }
        
        public int Res_Estado { get; set; }
        public string Estado { get; set; }
        
       
        
        public void SolicitarDatos()
        {
            Console.Write("Ingrese el ID del cliente:\t");
            Res_CliID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el numero de la habitacion a reservar:\t");
            Res_CuartoID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese la fecha en el siguiente formato [ 'YYYY-MM-DD' ]:");
            Res_CheckIn = Console.ReadLine();
            //string fecha_In = Console.ReadLine();
            //Res_CheckIn = SetFecha(fecha_In);

            Console.Write("Ingrese la fecha de Check In en el siguiente formato [ 'YYYY-MM-DD' ]:\t");
            Res_CheckOut = Console.ReadLine();
            //string fecha_Out = Console.ReadLine();
            //Res_CheckOut = SetFecha(fecha_Out);

        }

        public void ImprimirDetalle()
        {
            Console.WriteLine($"Datos de la reserva:{this.Res_ID}\t\t Estado: {this.Estado}\n" +
                              $"Numero de cuarto: {this.Res_CuartoID}\t\t Cliente: {this.Cliente}\t\t Cliente ID: {this.Res_CliID}\n" +
                              $"Check In: {this.Res_CheckIn}\t\t Check Out: {this.Res_CheckOut}\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"> Formato [ YYYY-MM-DD ] </param>
        /// <returns> Objeto DateOnly. </returns>
        private DateOnly SetFecha(string fecha) 
        {
            int year = Convert.ToInt32(fecha.Substring(0, 4));
            int month = Convert.ToInt16(fecha.Substring(5, 2));
            int day = Convert.ToInt16(fecha.Substring(8, 2));

            DateOnly aux_date = new DateOnly(year, month, day);

            return aux_date;
        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"Reserva nro:{this.Res_ID}\t\t Estado: {this.Estado}\t\t Numero de cuarto: {this.Res_CuartoID}" +
                              $"Check In: {this.Res_CheckIn}\t\t Check Out: {this.Res_CheckOut}\n");
        }
    }
}
