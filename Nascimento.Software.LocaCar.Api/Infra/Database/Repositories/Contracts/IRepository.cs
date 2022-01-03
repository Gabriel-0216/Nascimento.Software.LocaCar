namespace Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(string Id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Add(T entity);
        Task<bool> Remove(T entity);
        Task<bool> Update(T entity);
    }
}
