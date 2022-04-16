using Be3Test.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Domain.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> GetComplete(Guid id, CancellationToken cancellationToken);
    }
}
