using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Repository;
using ConstructoIT.Hotel.Accor.Domain.Entities;
using ConstructoIT.Hotel.Accor.Dominio.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructoIT.Hotel.Accor.Infraestrutura.Repository.Repositorio
{
    public class RepositoryCondominio: RepositorioGenerico<Condominio>, IRepositoryCondominio
    {
        private readonly ConstructoItDbContext _context;
        public RepositoryCondominio(ConstructoItDbContext context): base(context)
        {
            _context = context;
        }
    }
}
