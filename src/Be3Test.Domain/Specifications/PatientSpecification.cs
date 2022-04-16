using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Specifications;
using System;
using System.Linq.Expressions;

namespace Be3Test.Domain.Specifications
{
    public class PatientSpecification : Specification<Patient>, IPatientSpecification
    {
        public PatientSpecification(Expression<Func<Patient, bool>> expression) : base(expression)
        {
        }

    }
}