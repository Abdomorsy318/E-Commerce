using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities.Basket;
using StackExchange.Redis;

namespace Presistance.Reposatories
{
    public class BasketReposatory(IConnectionMultiplexer connectionMultiplexer) : IBasketReposatory
    {
        private readonly IDatabase _database = connectionMultiplexer.GetDatabase();
        public async Task<bool> DeleteBasketAsync(string id)
        => await _database.KeyDeleteAsync(id);

        public async Task<CustomerBasket?> GetBasketAsync(string id)
        {
            var value = await _database.StringGetAsync(id);
            if (string.IsNullOrEmpty(value))
                return null;
            return JsonSerializer.Deserialize<CustomerBasket>(value);
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket, TimeSpan? timeSpan = null)
        {
            var jsonBasket = JsonSerializer.Serialize(basket);
            var isCreatedOrUpdate = await _database.StringSetAsync(basket.Id, jsonBasket, timeSpan ?? TimeSpan.FromDays(30));
            return isCreatedOrUpdate ? await GetBasketAsync(basket.Id) : null;
        }
    }
}
