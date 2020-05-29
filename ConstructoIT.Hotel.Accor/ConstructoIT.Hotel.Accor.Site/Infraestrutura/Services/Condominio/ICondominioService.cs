using ConstructoIT.Hotel.Accor.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Infraestrutura.Condominio.Services
{
    public interface ICondominioService
    {
        Task<List<CondominioViewModel>> ListarAsync();

        Task<CondominioViewModel> ObterAsync(int id);

        Task CadastrarAsync(CondominioViewModel condominio);

        Task AtualizarAsync(CondominioViewModel condominio);
        Task ExcluirAsync(int id);
    }
}
