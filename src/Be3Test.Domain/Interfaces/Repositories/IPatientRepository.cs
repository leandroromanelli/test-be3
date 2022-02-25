using Be3Test.Domain.Entities;
using System;

namespace Be3Test.Domain.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient GetComplete(Guid id);
    }
}
