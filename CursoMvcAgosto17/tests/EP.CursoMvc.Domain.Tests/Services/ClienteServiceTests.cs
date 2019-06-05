using System;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace EP.CursoMvc.Domain.Tests.Services
{
    [TestClass]
    public class ClienteServiceTests
    {
        [TestMethod]
        public void ClienteService_Adicionar_DeveRetornarComSucesso()
        {
            // Arrange
            var cliente = new Cliente
            {
                CPF = "30390600822",
                Email = "cliente@cliente.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            cliente.EhValido();

            // Act
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.Adicionar(cliente)).Return(cliente);
            repo.Stub(s => s.ObterClienteUnico(cliente)).Return(null);

            var clienteReturn = new ClienteService(repo).Adicionar(cliente);

            // Assert
            Assert.IsTrue(clienteReturn.ValidationResult.IsValid);
        }
    }
}