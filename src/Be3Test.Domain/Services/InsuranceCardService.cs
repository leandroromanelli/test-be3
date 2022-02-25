using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Be3Test.Domain.Repositories;

namespace Be3Test.Domain.Services
{
    public class InsuranceCardService : Service<InsuranceCard>, IInsuranceCardService
    {
        public InsuranceCardService(IInsuranceCardRepository repository) : base(repository)
        {
        }
    }
}
