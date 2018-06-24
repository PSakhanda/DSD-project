using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBolt.Cart.Web.Model
{
    public interface ICartRepository
    {
        Task<CustomerCart> GetCartAsync(string customerId);
        IEnumerable<string> GetUsers();
        Task<CustomerCart> UpdateCartAsync(CustomerCart cart);
        Task<bool> DeleteCartAsync(string id);
    }
}
