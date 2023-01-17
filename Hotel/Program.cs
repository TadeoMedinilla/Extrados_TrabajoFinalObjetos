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
        Aplicacion App = new Aplicacion();
        await App.IniciarAplicacion();


        
        /* PRUEBAS: 

        //PRUEBA METODOS AAP:

        Consultas consulta = new Consultas();

        //CONSULTAS SOBRE CUARTOS:

        int CuartoID=1;

        //consulta.AAP_InfoCuarto(CuartoID);  //Funciona.

        //consulta.AAP_EstadoCuarto(CuartoID); //Funciona.

        //await consulta.AAP_ListarCuartos();  //Funciona.

        //await consulta.AAP_ListarCuartosDisponibles(); //Funciona. 

        
        
        //CONSULTAS SOBRE CLIENTES:

        ClienteDTO cli = new ClienteDTO();
        
        //cli.SolicitarDatos();

        int cliID = 1;

        //await consulta.AAP_NuevoCliente(cli); //Funciona.

        //consulta.AAP_InfoCliente(cliID); //Funciona.

        //await consulta.AAP_ListarClientes(); //Funciona.


        //CONSULTAS SOBRE RESERVAS:

        ReservaDTO Res = new ReservaDTO();

        //Res.SolicitarDatos();

        int ResID = 1;

        //await consulta.AAP_NuevaReserva(Res); //Funciona.

        //consulta.AAP_InfoReserva(ResID); //Funciona.

        //await consulta.AAP_ListarReservasActivas(); //Funciona.

       
        
        //PRUEBAS METODOS ADMIN:

        CuartoDTO NuevoCuarto = new CuartoDTO();
        //NuevoCuarto.SolicitarDatos();

        //await consulta.Admin_NuevoCuarto(NuevoCuarto); //Funciona

        //int Cuarto = 4;
        //int Estado = 2;

        //await consulta.Admin_CambiarEstadoCuarto(Cuarto, Estado); //Funciona

        //EmpleadoDTO empleado = new EmpleadoDTO();
        //empleado.SolicitarDatos();

        //await consulta.Admin_NuevoEmpleado(empleado); //Funciona.
        */

        /*          ¡¡CORREGIR!!
        UsuarioDTO User = new UsuarioDTO();
        User.SolicitarDatos();

        await consulta.Admin_NuevoUser(User);
        */

        Console.WriteLine("Listo");
        Console.ReadLine();

    }
}