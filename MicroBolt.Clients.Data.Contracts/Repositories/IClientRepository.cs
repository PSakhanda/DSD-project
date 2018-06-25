using MicroBolt.Clients.Data.Contracts.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBolt.Clients.Data.Contracts.Repositories
{
    public interface IClientRepository
    {
        Task<Client> Get(string id);
        Task<ICollection<Client>> GetMany();
        Task Create(Client entity);
        Task Update(Client entity);
        Task Delete(string id);
    }
}
