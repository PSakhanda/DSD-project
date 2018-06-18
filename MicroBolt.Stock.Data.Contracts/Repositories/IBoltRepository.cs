using MicroBolt.Stock.Data.Contracts.Entity;
using System.Threading.Tasks;

namespace MicroBolt.Stock.Data.Contracts.Repositories
{
    public interface IBoltRepository
    {
        Task<Bolt> GetBolt(string id);
        Task CreateBolt(Bolt entity);
        Task UpdateBolt(Bolt entity);
        Task DeleteBolt(string id);
    }
}
