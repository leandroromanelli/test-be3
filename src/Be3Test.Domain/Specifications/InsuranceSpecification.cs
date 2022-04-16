using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Specifications;
using System;
using System.Linq.Expressions;

namespace Be3Test.Domain.Specifications
{
    public class InsuranceSpecification : Specification<Insurance>, IInsuranceSpecification
    {
        public InsuranceSpecification(Expression<Func<Insurance, bool>> expression) : base(expression)
        {
        }

    }
}