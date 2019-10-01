using CSharp.Application.CasosDeUso.Hotel.Calculos;
using CSharp.Domain.Entidades;
using System;
using System.Collections.Generic;
using Xunit;

namespace CSharpTestProject
{
    public class SampleUnitTest
    {

        private List<HotelTaxasModel> RetornaListaHotelTaxasClienteNormal()
        {
            List<HotelTaxasModel> hotelTaxasModels = new List<HotelTaxasModel>();
            var h1 = new HotelTaxasModel()
            {
                DiaSemana = "Semana",
                Hotel = new HotelModel()
                {
                    Classificacao = 3,
                    Id = 1,
                    Nome = "Lakewood"
                },
                Id = 1,
                TipoCliente = "Normal",
                Valor = 110
            };
            var h2 = new HotelTaxasModel()
            {
                DiaSemana = "FimSemana",
                Hotel = new HotelModel()
                {
                    Classificacao = 3,
                    Id = 1,
                    Nome = "Lakewood"
                },
                Id = 2,
                TipoCliente = "Normal",
                Valor = 90
            };
            var h3 = new HotelTaxasModel()
            {
                DiaSemana = "Semana",
                Hotel = new HotelModel()
                {
                    Classificacao = 4,
                    Id = 2,
                    Nome = "Bridgewood"
                },
                Id = 1,
                TipoCliente = "Normal",
                Valor = 160
            };
            var h4 = new HotelTaxasModel()
            {
                DiaSemana = "FimSemana",
                Hotel = new HotelModel()
                {
                    Classificacao = 4,
                    Id = 2,
                    Nome = "Bridgewood"
                },
                Id = 2,
                TipoCliente = "Normal",
                Valor = 60
            };
            var h5 = new HotelTaxasModel()
            {
                DiaSemana = "Semana",
                Hotel = new HotelModel()
                {
                    Classificacao = 5,
                    Id = 3,
                    Nome = "Ridgewood"
                },
                Id = 1,
                TipoCliente = "Normal",
                Valor = 220
            };
            var h6 = new HotelTaxasModel()
            {
                DiaSemana = "FimSemana",
                Hotel = new HotelModel()
                {
                    Classificacao = 5,
                    Id = 3,
                    Nome = "Ridgewood"
                },
                Id = 2,
                TipoCliente = "Normal",
                Valor = 150
            };

            hotelTaxasModels.Add(h1);
            hotelTaxasModels.Add(h2);
            hotelTaxasModels.Add(h3);
            hotelTaxasModels.Add(h4);
            hotelTaxasModels.Add(h5);
            hotelTaxasModels.Add(h6);

            return hotelTaxasModels;
        }
        private List<HotelTaxasModel> RetornaListaHotelTaxasClienteAfinidade()
        {
            List<HotelTaxasModel> hotelTaxasModels = new List<HotelTaxasModel>();
            var h1 = new HotelTaxasModel()
            {
                DiaSemana = "Semana",
                Hotel = new HotelModel()
                {
                    Classificacao = 3,
                    Id = 1,
                    Nome = "Lakewood"
                },
                Id = 1,
                TipoCliente = "Afinidade",
                Valor = 80
            };
            var h2 = new HotelTaxasModel()
            {
                DiaSemana = "FimSemana",
                Hotel = new HotelModel()
                {
                    Classificacao = 3,
                    Id = 1,
                    Nome = "Lakewood"
                },
                Id = 2,
                TipoCliente = "Afinidade",
                Valor = 80
            };
            var h3 = new HotelTaxasModel()
            {
                DiaSemana = "Semana",
                Hotel = new HotelModel()
                {
                    Classificacao = 4,
                    Id = 2,
                    Nome = "Bridgewood"
                },
                Id = 1,
                TipoCliente = "Afinidade",
                Valor = 110
            };
            var h4 = new HotelTaxasModel()
            {
                DiaSemana = "FimSemana",
                Hotel = new HotelModel()
                {
                    Classificacao = 4,
                    Id = 2,
                    Nome = "Bridgewood"
                },
                Id = 2,
                TipoCliente = "Afinidade",
                Valor = 50
            };
            var h5 = new HotelTaxasModel()
            {
                DiaSemana = "Semana",
                Hotel = new HotelModel()
                {
                    Classificacao = 5,
                    Id = 3,
                    Nome = "Ridgewood"
                },
                Id = 1,
                TipoCliente = "Afinidade",
                Valor = 100
            };
            var h6 = new HotelTaxasModel()
            {
                DiaSemana = "FimSemana",
                Hotel = new HotelModel()
                {
                    Classificacao = 5,
                    Id = 3,
                    Nome = "Ridgewood"
                },
                Id = 2,
                TipoCliente = "Afinidade",
                Valor = 40
            };

            hotelTaxasModels.Add(h1);
            hotelTaxasModels.Add(h2);
            hotelTaxasModels.Add(h3);
            hotelTaxasModels.Add(h4);
            hotelTaxasModels.Add(h5);
            hotelTaxasModels.Add(h6);

            return hotelTaxasModels;
        }       

        [Fact]
        public void RetornarHotelMaisBaratoComIntervaloDeDataLakewood()
        {
            List<DateTime> dates = new List<DateTime>();
            var d1 = new DateTime(2009, 03, 15);
            var d2 = new DateTime(2009, 03, 17);
            var d3 = new DateTime(2009, 03, 18);

            dates.Add(d1);
            dates.Add(d2);
            dates.Add(d3);

            var taxas = RetornaListaHotelTaxasClienteNormal();

            CalcularHotelMaisBarato calcularHotelMaisBarato = new CalcularHotelMaisBarato();

            var nome = calcularHotelMaisBarato.Calcular(taxas, dates);


            Assert.Equal("Lakewood", nome);
        }
        [Fact]
        public void RetornarHotelMaisBaratoComIntervaloDeDataBridgewood()
        {
            List<DateTime> dates = new List<DateTime>();
            var d1 = new DateTime(2009, 03, 20);
            var d2 = new DateTime(2009, 03, 21);
            var d3 = new DateTime(2009, 03, 22);

            dates.Add(d1);
            dates.Add(d2);
            dates.Add(d3);

            var taxas = RetornaListaHotelTaxasClienteNormal();

            CalcularHotelMaisBarato calcularHotelMaisBarato = new CalcularHotelMaisBarato();

            var nome = calcularHotelMaisBarato.Calcular(taxas, dates);


            Assert.Equal("Bridgewood", nome);
        }
        [Fact]
        public void RetornarHotelMaisBaratoComIntervaloDeDataRidgewood()
        {
            List<DateTime> dates = new List<DateTime>();
            var d1 = new DateTime(2009, 03, 26);
            var d2 = new DateTime(2009, 03, 27);
            var d3 = new DateTime(2009, 03, 28);

            dates.Add(d1);
            dates.Add(d2);
            dates.Add(d3);

            var taxas = RetornaListaHotelTaxasClienteAfinidade();

            CalcularHotelMaisBarato calcularHotelMaisBarato = new CalcularHotelMaisBarato();

            var nome = calcularHotelMaisBarato.Calcular(taxas, dates);


            Assert.Equal("Ridgewood", nome);
        }
    }
}
