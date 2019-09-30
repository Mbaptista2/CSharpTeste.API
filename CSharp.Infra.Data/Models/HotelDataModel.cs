using CSharp.Infra.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Infra.Data.Models
{
    public class HotelDataModel : DataModel
    {
        public virtual string Nome { get; set; }
        public virtual int Classificacao { get; set; }
    }
}
