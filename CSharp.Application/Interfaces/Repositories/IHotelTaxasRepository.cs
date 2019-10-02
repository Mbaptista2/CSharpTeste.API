using CSharp.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Application.Interfaces.Repositories
{
    public interface IHotelTaxasRepository : IRepository<HotelTaxasModel>
    {
        void ExcluirPorIdHotel(int idHotel);
        IEnumerable<HotelTaxasModel> BuscarTaxasPorTipoCliente(string tipoCliente);
        IEnumerable<HotelTaxasModel> BuscarTaxasPorIdHotel(int idHotel);
    }
}
