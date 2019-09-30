using CSharp.Application.CasosDeUso.Hotel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Application.Interfaces.CasosDeUso
{
    public interface IHotelCasoDeUso
    {
        Task Inserir(InserirHotelRequest testeExtensaoRequest, IOutputPort<HotelResponse> outputPort);
        Task Alterar(AlterarHotelRequest testeExtensaoRequest, IOutputPort<HotelResponse> outputPort);
        Task Excluir(int id, IOutputPort<HotelResponse> outputPort);
        Task ObterPorId(int id, IOutputPort<HotelResponse> outputPort);
        Task ObterLista(IOutputPort<IEnumerable<HotelResponse>> outputPort);
        Task HotelMaisBrato(HotelMaisBaratoRequest HotelRequest, IOutputPort<HotelMaisBaratoResponse> outputPort);
    }
}
