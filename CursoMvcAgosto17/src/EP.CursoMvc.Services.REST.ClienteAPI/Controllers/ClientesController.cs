using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.ViewModels;
using Newtonsoft.Json;
using EP.CursoMvc.Infra.CrossCutting.MvcFilters;

// Identity - Cookie
// Identity - JWT

namespace EP.CursoMvc.Services.REST.ClienteAPI.Controllers
{
    [EnableCors(headers: "*", methods: "POST,GET", origins: "*")]
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return _clienteAppService.ObterAtivos();
        }

        [HttpGet]
        public ClienteViewModel ObterPorId(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        [HttpPost]
        [ClaimsAuthorize("Clientes","NV")]
        public IHttpActionResult Adicionar([FromBody]ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var @return = _clienteAppService.Adicionar(clienteEnderecoViewModel).Cliente.ValidationResult;
            return !@return.IsValid ? TratarErros(@return) : Ok();
        }

        [HttpPut]
        public IHttpActionResult Atualizar(Guid id, [FromBody]ClienteViewModel clienteViewModel)
        {
            var @return = _clienteAppService.Atualizar(clienteViewModel).ValidationResult;
            return !@return.IsValid ? TratarErros(@return) : Ok();
        }

        [HttpDelete]
        public void Remover(Guid id)
        {
            _clienteAppService.Remover(id);
        }

        private IHttpActionResult TratarErros(DomainValidation.Validation.ValidationResult result)
        {
            return BadRequest(JsonConvert.SerializeObject(result.Erros));
        }
    }
}
