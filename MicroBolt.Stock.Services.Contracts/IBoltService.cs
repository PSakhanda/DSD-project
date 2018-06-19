using MicroBolt.Stock.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBolt.Stock.Services.Contracts
{
    public interface IBoltService
    {
        Task<T> Get<T>(string id);
        Task<ICollection<TResult>> GetMany<TResult>(int skip, int top);
        Task Create(BoltModel model);
        Task Update(BoltModel model);
        Task Delete(string id);
    }
}
