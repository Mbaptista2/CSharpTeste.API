using AutoMapper;
using CSharp.Application.CasosDeUso.Hotel.Calculos;
using CSharp.Application.Interfaces.CasosDeUso;
using CSharp.Application.Interfaces.Repositories;
using CSharp.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Application.CasosDeUso.Hotel.Base
{
    public class HotelCasoDeUso : IHotelCasoDeUso
    {
        private readonly IHotelRepository _HotelRepository;
        private readonly IHotelTaxasRepository _hotelTaxasRepository;
        //private readonly IValidator<InserirHotelRequest> _inserirHotelValidator;
        //private readonly IValidator<AlterarHotelRequest> _alterarHotelValidator;
        private readonly IMapper _mapper;

        public HotelCasoDeUso(IHotelRepository HotelRepository,
            IHotelTaxasRepository hotelTaxasRepository,
           //IValidator<InserirHotelRequest> inserirHotelValidator,
           //IValidator<AlterarHotelRequest> alterarHotelValidator,
           IMapper mapper)
        {
            _HotelRepository = HotelRepository;
            _hotelTaxasRepository = hotelTaxasRepository;
            // _inserirHotelValidator = inserirHotelValidator;
            //_alterarHotelValidator = alterarHotelValidator;
            _mapper = mapper;
        }

        public async Task Inserir(InserirHotelRequest HotelRequest, IOutputPort<HotelResponse> outputPort)
        {
            //var validations = _inserirHotelValidator.Validate(HotelRequest);

            //if (!validations.IsValid)
            //{
            //    outputPort.Handler(new HotelResponse(validations.Errors.Select(x => x.ErrorMessage)));
            //    return;
            //}

            var a = _mapper.Map<HotelModel>(HotelRequest);
            await _HotelRepository.Inserir(a);

            foreach (var item in HotelRequest.Taxas)
            {
                var taxa = _mapper.Map<HotelTaxasModel>(item);
                taxa.Hotel = new HotelModel() { Id = a.Id };
                await _hotelTaxasRepository.Inserir(taxa);
            }
            outputPort.Handler(_mapper.Map<HotelResponse>(a));
        }

        public async Task Alterar(AlterarHotelRequest HotelRequest, IOutputPort<HotelResponse> outputPort)
        {
            //var validations = _alterarHotelValidator.Validate(HotelRequest);

            //if (!validations.IsValid)
            //{
            //    outputPort.Handler(new HotelResponse(validations.Errors.Select(x => x.ErrorMessage)));
            //    return;
            //}

            if (!await Existe(HotelRequest.Id, outputPort))
                return;

            var HotelModel = _mapper.Map<HotelModel>(HotelRequest);
            await _HotelRepository.Alterar(HotelModel);


            outputPort.Handler(_mapper.Map<HotelResponse>(HotelModel));
        }

        public async Task Excluir(int id, IOutputPort<HotelResponse> outputPort)
        {
            if (!await Existe(id, outputPort))
                return;

            _hotelTaxasRepository.ExcluirPorIdHotel(id);
            await _HotelRepository.Excluir(id);
        }

        public async Task ObterPorId(int id, IOutputPort<HotelResponse> outputPort)
        {
            var HotelModel = await _HotelRepository.ObterPorId(id);

            if (HotelModel != null)
                outputPort.Handler(_mapper.Map<HotelResponse>(HotelModel));
        }

        public async Task ObterLista(IOutputPort<IEnumerable<HotelResponse>> outputPort)
        {
            outputPort.Handler(_mapper.Map<IEnumerable<HotelResponse>>(await _HotelRepository.ObterLista()));
        }

        private async Task<bool> Existe(int id, IOutputPort<HotelResponse> outputPort)
        {
            var existe = await _HotelRepository.Existe(id);

            if (!existe)
                outputPort.Handler(new HotelResponse("Id não encoontrado", true));

            return existe;
        }

        public async Task HotelMaisBrato(HotelMaisBaratoRequest HotelRequest, IOutputPort<HotelMaisBaratoResponse> outputPort)
        {
            //var validations = _alterarHotelValidator.Validate(HotelRequest);

            //if (!validations.IsValid)
            //{
            //    outputPort.Handler(new HotelResponse(validations.Errors.Select(x => x.ErrorMessage)));
            //    return;
            //}

            var taxas = _hotelTaxasRepository.BuscarTaxasPorIdHotel(HotelRequest.TipoCliente);

            CalcularHotelMaisBarato calcularHotelMaisBarato = new CalcularHotelMaisBarato();

            HotelMaisBaratoResponse response = new HotelMaisBaratoResponse();

            response.Nome= calcularHotelMaisBarato.Calcular(taxas, HotelRequest.Datas);

            outputPort.Handler(response);
        }
    }
}
