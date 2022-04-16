using Be3Test.Domain.Entities;
using Be3Test.Domain.Repositories;
using Be3Test.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Infra.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {

        private readonly Be3TestContext _context;
        public PatientRepository(Be3TestContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Patient> GetComplete(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Patients
                .Where(patient => patient.Id == id)
                .Include("InsuranceCards")
                .Include("InsuranceCards.Insurance")
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
