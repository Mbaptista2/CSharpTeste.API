using CSharp.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Application.Extensions
{
    public static class HotelTaxaModelsExtensions
    {
        public static decimal CalculaPreco(this List<HotelTaxasModel> list, int nroDiasSemana, int nroDiasFimSemana)
        {
            decimal valorFimDeSemana = 0;
            decimal valorSemana = 0;
            if (nroDiasFimSemana > 0)
            {
                valorFimDeSemana = list.Where(y => y.DiaSemana == "FimSemana").FirstOrDefault().Valor * nroDiasFimSemana;
            }
            if (nroDiasSemana > 0)
            {
                valorSemana = list.Where(y => y.DiaSemana == "Semana").FirstOrDefault().Valor * nroDiasSemana;
            }

            return valorSemana + valorFimDeSemana;
        }
    }
}
