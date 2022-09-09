using src.Models;

namespace src.Data
{
    public interface IRepository 
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Computer[]> GetAllComputersAsync();
        Task<Computer[]> GetComputersAsyncById(int computerId);
        Task<Computer[]> GetComputersAsyncBySearch(string text);
    }
}