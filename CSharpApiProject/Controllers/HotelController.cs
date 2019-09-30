using CSharp.ApiProject.Response;
using CSharp.Application.CasosDeUso.Hotel.Base;
using CSharp.Application.Interfaces.CasosDeUso;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.ApiProject.Controllers
{
    [Route("[controller]")]
    public class HotelController : Controller
    {
        private readonly IHotelCasoDeUso _hotelCasoDeUso;
        private readonly Presenter _presenter;

        public HotelController(IHotelCasoDeUso hotelCasoDeUso, Presenter presenter)
        {
            _hotelCasoDeUso = hotelCasoDeUso;
            _presenter = presenter;
        }

        [HttpPost]
        [Route(nameof(Inserir))]
        public async Task<IActionResult> Inserir([FromBody]InserirHotelRequest testeExtensaoRequest)
        {
            await _hotelCasoDeUso.Inserir(testeExtensaoRequest, _presenter);
            return _presenter.ContentResult;
        }

        [HttpPut]
        [Route(nameof(Alterar))]
        public async Task<IActionResult> Alterar([FromBody]AlterarHotelRequest testeExtensaoRequest)
        {
            await _hotelCasoDeUso.Alterar(testeExtensaoRequest, _presenter);
            return _presenter.ContentResult;
        }

        [HttpDelete]
        [Route(nameof(Excluir))]
        public async Task<IActionResult> Excluir(int id)
        {
            await _hotelCasoDeUso.Excluir(id, _presenter);
            return _presenter.ContentResult;
        }

        [HttpGet]
        [Route(nameof(ObterPorId))]
        public async Task<IActionResult> ObterPorId(int id)
        {
            await _hotelCasoDeUso.ObterPorId(id, _presenter);
            return _presenter.ContentResult;
        }

        [HttpGet]
        [Route(nameof(ObterLista))]
        public async Task<IActionResult> ObterLista()
        {
            await _hotelCasoDeUso.ObterLista(_presenter);
            return _presenter.ContentResult;
        }


        [HttpGet]
        [Route(nameof(HotelMaisBarato))]
        public async Task<IActionResult> HotelMaisBarato(HotelMaisBaratoRequest hotelMaisBaratoRequest)
        {
            await _hotelCasoDeUso.HotelMaisBrato(hotelMaisBaratoRequest, _presenter);
            return _presenter.ContentResult;
        }
    }
}
