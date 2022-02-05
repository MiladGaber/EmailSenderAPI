using EmailSender.Core.Interfaces;
using EmailSender.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        private DbSet<T> table = null;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }


        public async Task<T> AddAsync(T entity)
        {
            await table.AddAsync(entity);
            return entity;
        }




        public void Attach(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }


        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

    }
}
