using CSharp.Infra.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Infra.Data.Models
{
    public class HotelTaxasDataModel: DataModel
    {
        public virtual HotelDataModel Hotel { get; set; }
        public virtual string TipoCliente { get; set; }
        public virtual string DiaSemana { get; set; }        
        public virtual decimal Valor { get; set; }
    }
}
