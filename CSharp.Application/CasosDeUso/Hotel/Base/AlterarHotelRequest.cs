using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Application.CasosDeUso.Hotel.Base
{
    public class AlterarHotelRequest 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Classificacao { get; set; }
        public IEnumerable<HotelTaxasRequest> Taxas { get; set; }
    }
}
