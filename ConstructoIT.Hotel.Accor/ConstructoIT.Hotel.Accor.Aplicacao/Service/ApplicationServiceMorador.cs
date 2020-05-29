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
    public class ApplicationServiceMorador : IApplicationServiceMorador
    {
        private readonly IServiceMorador _serviceMorador;
        public ApplicationServiceMorador(IServiceMorador serviceMorador)
        {
            _serviceMorador = serviceMorador;
        }

        public void Add(MoradorDTO obj)
        {
            try
            {
                var objNew = Mapeador.Mapear<MoradorDTO, Morador>(obj);

                _serviceMorador.Add(objNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            _serviceMorador.Dispose();
        }
        public IEnumerable<MoradorDTO> GetAll()
        {
            var objMoradores = _serviceMorador.GetAll();
            return Mapeador.Mapear<IEnumerable<Morador>, IEnumerable<MoradorDTO>>(objMoradores);
        }

        public async Task<IEnumerable<MoradorDTO>> GetAllMoradorAsync()
        {
            return await _serviceMorador.GetAllMoradorAsync();
        }
        public MoradorDTO GetById(int id)
        {
            var obj = _serviceMorador.GetById(id);
            return Mapeador.Mapear<Morador, MoradorDTO>(obj);
        }
        public async Task<MoradorDTO> GetByIdAsync(int id)
        {
            var obj = await _serviceMorador.GetByIdAsync(id);
            return Mapeador.Mapear<Morador, MoradorDTO>(obj);
        }
        public void Remove(MoradorDTO obj)
        {
            var objNew = Mapeador.Mapear<MoradorDTO, Morador>(obj);
            _serviceMorador.Remove(objNew);
        }
        public void Update(MoradorDTO obj)
        {
            try
            {
                var objNew = Mapeador.Mapear<MoradorDTO, Morador>(obj);

                _serviceMorador.Update(objNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MoradorDTO>> GetAllAsync()
        {
            var objMoradores = await _serviceMorador.GetAllAsync();
            return Mapeador.Mapear<IEnumerable<Morador>, IEnumerable<MoradorDTO>>(objMoradores);
        }

        public async Task AddAsync(MoradorDTO obj)
        {
            try
            {
                var objNew = Mapeador.Mapear<MoradorDTO, Morador>(obj);

                await _serviceMorador.AddAsync(objNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MoradorDTO> ObterMoradorAsync(int id)
        {
            return await _serviceMorador.ObterMoradorAsync(id);
        }



        public Task<IEnumerable<MoradorDTO>> GetAllByFilterAsync(Expression<Func<MoradorDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<MoradorDTO> GetByFilterAsync(Expression<Func<MoradorDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

    }
}
