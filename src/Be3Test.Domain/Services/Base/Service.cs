using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Be3Test.Domain.Interfaces.Specifications;
using Be3Test.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Domain.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> Get(CancellationToken cancellationToken)
        {
            return await _repository.Get(cancellationToken);
        }

        public async Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.Get(id, cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var obj = await _repository.Get(id, cancellationToken);

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            await _repository.Delete(obj, cancellationToken);
        }

        public async Task Add(T obj, CancellationToken cancellationToken)
        {
            var dbObj = await _repository.Get(obj.Id, cancellationToken);

            if (dbObj != null)
                throw new ArgumentNullException(nameof(obj));

            await _repository.Add(obj, cancellationToken);
        }

        public async Task Update(T obj, Guid id, CancellationToken cancellationToken)
        {
            var dbObj = await _repository.Get(id, cancellationToken);

            if (dbObj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.Id = id;
            
            await _repository.Update(obj, cancellationToken);
        }

        public async Task<List<T>> FindMany(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            return await _repository.FindMany(specification, cancellationToken);
        }

        public async Task<T> Find(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            return await _repository.Find(specification, cancellationToken);
        }
    }
}
