using CSharp.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Infra.Data.Mappings.Hotel
{
    public class HotelMap : MapBase<HotelDataModel>
    {
        public HotelMap()
        {
            CreateIdColumn("Hotel", "Id");

            Map(m => m.Nome, "Nome");
            Map(m => m.Classificacao, "Classificacao");
        }
    }
}
