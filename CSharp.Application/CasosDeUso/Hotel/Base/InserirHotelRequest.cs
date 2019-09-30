using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Application.CasosDeUso.Hotel.Base
{
    public class InserirHotelRequest
    {        
        public string Nome { get; set; }
        public int Classificacao { get; set; }
        public IEnumerable<HotelTaxasRequest> Taxas { get; set; }
    }
}
