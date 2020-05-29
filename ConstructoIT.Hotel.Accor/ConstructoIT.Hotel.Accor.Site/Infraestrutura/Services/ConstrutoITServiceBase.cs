using Microsoft.AspNetCore.Connections.Features;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services
{
    public abstract class ConstrutoITServiceBase
    {
        private readonly RestClient _client;
        protected readonly ILogger<ConstrutoITServiceBase> Logger;
        protected string ResourceUri { get; set; }

        private readonly JsonSerializerOptions _SerializerOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public ConstrutoITServiceBase(RestClient client, ILogger<ConstrutoITServiceBase> logger)
        {
            _client = client;
            Logger = logger;
        }

        protected virtual RestRequest CreateRequest(string uri = null, Method method = Method.GET) => new RestRequest(uri ?? ResourceUri, method);

        protected virtual async Task<T> ExecuteAsync<T>(RestRequest request)
        {
            var response = await MakeRequestAsync(request);

            if (string.IsNullOrEmpty(response.Content)) return default;
            return JsonSerializer.Deserialize<T>(response.Content, _SerializerOptions);
        }

        protected virtual async Task ExecuteAsync(RestRequest request)
        {
            await MakeRequestAsync(request);
        }

        private async Task<IRestResponse> MakeRequestAsync(RestRequest request)
        {
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.NotFound && request.Method != Method.GET)
                {
                    Logger.LogInformation("Recurso não encontrado {path)", response.ResponseUri.ToString());
                    throw new ConstrutoITInvalidRequestException("Recurso não encontrado");
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    Logger.LogInformation("Recurso não encontrado {path}", response.ResponseUri.ToString());
                }

                if (response.ErrorException != null)
                {
                    Logger.LogError(response.ErrorException, "Erro ao excutar requisição. {EX}", response.ErrorException.Message);
                    throw response.ErrorException;
                }

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    Logger.LogError("Erro ao executar requisição. A api retornou bad request");

                    if (!string.IsNullOrEmpty(response.Content))
                    {
                        var erros = JsonSerializer.Deserialize<IDictionary<string, IEnumerable<string>>>(response.Content);
                        throw new ConstrutoITValidationException("Falha ao validar requisição", erros);
                    }
                }

                throw new HttpRequestException("Erro ao realizar requisição. O servidor retornou o status code " + (int)response.StatusCode);
            }

            return response;
        }
    }
}
