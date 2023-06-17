using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;

namespace User.Infrastructure.Persistence
{
    public class DB : DbContext
    {
        private readonly IMediator _mediator;

        public DB(IMediator mediator)
        {
            _mediator = mediator;
        }
        public DB(DbContextOptions<DB> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=No6;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Domain.Entities.User> Users { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
