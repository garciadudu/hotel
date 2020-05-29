using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using ConstructoIT.Hotel.Accor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Domain.Core.Interface.Service
{
    public interface IServiceFamilia: IServiceBase<Familia>
    {
        public Task<IEnumerable<FamiliaDTO>> GetAllFamiliaAsync();
        public Task<FamiliaDTO> ObterFamiliaAsync(int id);
    }
}
