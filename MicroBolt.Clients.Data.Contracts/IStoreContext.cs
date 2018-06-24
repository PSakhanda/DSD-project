using MicroBolt.Clients.Data.Contracts.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBolt.Clients.Data.Contracts
{
    public interface IStoreContext
    {
        IMongoCollection<Client> Clients { get; }
    }
}
