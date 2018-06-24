using MicroBolt.Clients.Data.Contracts;
using MicroBolt.Clients.Data.Contracts.Entity;
using MicroBolt.Clients.Data.Contracts.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBolt.Clients.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IStoreContext context;

        public ClientRepository(IStoreContext context)
        {
            this.context = context;
        }

        public async Task<Client> Get(string id)
        {
            return await this.context.Clients.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Client>> GetMany()
        {
            return await this.context.Clients
                .Find(new BsonDocument())
                .ToListAsync();
        }

        public async Task Create(Client entity)
        {
            await this.context.Clients.InsertOneAsync(entity);
        }

        public async Task Update(Client entity)
        {
            await this.context.Clients.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(entity.Id)), entity);
        }
        public async Task Delete(string id)
        {
            await this.context.Clients.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
