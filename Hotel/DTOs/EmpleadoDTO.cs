using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal class EmpleadoDTO
    {
        public int EmpDTO_ID { get; set; }
        public string EmpDTO_Nombre { get; set; }
        public int EmpDTO_Edad { get; set; }
        public string EmpDTO_Puesto { get; set; }
        public string EmpDTO_Mail { get; set; }
    }
}
