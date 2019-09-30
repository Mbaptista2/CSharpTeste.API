using AutoMapper;
using CSharp.Application.Interfaces.Repositories;
using CSharp.Domain.Entidades;
using CSharp.Infra.Data.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Infra.Data.Repositories
{
    public class HotelTaxasRepository : RepositoryBase<HotelTaxasModel, HotelTaxasDataModel>, IHotelTaxasRepository
    {
        public HotelTaxasRepository(ISessionFactory sessionFactory, IMapper mapper) : base(sessionFactory, mapper)
        {

        }

        public IEnumerable<HotelTaxasModel> BuscarTaxasPorIdHotel(string tipoCliente)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return _mapper.Map<List<HotelTaxasModel>>(session.Query<HotelTaxasDataModel>().Where(x => x.TipoCliente == tipoCliente).Select(y => y));
            }
        }

        public void  ExcluirPorIdHotel(int idHotel)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.Query<HotelTaxasDataModel>().Where(x => x.Hotel.Id == idHotel).Delete();
            }
        }
    }
}
