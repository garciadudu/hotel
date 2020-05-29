using ConstructoIT.Hotel.Accor.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Infraestrutura.Morador.Services
{
    public interface IMoradorService
    {
        Task<List<MoradorViewModel>> ListarAsync();
        Task<List<MoradorViewModel>> ListarMoradorAsync();
        Task<MoradorViewModel> ObterMoradorAsync(int id);

        Task<MoradorViewModel> ObterAsync(int id);
        Task CadastrarAsync(MoradorViewModel morador);
        Task AtualizarAsync(MoradorViewModel morador);
        Task ExcluirAsync(int id);
    }
}
