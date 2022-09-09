using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<Computer[]> GetAllComputersAsync()
        {
            IQueryable<Computer> query = _context.Computers;

            query = query.AsNoTracking()
            .OrderBy(pc => pc.Id);
                

            return await query.ToArrayAsync();
        }

        public async Task<Computer[]> GetComputersAsyncById(int computerId)
        {
            IQueryable<Computer> query = _context.Computers;

            query = query.AsNoTracking()
                .OrderBy(pc => pc.Id)
                .Where(pc => pc.Id == computerId);

            return await query.ToArrayAsync();
        }

        public async Task<Computer[]> GetComputersAsyncBySearch(string text)
        {
            IQueryable<Computer> query = _context.Computers;
            
            query = query.AsNoTracking()
            .OrderBy(pc => pc.Id)
            .Where(pc => pc.Modelo.Contains(text) || pc.Marca.Contains(text));            

            return await query.ToArrayAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}