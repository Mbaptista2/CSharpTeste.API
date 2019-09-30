using CSharp.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Infra.Data.Mappings.HotelTaxas
{
    public class HotelTaxasMap : MapBase<HotelTaxasDataModel>
    {
        public HotelTaxasMap()
        {
            CreateIdColumn("Hotel_Taxas", "Id");

            Map(m => m.TipoCliente, "Tipo_Cliente");
            Map(m => m.DiaSemana, "Dia_Semana");
            Map(m => m.Valor, "Valor");

            References(x => x.Hotel, "Id_Hotel");


        }
    }
}
