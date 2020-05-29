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
    public class ServiceMorador: ServiceBase<Morador>, IServiceMorador
    {
        public readonly IRepositoryMorador _repository;

        public ServiceMorador(IRepositoryMorador repository): base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MoradorDTO>> GetAllMoradorAsync()
        {
            return await _repository.GetAllMoradorAsync();
        }

        public async Task<MoradorDTO> ObterMoradorAsync(int id)
        {
            return await _repository.ObterMoradorAsync(id);
        }
    }
}
