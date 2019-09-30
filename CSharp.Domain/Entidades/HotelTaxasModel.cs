using CSharp.Domain.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Domain.Entidades
{
    public class HotelTaxasModel : DomainModel
    {
        public HotelModel Hotel { get; set; }
        public string TipoCliente { get; set; }
        public string DiaSemana { get; set; }
        public decimal Valor { get; set; }
    }
}
