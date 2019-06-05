using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.ValueObjects;

namespace EP.CursoMvc.Domain.Specification.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPF.Validar(cliente.CPF);
        }
    }

    public class DeveTerCpfValidoSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string cpf)
        {
            return CPF.Validar(cpf);
        }
    }
}