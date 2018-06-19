using MicroBolt.Stock.Data.Contracts.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBolt.Stock.Data.Contracts.Repositories
{
    public class BoltRepository : IBoltRepository
    {
        private readonly IStoreContext context;

        public BoltRepository(IStoreContext context)
        {
            this.context = context;
        }

        public async Task<Bolt> Get(string id)
        {
            return await this.context.Bolts.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Bolt>> GetMany(int skip, int top)
        {
            return await this.context.Bolts
                .Find(new BsonDocument())
                .Skip(skip)
                .Limit(top)
                .ToListAsync();
        }

        public async Task Create(Bolt entity)
        {
            await this.context.Bolts.InsertOneAsync(entity);
        }

        public async Task Update(Bolt entity)
        {
            await this.context.Bolts.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(entity.Id)), entity);
        }
        public async Task Delete(string id)
        {
            await this.context.Bolts.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
