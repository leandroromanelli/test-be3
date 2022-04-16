using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Specifications;
using Be3Test.Domain.Repositories;
using Be3Test.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Be3TestContext _context;

        public Repository(Be3TestContext context)
        {
            _context = context;
        }

        public async Task Add(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<T>> FindMany(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().Where(specification.ToExpression()).ToListAsync(cancellationToken);
        }

        public async Task<List<T>> Get(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<T> Find(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(specification.ToExpression(), cancellationToken);
        }

        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
