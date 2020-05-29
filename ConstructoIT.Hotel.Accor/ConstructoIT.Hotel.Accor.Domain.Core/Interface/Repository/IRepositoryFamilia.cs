using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using ConstructoIT.Hotel.Accor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Domain.Core.Interface.Repository
{
    public interface IRepositoryFamilia : IRepositoryBase<Familia>
    {
        Task<IEnumerable<FamiliaDTO>> GetAllFamiliaAsync();
        Task<FamiliaDTO> ObterFamiliaAsync(int id);
    }
}
