using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Repository;
using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Service;
using ConstructoIT.Hotel.Accor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Servicos.Service
{
    public class ServiceCondominio: ServiceBase<Condominio>, IServiceCondominio
    {
        public readonly IRepositoryCondominio _repository;

        public ServiceCondominio(IRepositoryCondominio repository): base(repository)
        {
            _repository = repository;
        }
    }
}
