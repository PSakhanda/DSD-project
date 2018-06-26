using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBolt.Cart.Models
{
    public class RedisCartRepository : ICartRepository
    {
        private readonly ConnectionMultiplexer redisConnections;

        public RedisCartRepository()
        {
            var connectionString = "localhost,abortConnect=false";
            this.redisConnections = ConnectionMultiplexer.Connect(connectionString);
        }

        public async Task<bool> DeleteCartAsync(string id)
        {
            var db = this.redisConnections.GetDatabase();
            return await db.KeyDeleteAsync(id);
        }

        public async Task<CustomerCart> GetCartAsync(string customerId)
        {
            var db = this.redisConnections.GetDatabase();
            var data = await db.StringGetAsync(customerId);
            if (data.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<CustomerCart>(data);
        }

        public async Task<CustomerCart> UpdateCartAsync(CustomerCart cart)
        {
            var db = this.redisConnections.GetDatabase();
            var created = await db.StringSetAsync(cart.BuyerId, JsonConvert.SerializeObject(cart));
            if (!created)
            {
                return null;
            }
            return await GetCartAsync(cart.BuyerId);
        }
    }
}
