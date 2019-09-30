using CSharp.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CSharp.Application.Extensions;
using CSharp.Application.ValueObjects;

namespace CSharp.Application.CasosDeUso.Hotel.Calculos
{
    public class CalcularHotelMaisBarato: ICalcularHotelMaisBarato
    {
        public string Calcular(IEnumerable<HotelTaxasModel> taxas, IEnumerable<DateTime> Datas)
        {
            var QtdeDiasfimSemana = Datas.Select(x => x).Where(y => y.FimDeSemana()).Count();
            var QtdeDiassemana = Datas.Select(x => x).Where(y => !y.FimDeSemana()).Count();


            var hoteis = taxas.GroupBy(x => new { x.Hotel.Id, x.Hotel.Nome, x.Hotel.Classificacao })
                   .Select(y => new HotelCalculadoVo()
                   {
                       idHotel = y.Key.Id,
                       Classificacao = y.Key.Classificacao,
                       Nome = y.Key.Nome,
                   }
                   );

            List<HotelCalculadoVo> hotelCalculadoVo = new List<HotelCalculadoVo>();
            foreach (var hotel in hoteis)
            {

                var taxaPorHotel = taxas.Where(x => x.Hotel.Id == hotel.idHotel).ToList();
                hotel.Valor = taxaPorHotel.CalculaPreco(QtdeDiassemana, QtdeDiasfimSemana);
                hotelCalculadoVo.Add(hotel);
            }

            return hotelCalculadoVo.OrderBy(x => x.Valor).ThenByDescending(x => x.Classificacao).FirstOrDefault().Nome;
        }
      
    }
      
}
