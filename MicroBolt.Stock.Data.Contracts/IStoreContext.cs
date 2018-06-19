using MicroBolt.Stock.Data.Contracts.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBolt.Stock.Data.Contracts
{
    public interface IStoreContext
    {
        IMongoCollection<Bolt> Bolts { get; }
    }
}
