using DockerVolumesPersistency.Configuration;
using DockerVolumesPersistency.Interfaces;
using DockerVolumesPersistency.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DockerVolumesPersistency.Services
{
    public class CounterService : ICounterService
    {
        private readonly IMongoCollection<Counters> _collection;

        public CounterService(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            var db = client.GetDatabase(settings.Value.Database);
            _collection = db.GetCollection<Counters>(settings.Value.Collection);
        }

        public async Task<Counters> IncrementAsync(string counterId)
        {
            FilterDefinition<Counters> filter = Builders<Counters>.Filter.Eq(c => c.Id, counterId);

            Counters counter = await _collection.Find(filter).FirstOrDefaultAsync();

            if (counter == null)
            {
                counter = new Counters
                {
                    Id = counterId,
                    Count = 1
                };

                await _collection.InsertOneAsync(counter);
            }
            else
            {
                counter.Count++;
                await _collection.ReplaceOneAsync(filter, counter);
            }

            return counter;
        }

        public async Task<Counters?> GetAsync(string counterId)
        {
            var filter = Builders<Counters>.Filter.Eq(c => c.Id, counterId);
            var counter = await _collection.Find(filter).FirstOrDefaultAsync();

            if(counter == null)
                return new Counters { Id = counterId, Count = 0 };

            return counter;
        }

    }
}
