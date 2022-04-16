using Be3Test.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Be3Test.Domain.Interfaces.Specifications
{
    public interface ISpecification<T> where T : BaseEntity
    {
        Expression<Func<T, bool>> ToExpression();
        bool IsSatisfiedBy(T entity);
    }
}
