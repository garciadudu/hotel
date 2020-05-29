using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Repository;
using ConstructoIT.Hotel.Accor.Domain.Entities;
using ConstructoIT.Hotel.Accor.Dominio.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Infraestrutura.Repository.Repositorio
{
    public class RepositoryMorador: RepositorioGenerico<Morador>, IRepositoryMorador
    {
        private readonly ConstructoItDbContext _context;

        public RepositoryMorador(ConstructoItDbContext context): base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<MoradorDTO>> GetAllMoradorAsync()
        {
            return await _context.Morador.Select(x => new MoradorDTO
            {
                Id = x.Id,
                Id_Familia = x.Id_Familia,
                Nome = x.Nome,
                QuantidadeBichosEstimacao = x.QuantidadeBichosEstimacao,
                Familia = x.Familia.Nome,
            }).ToListAsync();
        }
        public async Task<MoradorDTO> ObterMoradorAsync(int id)
        {
            var morador = await _context.Morador
                .Where(x => x.Id == id)
                .Include(x=>x.Familia)
                .Select(x => new MoradorDTO
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        QuantidadeBichosEstimacao = x.QuantidadeBichosEstimacao,
                        Id_Familia = x.Id_Familia,
                        Familia = x.Familia.Nome
                    })
                .FirstOrDefaultAsync();

            return morador;
        }
    }
}
