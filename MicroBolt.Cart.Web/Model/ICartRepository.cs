using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBolt.Cart.Web.Model
{
    public interface ICartRepository
    {
        Task<CustomerCart> GetCartAsync(string customerId);
        Task<CustomerCart> UpdateCartAsync(CustomerCart cart);
        Task<bool> DeleteCartAsync(string id);
    }
}
