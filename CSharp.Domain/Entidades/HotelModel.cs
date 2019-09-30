using CSharp.Domain.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Domain.Entidades
{
    public class HotelModel : DomainModel
    {
        public string Nome { get; set; }
        public int Classificacao { get; set; }
    }
}
