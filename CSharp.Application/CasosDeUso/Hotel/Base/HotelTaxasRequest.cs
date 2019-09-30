using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Application.CasosDeUso.Hotel.Base
{
    public class HotelTaxasRequest
    {
        public string TipoCliente { get; set; }
        public string DiaSemana { get; set; }
        public decimal Valor { get; set; }
    }
}
