using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Be3Test.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Be3Test.Domain.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public List<T> List()
        {
            return _repository.Get().ToList();
        }

        public T Find(Guid id)
        {
            return _repository.Get().FirstOrDefault(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var obj = _repository.Get().FirstOrDefault(x => x.Id == id);

            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            _repository.Delete(obj);
        }

        public void Add(T obj)
        {
            var dbObj = _repository.Get().FirstOrDefault(x => x.Id == obj.Id);

            if (dbObj != null)
                throw new ArgumentNullException(nameof(obj));

            _repository.Add(obj);
        }

        public void Update(T obj, Guid id)
        {
            var dbObj = _repository.Get().FirstOrDefault(x => x.Id == id);

            if (dbObj == null)
                throw new ArgumentNullException(nameof(obj));

            obj.Id = id;
            
            _repository.Update(obj);
        }
    }
}
