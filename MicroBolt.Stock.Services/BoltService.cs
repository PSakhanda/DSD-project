using AutoMapper;
using MicroBolt.Stock.Data;
using MicroBolt.Stock.Data.Contracts.Entity;
using MicroBolt.Stock.Data.Contracts.Repositories;
using MicroBolt.Stock.Models;
using MicroBolt.Stock.Services.Contracts;
using System;
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
            return this.mapper.Map<TResult>(await this.boltRepository.GetBolt(id));
        }

        public async Task Create(BoltModel model)
        {
            var enity = this.mapper.Map<Bolt>(model);
            await this.boltRepository.CreateBolt(enity);
        }

        public async Task Update(BoltModel model)
        {
            var entity = this.mapper.Map<Bolt>(model);
            await this.boltRepository.UpdateBolt(entity);
        }
        public async Task Delete(string id)
        {
            await this.boltRepository.DeleteBolt(id);
        }
    }
}
