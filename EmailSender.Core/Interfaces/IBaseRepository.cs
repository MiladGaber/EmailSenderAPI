using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);


        Task<T> AddAsync(T entity);
        void Attach(T entity);

        void Delete(object id);

    }
}
