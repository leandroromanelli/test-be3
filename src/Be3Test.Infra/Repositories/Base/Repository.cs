using Be3Test.Domain.Entities;
using Be3Test.Domain.Repositories;
using Be3Test.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Be3Test.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Be3TestContext _context;

        public Repository(Be3TestContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> Get()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T Get(Guid id)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
