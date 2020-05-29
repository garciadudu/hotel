using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Aplicacao.Interfaces
{
    public interface IApplicationServiceMorador
    {
        void Add(MoradorDTO obj);
        Task AddAsync(MoradorDTO obj);
        MoradorDTO GetById(int id);
        IEnumerable<MoradorDTO> GetAll();
        Task<IEnumerable<MoradorDTO>> GetAllMoradorAsync();
        public Task<MoradorDTO> ObterMoradorAsync(int id);
        void Update(MoradorDTO obj);
        void Remove(MoradorDTO obj);
        Task<IEnumerable<MoradorDTO>> GetAllAsync();
        Task<MoradorDTO> GetByFilterAsync(Expression<Func<MoradorDTO, bool>> expression);
        Task<IEnumerable<MoradorDTO>> GetAllByFilterAsync(Expression<Func<MoradorDTO, bool>> expression);
        Task<MoradorDTO> GetByIdAsync(int id);
        void Dispose();

    }
}
