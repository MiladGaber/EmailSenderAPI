using EmailSender.Core.Interfaces;
using EmailSender.Infrastructure.Data;
using EmailSender.Infrastructure.Repositories;

namespace EmailSender.Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private IBaseRepository<T> _entity;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IBaseRepository<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new BaseRepository<T>(_context));
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
