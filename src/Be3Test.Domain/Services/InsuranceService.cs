using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Be3Test.Domain.Repositories;

namespace Be3Test.Domain.Services
{
    public class InsuranceService : Service<Insurance>, IInsuranceService
    {
        public InsuranceService(IInsuranceRepository repository) : base(repository)
        {
        }
    }
}
