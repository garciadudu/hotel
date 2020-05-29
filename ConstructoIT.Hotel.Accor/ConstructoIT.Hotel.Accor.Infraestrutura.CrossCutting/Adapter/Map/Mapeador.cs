using AutoMapper;
using AutoMapper.Configuration.Conventions;
using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using ConstructoIT.Hotel.Accor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Infraestrutura.CrossCutting.Adapter.Map
{
    public static class Mapeador
    {
        static MapperConfiguration configuration;

        static Mapeador()
        {
            configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Condominio, CondominioDTO>();
                cfg.CreateMap<CondominioDTO, Condominio>();

                cfg.CreateMap<Familia, FamiliaDTO>();
                cfg.CreateMap<FamiliaDTO, Familia>()
                .ForMember(x => x.Condominio, o => o.Ignore());

                cfg.CreateMap<Morador, MoradorDTO>();
                cfg.CreateMap<MoradorDTO, Morador>()
                .ForMember(x => x.Familia, o => o.Ignore());

            });
        }

        public static TDestino Mapear<TOrigem, TDestino>(TOrigem origem)
                where TOrigem : class
                 where TDestino : class
        {
            var mapper = configuration.CreateMapper();
            return mapper.Map<TOrigem, TDestino>(origem);
        }
    }
}
