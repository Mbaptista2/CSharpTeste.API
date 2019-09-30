using CSharp.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Application.CasosDeUso.Hotel.Calculos
{
    public interface ICalcularHotelMaisBarato
    {
        string Calcular(IEnumerable<HotelTaxasModel> taxas, IEnumerable<DateTime> Datas);
    }
}
