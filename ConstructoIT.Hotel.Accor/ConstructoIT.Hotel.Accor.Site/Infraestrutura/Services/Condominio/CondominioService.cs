using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Condominio.Services;
using ConstructoIT.Hotel.Accor.Site.Models;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services.Condominio
{
    public class CondominioService: ConstrutoITServiceBase, ICondominioService
    {
        public CondominioService(RestClient client, ILogger<CondominioService> logger): base(client, logger)
        {
            ResourceUri = "api/Condominio";
        }

        public Task<List<CondominioViewModel>> ListarAsync()
        {
            var request = CreateRequest(ResourceUri);
            return ExecuteAsync<List<CondominioViewModel>>(request);
        }

        public Task<CondominioViewModel> ObterAsync(int id)
        {
            var request = CreateRequest($"{ResourceUri}/{id}");
            return ExecuteAsync<CondominioViewModel>(request);
        }

        public Task CadastrarAsync(CondominioViewModel condominio)
        {
            var request = CreateRequest(ResourceUri, Method.POST);
            request.AddJsonBody(condominio);
            return ExecuteAsync(request);
        }

        public Task AtualizarAsync(CondominioViewModel condominio)
        {
            var request = CreateRequest($"{ResourceUri}/{condominio.Id}", Method.PUT);
            request.AddJsonBody(condominio);

            return ExecuteAsync(request);
        }

        public Task ExcluirAsync(int id)
        {
            var request = CreateRequest($"{ResourceUri}/{id}", Method.DELETE);
            return ExecuteAsync(request);
        }
    }
}
