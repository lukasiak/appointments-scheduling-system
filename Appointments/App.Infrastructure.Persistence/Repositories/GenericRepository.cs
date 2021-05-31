using App.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public AppointmentContext _context = null;
        public DbSet<T> _table = null;

        public GenericRepository(AppointmentContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task InsertAsync(T obj)
        {
            await _table.AddAsync(obj);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            T existing = await _table.FindAsync(id);
            _table.Remove(existing);
        }
    }
}
