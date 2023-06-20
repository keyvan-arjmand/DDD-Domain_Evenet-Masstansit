using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using User.Domain.Common;

namespace User.Application.Contracts
{

    public interface IRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(ObjectId id);
        Task AddAsync(T? aggregateRoot, InsertOneOptions? options = null);
        Task<UpdateResult> UpdateAsync(Expression<Func<T, bool>> predicate, T aggregateRoot, Expression<Func<T, object>>[] properties, UpdateOptions? options = null);
        Task<DeleteResult> DeleteAsync(Expression<Func<T, bool>> predicate, T aggregateRoot, DeleteOptions? options = null);
        Task<UpdateResult> UpdateOne(T entity);
    }
}
