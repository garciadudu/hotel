using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Aplicacao.Interfaces
{
    public interface IApplicationServiceCondominio
    {
        void Add(CondominioDTO obj);
        Task AddAsync(CondominioDTO obj);
        CondominioDTO GetById(int id);
        IEnumerable<CondominioDTO> GetAll();
        void Update(CondominioDTO obj);
        void Remove(CondominioDTO obj);
        Task<IEnumerable<CondominioDTO>> GetAllAsync();
        Task<CondominioDTO> GetByFilterAsync(Expression<Func<CondominioDTO, bool>> expression);
        Task<IEnumerable<CondominioDTO>> GetAllByFilterAsync(Expression<Func<CondominioDTO, bool>> expression);
        Task<CondominioDTO> GetByIdAsync(int id);
        void Dispose();
    }
}
