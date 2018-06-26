using AutoMapper;
using MicroBolt.Clients.Data.Contracts.Entity;
using MicroBolt.Clients.Data.Contracts.Repositories;
using MicroBolt.Clients.Models;
using MicroBolt.Clients.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroBolt.Clients.MessageBus;

namespace MicroBolt.Clients.Services
{
   
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;
        public IRabbitTransfer rat;

        public ClientService(IClientRepository clientRepository,
            IMapper mapper, IRabbitTransfer rat)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
            this.rat = rat;
        }

        public async Task<TResult> Get<TResult>(string id)
        {
            return this.mapper.Map<TResult>(await this.clientRepository.Get(id));
        }

        public async Task<ICollection<TResult>> GetMany<TResult>()
        {
            rat.Start();
            return this.mapper.Map<ICollection<TResult>>(await this.clientRepository.GetMany());
        }

        public async Task Create(ClientModel model)
        {
            var enity = this.mapper.Map<Client>(model);
            await this.clientRepository.Create(enity);
        }

        public async Task Update(ClientModel model)
        {
            var entity = this.mapper.Map<Client>(model);
            await this.clientRepository.Update(entity);
        }
        public async Task Delete(string id)
        {
            await this.clientRepository.Delete(id);
        }
    }
}
