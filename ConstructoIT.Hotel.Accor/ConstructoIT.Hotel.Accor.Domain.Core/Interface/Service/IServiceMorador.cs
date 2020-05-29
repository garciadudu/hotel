using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using ConstructoIT.Hotel.Accor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Domain.Core.Interface.Service
{
    public interface IServiceMorador: IServiceBase<Morador>
    {
        public Task<IEnumerable<MoradorDTO>> GetAllMoradorAsync();
        public Task<MoradorDTO> ObterMoradorAsync(int id);
    }
}
