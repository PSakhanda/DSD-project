using MicroBolt.Stock.Data.Contracts.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBolt.Stock.Data.Contracts.Repositories
{
    public interface IBoltRepository
    {
        Task<Bolt> Get(string id);
        Task<ICollection<Bolt>> GetMany(int skip, int top);
        Task Create(Bolt entity);
        Task Update(Bolt entity);
        Task Delete(string id);
    }
}
