using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Specifications;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> Get(CancellationToken cancellationToken);
        Task<T> Get(Guid id, CancellationToken cancellationToken);
        Task<List<T>> FindMany(ISpecification<T> specification, CancellationToken cancellationToken);
        Task<T> Find(ISpecification<T> specification, CancellationToken cancellationToken);
        Task Add(T obj, CancellationToken cancellationToken);
        Task Update(T obj, CancellationToken cancellationToken);
        Task Delete(T obj, CancellationToken cancellationToken);
    }
}
