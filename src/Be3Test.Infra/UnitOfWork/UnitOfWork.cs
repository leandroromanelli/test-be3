using Be3Test.Domain.Interfaces.UnitOfWork;
using Be3Test.Domain.Repositories;
using Be3Test.Infra.Context;
using Be3Test.Infra.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IInsuranceRepository InsuranceRepository { get; private set; }
        public IInsuranceCardRepository InsuranceCardRepository { get; private set; }
        public IPatientRepository PatientRepository { get; private set; }

        private readonly Be3TestContext _context;

        public UnitOfWork(Be3TestContext context)
        {
            _context ??= context;

            InsuranceRepository ??= new InsuranceRepository(context);
            InsuranceCardRepository ??= new InsuranceCardRepository(context);
            PatientRepository ??= new PatientRepository(context);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task Save(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
