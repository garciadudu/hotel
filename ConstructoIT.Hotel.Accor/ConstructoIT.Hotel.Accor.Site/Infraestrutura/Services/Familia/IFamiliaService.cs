using ConstructoIT.Hotel.Accor.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Infraestrutura.Familia.Services
{
    public interface IFamiliaService
    {
        Task<List<FamiliaViewModel>> ListarAsync();
        Task<List<FamiliaViewModel>> ListarFamiliaAsync();
        Task<FamiliaViewModel> ObterFamiliaAsync(int id);

        Task<FamiliaViewModel> ObterAsync(int id);

        Task CadastrarAsync(FamiliaViewModel familia);

        Task AtualizarAsync(FamiliaViewModel familia);
        Task ExcluirAsync(int id);
    }
}
