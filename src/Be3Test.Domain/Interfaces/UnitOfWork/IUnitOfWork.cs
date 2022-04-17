using Be3Test.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IInsuranceRepository InsuranceRepository { get; }
        IInsuranceCardRepository InsuranceCardRepository { get; }
        IPatientRepository PatientRepository { get; }
        Task Save(CancellationToken cancellationToken);

    }
}
