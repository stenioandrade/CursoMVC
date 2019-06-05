using System;
using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Models;

namespace EP.CursoMvc.Domain.Specification.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
        }
    }
}