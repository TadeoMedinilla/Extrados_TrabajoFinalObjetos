using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DTOs
{
    internal interface IDataTransferObject
    {
        /// <summary>
        /// Este metodo solicita la informacion necesaria para completar un objeto.
        /// </summary>
        public void SolicitarDatos();

        /// <summary>
        /// Este metodo imprime informacion acotada de un objeto.
        /// Para utilizar en la impresion de listas.
        /// </summary>
        public void ImprimirDatos();

        /// <summary>
        /// Este metodo imprime informacion detallada de un objeto.
        /// </summary>
        public void ImprimirDetalle();

    }
}
