using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal class EmpleadoDTO
    {
        public int? EmpDTO_ID { get; set; }
        public string EmpDTO_Nombre { get; set; }
        public int? EmpDTO_Edad { get; set; }
        public int EmpDTO_Puesto { get; set; }
        public string? EmpDTO_Mail { get; set; }

        public void SolicitarDatos()
        {
            Console.Write("Ingrese el nombre:\t");
            this.EmpDTO_Nombre = Console.ReadLine();

            Console.Write("Ingrese la edad:\t");
            this.EmpDTO_Edad = Convert.ToInt16(Console.ReadLine());
           
            Console.Write("0. Atencion al publico\n 1. Administrador\n Seleccione el puesto:\t");
            this.EmpDTO_Puesto = Convert.ToInt16(Console.ReadLine());

            Console.Write("Ingrese el mail de empleado:\t");
            this.EmpDTO_Mail = Console.ReadLine();
        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"ID Empleado: {this.EmpDTO_ID}\n" +
                              $"Nombre: {this.EmpDTO_Nombre}\n" +
                              $"Edad: {this.EmpDTO_Edad}\n" +
                              $"Puesto: {this.EmpDTO_Mail}\n" +
                              $"Mail: {this.EmpDTO_Mail}\n");
        }
    }
}
