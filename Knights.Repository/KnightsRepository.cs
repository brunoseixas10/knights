using Knights.Model;
using Knights.Model.Extensions;
using Knights.Model.ViewModels;
using Knights.Service.Interfaces;
using MongoDB.Driver;

namespace Knights.Service
{
    public sealed class KnightsRepository : IKnightsRepository
    {
        private readonly IMongoCollection<Knight> _knightCollection;

        public KnightsRepository(IMongoDatabase mongo)
        {
            _knightCollection = mongo.GetCollection<Knight>("Knights");
        }

        public async Task<string> Add(Knight knight)
        {
            knight.id = Guid.NewGuid().ToString();
            await _knightCollection.InsertOneAsync(knight);
            return knight.id;
        }

        public async Task<Knight> GetById(string id)
        {
            return await _knightCollection.Find(x=>x.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<KnightViewModel>> List(bool onlyHeroes)
        {
            var knights = new List<Knight>();
            if (onlyHeroes) 
            {
                knights = await _knightCollection.Find(x => x.isHero).ToListAsync();
            }
            else
            {
                knights = await _knightCollection.Find(_ => true).ToListAsync();
            }

            if (knights.Any()) { 
                return knights.Select(KnightExtensions.ToKnightViewModel).ToList();
            }

            return [];
        }

        public async Task Remove(string id)
        {
            await _knightCollection.UpdateOneAsync(x => x.id == id, Builders<Knight>.Update.Set(y => y.isHero, true));
        }

        public async Task UpdateNickname(string id, string nickname)
        {
            await _knightCollection.UpdateOneAsync(x => x.id == id, Builders<Knight>.Update.Set(y => y.nickname, nickname));
        }
    }
}
