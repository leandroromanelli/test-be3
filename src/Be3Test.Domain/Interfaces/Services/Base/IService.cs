using Be3Test.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Be3Test.Domain.Interfaces.Services
{
    public interface IService<T> where T : BaseEntity
    {
        List<T> List();
        T Find(Guid id);
        void Delete(Guid id);
        void Add(T obj);
        void Update(T obj, Guid id);
    }
}
