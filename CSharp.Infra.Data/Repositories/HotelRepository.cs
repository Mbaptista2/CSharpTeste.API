using AutoMapper;
using CSharp.Application.Interfaces.Repositories;
using CSharp.Domain.Entidades;
using CSharp.Infra.Data.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Infra.Data.Repositories
{   
        public class HotelRepository : RepositoryBase<HotelModel, HotelDataModel>, IHotelRepository
        {
            public HotelRepository(ISessionFactory sessionFactory, IMapper mapper) : base(sessionFactory, mapper)
            {

            }
        }
    
}
