using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Domain.Entities;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Repository
{
    public class UserRepository : IRepository<Domain.Entities.User>
    {
        private readonly IMediator _mediator;
        private readonly IMongoCollection<Domain.Entities.User> _collection;
        private readonly Mongosettings _settings;
        private readonly DB _db;


        public UserRepository(IMediator mediator, IOptions<Mongosettings> settings, DB db)
        {
            _mediator = mediator;
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionURI);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Domain.Entities.User>(_settings.CollectionName);
            _db = db;
        }

        public async Task<Domain.Entities.User> AddAsync(Domain.Entities.User entity)
        {
            await _collection.InsertOneAsync(entity).ConfigureAwait(false);
            return entity;
        }

        public Task DeleteAsync(Domain.Entities.User entity)
        {
            return _collection.DeleteOneAsync(c => c.Id == entity.Id);
        }

        public async Task<IReadOnlyList<Domain.Entities.User>> GetAllAsync()
        {
            return await _collection.Find(c => true).ToListAsync();
        }

        public Task<Domain.Entities.User> GetByIdAsync(int id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(_db);
            await _db.SaveChangesAsync();
        }

        public Task UpdateAsync(Domain.Entities.User entity)
        {
            return _collection.ReplaceOneAsync(c => c.Id == entity.Id, entity);
        }

    }
}
