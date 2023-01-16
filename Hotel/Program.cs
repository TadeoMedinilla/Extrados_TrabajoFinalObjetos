// See https://aka.ms/new-console-template for more information
using AutoMapper;
using Hotel;
using Hotel.DTOs;
using Hotel.Entidades;
using Hotel.Servicios;
using Hotel.Servicios.CRUDs;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Consultas consulta = new Consultas();

        EmpleadoDTO Personal = new EmpleadoDTO();

        //await consulta.AAP_NuevoCliente();

        //consulta.AAP_InfoCliente(1);

        //await consulta.AAP_ListarClientes();

        //consulta.AAP_EstadoCuarto(1);

        //await consulta.AAP_ListarCuartos();

        //consulta.AAP_InfoCuarto(1);

        //string mail = "Ernesto@mail.com";
        //string pass = "Chau";



        //Personal = consulta.LogIn(mail, pass);

        Aplicacion app = new Aplicacion();
        await app.IniciarAplicacion();


        Console.WriteLine("Listo");
        Console.ReadLine();

    }
}