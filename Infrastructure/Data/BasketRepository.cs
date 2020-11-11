using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        // IDatabase for redis and creates a connection to redis in-memory database
        private readonly IDatabase _database;


        // Constructor injects IConnectionMultiplexer for Redis
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            // our json will be serialized into a string to store into redis  
            var data = await _database.StringGetAsync(basketId);


            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            // If we updating a basket, we replace the existing basket in redis database from client with the new basket


            // StringSetAsync sets key to hold a string value
            
            // We can set time which our items will live for in the redis
            // basket for our in memory database by giving a timespan

            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket),
                                TimeSpan.FromDays(30));

            if (!created) 
            {
                return null;
            }

            return await GetBasketAsync(basket.Id);
        }
    }
}
