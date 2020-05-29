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
    public class RepositoryFamilia: RepositorioGenerico<Familia>, IRepositoryFamilia
    {
        private readonly ConstructoItDbContext _context;

        public RepositoryFamilia(ConstructoItDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FamiliaDTO>> GetAllFamiliaAsync()
        {
            return await _context.Familia.Select(x => new FamiliaDTO
            {
                Id = x.Id,
                Condominio = x.Condominio.Nome,
                Id_Condominio = x.Id_Condominio,
                Nome = x.Nome,
                Apto = x.Apto,
            }).ToListAsync();
        }

        public async Task<FamiliaDTO> ObterFamiliaAsync(int id)
        {
            return await _context.Familia.Select(x => new FamiliaDTO
            {
                Id = x.Id,
                Condominio = x.Condominio.Nome,
                Id_Condominio = x.Id_Condominio,
                Nome = x.Nome,
                Apto = x.Apto,
            })
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        }


    }
}
