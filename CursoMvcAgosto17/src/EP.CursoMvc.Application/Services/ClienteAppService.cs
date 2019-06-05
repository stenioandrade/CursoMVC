﻿using System;
using System.Collections.Generic;
using AutoMapper;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Interfaces.Services;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Infra.Data.UoW;

namespace EP.CursoMvc.Application.Services
{
    public class ClienteAppService : AppService, IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteRepository clienteRepository, 
                                 IClienteService clienteService,
                                 IUnitOfWork uow)
            : base(uow)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.Enderecos.Add(endereco);

            // mais de um item
            var clienteReturn = _clienteService.Adicionar(cliente);
            // + enderco
            // + registro adicional

            if (clienteReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            clienteEnderecoViewModel.Cliente = Mapper.Map<ClienteViewModel>(clienteReturn);

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            var clienteReturn = _clienteService.Atualizar(cliente);

            if (clienteReturn.ValidationResult.IsValid)
            {
                Commit();
            }
            
            return Mapper.Map<ClienteViewModel>(clienteReturn);
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            //return _clienteRepository.ObterAtivos().ProjectTo<ClienteViewModel>();
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            _clienteService.Dispose();
        }
    }
}