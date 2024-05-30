namespace Movie_Database_App.Repository
{
    public interface IMongoRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string id);
        Task<T> Create(T entity);
        Task Update(string id, T entity);
        Task Delete(string id);
    }
}
