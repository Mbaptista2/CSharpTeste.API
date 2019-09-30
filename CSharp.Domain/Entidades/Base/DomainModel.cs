using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Domain.Entidades.Base
{
    public abstract class DomainModel: IDomainModel
    {
        public int Id { get; set; }
    }
}
