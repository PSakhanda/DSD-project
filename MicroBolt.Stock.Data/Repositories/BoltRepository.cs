using MicroBolt.Stock.Data.Contracts.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
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
        public async Task CreateBolt(Bolt entity)
        {
            await this.context.Bolts.InsertOneAsync(entity);
        }

        public async Task DeleteBolt(string id)
        {
            await this.context.Bolts.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }

        public async Task<Bolt> GetBolt(string id)
        {
            return await this.context.Bolts.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task UpdateBolt(Bolt entity)
        {
            await this.context.Bolts.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(entity.Id)), entity);
        }
    }
}
