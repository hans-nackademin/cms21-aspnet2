namespace _00_ServiceLifetimes.Services
{
    public interface ICrud
    {
        Task<T> CreateAsync<T>();
        Task<IEnumerable<T>> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> UpdateAsync<T>(T model);
        Task DeleteAsync(int id);
    }
}
