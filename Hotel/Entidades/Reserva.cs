using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entidades
{
    internal class Reserva
    {
        public int Res_ID { get; set; }
        public int Res_CliID { get; set; }
        public int Res_CuartoID { get; set; }
        public DateOnly Res_CheckIn { get; set; }
        public DateOnly Res_CheckOut { get; set; }
        public int Res_Estado { get; set; }

    }
}
