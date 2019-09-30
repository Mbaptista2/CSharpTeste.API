using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Application.CasosDeUso.Hotel.Base
{
    public class HotelMaisBaratoRequest
    {
        public string TipoCliente { get; set; }
        public IEnumerable<DateTime> Datas { get; set; }
    }
}
