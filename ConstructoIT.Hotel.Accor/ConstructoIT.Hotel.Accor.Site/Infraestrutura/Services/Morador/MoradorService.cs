using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Morador.Services;
using ConstructoIT.Hotel.Accor.Site.Models;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services.Morador
{
    public class MoradorService : ConstrutoITServiceBase, IMoradorService
    {
        public MoradorService(RestClient client, ILogger<MoradorService> logger) : base(client, logger)
        {
            ResourceUri = "api/Morador";
        }

        public Task<List<MoradorViewModel>> ListarAsync()
        {
            var request = CreateRequest(ResourceUri);
            return ExecuteAsync<List<MoradorViewModel>>(request);
        }

        public Task<List<MoradorViewModel>> ListarMoradorAsync()
        {
            var request = CreateRequest($"{ResourceUri}/GetAllMorador");
            return ExecuteAsync<List<MoradorViewModel>>(request);
        }

        public Task<MoradorViewModel> ObterMoradorAsync(int id)
        {
            var request = CreateRequest($"{ResourceUri}/ObterMorador/{id}");
            return ExecuteAsync<MoradorViewModel>(request);
        }

        public Task<MoradorViewModel> ObterAsync(int id)
        {
            var request = CreateRequest($"{ResourceUri}/{id}");
            return ExecuteAsync<MoradorViewModel>(request);
        }

        public Task CadastrarAsync(MoradorViewModel morador)
        {
            var request = CreateRequest(ResourceUri, Method.POST);
            request.AddJsonBody(morador);
            return ExecuteAsync(request);
        }

        public Task AtualizarAsync(MoradorViewModel morador)
        {
            var request = CreateRequest($"{ResourceUri}/{morador.Id}", Method.PUT);
            request.AddJsonBody(morador);

            return ExecuteAsync(request);
        }

        public Task ExcluirAsync(int id)
        {
            var request = CreateRequest($"{ResourceUri}/{id}", Method.DELETE);
            return ExecuteAsync(request);
        }

    }
}
