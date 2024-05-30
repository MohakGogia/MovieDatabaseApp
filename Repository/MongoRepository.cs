using MongoDB.Driver;
using Movie_Database_App.Repository;

public class MongoRepository<T> : IMongoRepository<T>
{
    private readonly IMongoCollection<T> _collection;

    public MongoRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }

    public async Task<IEnumerable<T>> GetAll() => await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();

    public async Task<T> Get(string id) => await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();

    public async Task<T> Create(T entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task Update(string id, T entity) => await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), entity);

    public async Task Delete(string id) => await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
}
