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
    public class ApplicationServiceCondominio : IApplicationServiceCondominio
    {
        private readonly IServiceCondominio _serviceCondominio;
        public ApplicationServiceCondominio(IServiceCondominio serviceCondominio)
        {
            _serviceCondominio = serviceCondominio;
        }

        public void Add(CondominioDTO obj)
        {
            try
            {
                var objNew = Mapeador.Mapear<CondominioDTO, Condominio>(obj);

                _serviceCondominio.Add(objNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            _serviceCondominio.Dispose();
        }
        public IEnumerable<CondominioDTO> GetAll()
        {
            var objCondominios = _serviceCondominio.GetAll();
            return Mapeador.Mapear<IEnumerable<Condominio>, IEnumerable<CondominioDTO>>(objCondominios);
        }
        public CondominioDTO GetById(int id)
        {
            var obj = _serviceCondominio.GetById(id);
            return Mapeador.Mapear<Condominio, CondominioDTO>(obj);
        }
        public async Task<CondominioDTO> GetByIdAsync(int id)
        {
            var obj = await _serviceCondominio.GetByIdAsync(id);
            return Mapeador.Mapear<Condominio, CondominioDTO>(obj);
        }
        public void Remove(CondominioDTO obj)
        {
            var objNew = Mapeador.Mapear<CondominioDTO, Condominio>(obj);
            _serviceCondominio.Remove(objNew);
        }
        public void Update(CondominioDTO obj)
        {
            try
            {
                var objNew = Mapeador.Mapear<CondominioDTO, Condominio>(obj);

                _serviceCondominio.Update(objNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CondominioDTO>> GetAllAsync()
        {
            var objCondominios = await _serviceCondominio.GetAllAsync();
            return Mapeador.Mapear<IEnumerable<Condominio>, IEnumerable<CondominioDTO>>(objCondominios);
        }

        public async Task AddAsync(CondominioDTO obj)
        {
            try
            {
                var objNew = Mapeador.Mapear<CondominioDTO, Condominio>(obj);

                await _serviceCondominio.AddAsync(objNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Task<IEnumerable<CondominioDTO>> GetAllByFilterAsync(Expression<Func<CondominioDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<CondominioDTO> GetByFilterAsync(Expression<Func<CondominioDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

    }
}
