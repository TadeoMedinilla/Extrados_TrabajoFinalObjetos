﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal class EmpleadoDTO
    {
        public int? Emp_ID { get; set; }
        public string Emp_Nombre { get; set; }
        public int? Emp_Edad { get; set; }
        public int Emp_Puesto { get; set; }
        public string? Emp_Mail { get; set; }

        public void SolicitarDatos()
        {
            Console.Write("Ingrese el nombre:\t");
            this.Emp_Nombre = Console.ReadLine();

            Console.Write("Ingrese la edad:\t");
            this.Emp_Edad = Convert.ToInt16(Console.ReadLine());
           
            Console.Write("0. Atencion al publico\n 1. Administrador\n Seleccione el puesto:\t");
            this.Emp_Puesto = Convert.ToInt16(Console.ReadLine());

            Console.Write("Ingrese el mail de empleado:\t");
            this.Emp_Mail = Console.ReadLine();
        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"ID Empleado: {this.Emp_ID}\n" +
                              $"Nombre: {this.Emp_Nombre}\n" +
                              $"Edad: {this.Emp_Edad}\n" +
                              $"Puesto: {this.Emp_Mail}\n" +
                              $"Mail: {this.Emp_Mail}\n");
        }
    }
}
