using Be3Test.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Be3Test.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> Get();
        T Get(Guid id);
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
