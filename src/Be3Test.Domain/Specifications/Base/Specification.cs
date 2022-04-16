using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Specifications;
using System;
using System.Linq.Expressions;

namespace Be3Test.Domain.Specifications
{
    public class Specification<T> : ISpecification<T> where T : BaseEntity
    {
        protected readonly Expression<Func<T, bool>> _expression;
        
        public Specification(Expression<Func<T, bool>> expression)
        {
            _expression = expression;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return _expression.Compile().Invoke(entity);
        }

        public Expression<Func<T, bool>> ToExpression()
        {
            return _expression;
        }
    }
}
