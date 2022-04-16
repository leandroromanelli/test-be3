using Be3Test.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Domain.Interfaces.Services
{
    public interface IPatientService : IService<Patient>
    {
        Task Update(Patient patient, Guid id, Guid? insuranceCardId, CancellationToken cancellationToken);
    }
}
