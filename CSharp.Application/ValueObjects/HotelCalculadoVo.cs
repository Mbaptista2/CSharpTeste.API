using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Application.ValueObjects
{
    public class HotelCalculadoVo
    {
        public int idHotel { get; set; }
        public string Nome { get; set; }
        public int Classificacao { get; set; }
        public decimal Valor { get; set; }
    }
}
