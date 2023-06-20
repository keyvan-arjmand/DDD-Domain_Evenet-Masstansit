using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using User.Application.Contracts;
using User.Domain.Common;
using System.Threading;
using User.Application.Commn;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MassTransit.Configuration;
using MassTransit;
namespace User.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public IMongoCollection<T> Collection { get; }
        private readonly IMongoClient _mongoClient;
        public Repository(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
            var settings = MongoClientSettings.FromConnectionString(_configuration["MongoSettings:ConnectionString"]);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _mongoClient = new MongoClient(settings);
            Collection = _mongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"])
                .GetCollection<T>(typeof(T).Name + "s");

        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var documents = await Collection.FindAsync(_ => true, null);
            return await documents.ToListAsync();
        }

        public async Task<T> GetByIdAsync(ObjectId id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(MongodbConstance.MongodbId, id);
            var result = await Collection.FindAsync(filter, null).ConfigureAwait(false);
            if (result is null)
                return null;
            return result.FirstOrDefault();
        }

        public async Task AddAsync(T? aggregateRoot, InsertOneOptions? options = null)
        {
            if (aggregateRoot is null)
                throw new ArgumentException("aggregateRoot cannot be null or empty.", nameof(aggregateRoot));

            await _mediator.DispatchDomainEventsAsync(aggregateRoot);
            await Collection.InsertOneAsync(aggregateRoot, options);
        }

        public async Task<UpdateResult> UpdateAsync(Expression<Func<T, bool>> predicate, T aggregateRoot, Expression<Func<T, object>>[] properties, UpdateOptions? options = null)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate), "predicate cannot be null.");
            if ((object)aggregateRoot is null)
                throw new ArgumentNullException(nameof(aggregateRoot), "entity cannot be null.");
            if (properties is null || !((IEnumerable<Expression<Func<T, object>>>)properties).Any<Expression<Func<T, object>>>())
                throw new ArgumentException("properties cannot be null or empty.", nameof(properties));



            UpdateDefinition<T>? definition = (UpdateDefinition<T>)null;
            foreach (Expression<Func<T, object>> property in properties)
            {
                object obj = property.Compile()(aggregateRoot);
                definition = definition != null ? definition.Set<T, object>(property, obj) : Builders<T>.Update.Set<object>(property, obj);
            }

            await _mediator.DispatchDomainEventsAsync(aggregateRoot);

            return await Collection.UpdateOneAsync(predicate, definition, options);
        }
        public async Task<UpdateResult> UpdateOne(T entity)
        {
            var result = await GetByIdAsync(entity.Id);
            var filter = Builders<T>.Filter
                .Eq(x => x, result);

            var update = Builders<T>.Update
                .Set(x => x, entity);

            return await Collection.UpdateOneAsync(filter, update);
        }

        public async Task<DeleteResult> DeleteAsync(Expression<Func<T, bool>> predicate, T aggregateRoot, DeleteOptions? options = null)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate), "predicate cannot be null.");

            await _mediator.DispatchDomainEventsAsync(aggregateRoot);
            return await Collection.DeleteOneAsync(predicate, options);
        }

    }
}
