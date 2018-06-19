using AutoMapper;
using MicroBolt.Stock.Data;
using MicroBolt.Stock.Data.Contracts.Entity;
using MicroBolt.Stock.Data.Contracts.Repositories;
using MicroBolt.Stock.Models;
using MicroBolt.Stock.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBolt.Stock.Services
{
    public class BoltService : IBoltService
    {
        private readonly IBoltRepository boltRepository;
        private readonly IMapper mapper;
        
        public BoltService(IBoltRepository boltRepository,
            IMapper mapper)
        {
            this.boltRepository = boltRepository;
            this.mapper = mapper;
        }

        public async Task<TResult> Get<TResult>(string id)
        {
            return this.mapper.Map<TResult>(await this.boltRepository.Get(id));
        }

        public async Task<ICollection<TResult>> GetMany<TResult>(int skip, int top)
        {
            return this.mapper.Map<ICollection<TResult>>(await this.boltRepository.GetMany(skip, top));
        }

        public async Task Create(BoltModel model)
        {
            var enity = this.mapper.Map<Bolt>(model);
            await this.boltRepository.Create(enity);
        }

        public async Task Update(BoltModel model)
        {
            var entity = this.mapper.Map<Bolt>(model);
            await this.boltRepository.Update(entity);
        }
        public async Task Delete(string id)
        {
            await this.boltRepository.Delete(id);
        }
    }
}
