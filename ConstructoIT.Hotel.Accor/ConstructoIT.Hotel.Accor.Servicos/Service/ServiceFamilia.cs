using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Repository;
using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Service;
using ConstructoIT.Hotel.Accor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Servicos.Service
{
    public class ServiceFamilia: ServiceBase<Familia>, IServiceFamilia
    {
        public readonly IRepositoryFamilia _repository;

        public ServiceFamilia(IRepositoryFamilia repository): base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FamiliaDTO>> GetAllFamiliaAsync()
        {
            return await _repository.GetAllFamiliaAsync();
        }

        public async Task<FamiliaDTO> ObterFamiliaAsync(int id)
        {
            return await _repository.ObterFamiliaAsync(id);
        }

    }
}
