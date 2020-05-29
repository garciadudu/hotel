using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Aplicacao.Interfaces
{
    public interface IApplicationServiceFamilia
    {
        void Add(FamiliaDTO obj);
        Task AddAsync(FamiliaDTO obj);
        FamiliaDTO GetById(int id);
        IEnumerable<FamiliaDTO> GetAll();
        Task<IEnumerable<FamiliaDTO>> GetAllFamiliaAsync();
        Task<FamiliaDTO> ObterFamiliaAsync(int id);

        void Update(FamiliaDTO obj);
        void Remove(FamiliaDTO obj);
        Task<IEnumerable<FamiliaDTO>> GetAllAsync();
        Task<FamiliaDTO> GetByFilterAsync(Expression<Func<FamiliaDTO, bool>> expression);
        Task<IEnumerable<FamiliaDTO>> GetAllByFilterAsync(Expression<Func<FamiliaDTO, bool>> expression);
        Task<FamiliaDTO> GetByIdAsync(int id);
        void Dispose();
    }
}
