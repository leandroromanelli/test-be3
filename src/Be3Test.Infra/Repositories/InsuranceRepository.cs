using Be3Test.Domain.Entities;
using Be3Test.Domain.Repositories;
using Be3Test.Infra.Context;

namespace Be3Test.Infra.Repositories
{
    public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(Be3TestContext context) : base(context)
        {
        }

    }
}
