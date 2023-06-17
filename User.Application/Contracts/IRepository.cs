using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;

namespace User.Application.Contracts
{

    public interface IRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
