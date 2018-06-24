using MicroBolt.Clients.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBolt.Clients.Services.Contracts
{
    public interface IClientService
    {
        Task<T> Get<T>(string id);
        Task<ICollection<TResult>> GetMany<TResult>();
        Task Create(ClientModel model);
        Task Update(ClientModel model);
        Task Delete(string id);
    }
}
