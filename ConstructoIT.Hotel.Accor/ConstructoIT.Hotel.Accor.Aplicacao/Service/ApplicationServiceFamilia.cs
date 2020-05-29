using ConstructoIT.Hotel.Accor.Aplicacao.Interfaces;
using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Service;
using ConstructoIT.Hotel.Accor.Domain.Entities;
using ConstructoIT.Hotel.Accor.Infraestrutura.CrossCutting.Adapter.Map;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Aplicacao.Service
{
    public class ApplicationServiceFamilia : IApplicationServiceFamilia
    {
        private readonly IServiceFamilia _serviceFamilia;
        public ApplicationServiceFamilia(IServiceFamilia serviceFamilia)
        {
            _serviceFamilia = serviceFamilia;
        }

        public void Add(FamiliaDTO obj)
        {
            try
            {
                var objNew = Mapeador.Mapear<FamiliaDTO, Familia>(obj);

                _serviceFamilia.Add(objNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            _serviceFamilia.Dispose();
        }
        public IEnumerable<FamiliaDTO> GetAll()
        {
            var objFamilias = _serviceFamilia.GetAll();
            return Mapeador.Mapear<IEnumerable<Familia>, IEnumerable<FamiliaDTO>>(objFamilias);
        }
        public FamiliaDTO GetById(int id)
        {
            var obj = _serviceFamilia.GetById(id);
            return Mapeador.Mapear<Familia, FamiliaDTO>(obj);
        }
        public async Task<FamiliaDTO> GetByIdAsync(int id)
        {
            var obj = await _serviceFamilia.GetByIdAsync(id);
            return Mapeador.Mapear<Familia, FamiliaDTO>(obj);
        }
        public void Remove(FamiliaDTO obj)
        {
            var objNew = Mapeador.Mapear<FamiliaDTO, Familia>(obj);
            _serviceFamilia.Remove(objNew);
        }
        public void Update(FamiliaDTO obj)
        {
            try
            {
                var objNew = Mapeador.Mapear<FamiliaDTO, Familia>(obj);

                _serviceFamilia.Update(objNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<FamiliaDTO>> GetAllAsync()
        {
            var objFamilias = await _serviceFamilia.GetAllAsync();
            return Mapeador.Mapear<IEnumerable<Familia>, IEnumerable<FamiliaDTO>>(objFamilias);
        }

        public async Task AddAsync(FamiliaDTO obj)
        {
            try
            {
                var objNew = Mapeador.Mapear<FamiliaDTO, Familia>(obj);

                await _serviceFamilia.AddAsync(objNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<FamiliaDTO>> GetAllFamiliaAsync()
        {
            return await _serviceFamilia.GetAllFamiliaAsync();
        }

        public async Task<FamiliaDTO> ObterFamiliaAsync(int id)
        {
            return await _serviceFamilia.ObterFamiliaAsync(id);
        }



        public Task<IEnumerable<FamiliaDTO>> GetAllByFilterAsync(Expression<Func<FamiliaDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<FamiliaDTO> GetByFilterAsync(Expression<Func<FamiliaDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

    }
}
