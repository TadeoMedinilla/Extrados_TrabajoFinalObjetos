// See https://aka.ms/new-console-template for more information
using AutoMapper;
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

        //await consulta.AAP_NuevoCliente();

        //consulta.AAP_InfoCliente(1);

        //await consulta.AAP_ListarClientes();

        //consulta.AAP_EstadoCuarto(1);

        await consulta.AAP_ListarCuartos();

        consulta.AAP_InfoCuarto(1);

        Console.WriteLine("Listo");
        Console.ReadLine();

    }
}