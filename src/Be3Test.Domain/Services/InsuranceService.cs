using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Be3Test.Domain.Interfaces.UnitOfWork;
using Be3Test.Domain.Repositories;

namespace Be3Test.Domain.Services
{
    public class InsuranceService : Service<Insurance>, IInsuranceService
    {
        public InsuranceService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.InsuranceRepository)
        {
        }
    }
}
