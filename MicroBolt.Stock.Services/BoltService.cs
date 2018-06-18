using MicroBolt.Stock.Data;
using MicroBolt.Stock.Data.Contracts.Repositories;
using MicroBolt.Stock.Models;
using MicroBolt.Stock.Services.Contracts;
using System;

namespace MicroBolt.Stock.Services
{
    public class BoltService : IBoltService
    {
        private readonly IBoltRepository boltRepository;

        public BoltService(IBoltRepository boltRepository)
        {
            this.boltRepository = boltRepository;
        }

        public int Create(Bolt model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Bolt Get(int id)
        {
            this.storeContext.Bolts
            throw new NotImplementedException();
        }

        public void Update(Bolt model)
        {
            throw new NotImplementedException();
        }
    }
}
