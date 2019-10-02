using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Application.CasosDeUso.Hotel.Base
{
    public class HotelResponse : CasoDeUsoResponseMessage
    {
        public string Nome { get; set; }
        public int Classificacao { get; set; }       
        public HotelResponse() { }
        public HotelResponse(string message, bool error) : base(message, error) { }

        public HotelResponse(IEnumerable<string> errors) : base(errors) { }
    }
}
