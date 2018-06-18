using MicroBolt.Stock.Models;
using System;
using System.Threading.Tasks;

namespace MicroBolt.Stock.Services.Contracts
{
    public interface IBoltService
    {
        Task<T> Get<T>(string id);
        Task Create(BoltModel model);
        Task Update(BoltModel model);
        Task Delete(string id);
    }
}
