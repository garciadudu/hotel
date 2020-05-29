using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Familia.Services;
using ConstructoIT.Hotel.Accor.Site.Models;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services.Familia
{
    public class FamiliaService : ConstrutoITServiceBase, IFamiliaService
    {
        public FamiliaService(RestClient client, ILogger<FamiliaService> logger) : base(client, logger)
        {
            ResourceUri = "api/Familia";
        }

        public Task<List<FamiliaViewModel>> ListarAsync()
        {
            var request = CreateRequest(ResourceUri);
            return ExecuteAsync<List<FamiliaViewModel>>(request);
        }

        public Task<List<FamiliaViewModel>> ListarFamiliaAsync()
        {
            var request = CreateRequest($"{ResourceUri}/GetAllFamilia");
            return ExecuteAsync<List<FamiliaViewModel>>(request);
        }

        public Task<FamiliaViewModel> ObterFamiliaAsync(int id) {
            var request = CreateRequest($"{ResourceUri}/ObterFamilia/{id}");
            return ExecuteAsync<FamiliaViewModel>(request);
        }


        public Task<FamiliaViewModel> ObterAsync(int id)
        {
            var request = CreateRequest($"{ResourceUri}/{id}");
            return ExecuteAsync<FamiliaViewModel>(request);
        }

        public Task CadastrarAsync(FamiliaViewModel familia)
        {
            var request = CreateRequest(ResourceUri, Method.POST);
            request.AddJsonBody(familia);
            return ExecuteAsync(request);
        }

        public Task AtualizarAsync(FamiliaViewModel familia)
        {
            var request = CreateRequest($"{ResourceUri}/{familia.Id}", Method.PUT);
            request.AddJsonBody(familia);

            return ExecuteAsync(request);
        }

        public Task ExcluirAsync(int id)
        {
            var request = CreateRequest($"{ResourceUri}/{id}", Method.DELETE);
            return ExecuteAsync(request);
        }
    }
}
