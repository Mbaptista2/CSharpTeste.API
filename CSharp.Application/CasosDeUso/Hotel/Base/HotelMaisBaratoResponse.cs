using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Application.CasosDeUso.Hotel.Base
{
    public class HotelMaisBaratoResponse : CasoDeUsoResponseMessage
    {
        public string Nome { get; set; }
        public HotelMaisBaratoResponse() { }
        public HotelMaisBaratoResponse(string message, bool error) : base(message, error) { }

        public HotelMaisBaratoResponse(IEnumerable<string> errors) : base(errors) { }
    }
}
