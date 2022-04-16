using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Specifications;
using System;
using System.Linq.Expressions;

namespace Be3Test.Domain.Specifications
{
    public class InsuranceCardSpecification : Specification<InsuranceCard>, IInsuranceCardSpecification
    {
        public InsuranceCardSpecification(Expression<Func<InsuranceCard, bool>> expression) : base(expression)
        {
        }

    }
}