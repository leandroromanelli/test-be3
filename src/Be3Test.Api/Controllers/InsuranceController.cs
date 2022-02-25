using AutoMapper;
using Be3Test.Api.Controllers.Base;
using Be3Test.Api.Models;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;

namespace Be3Test.Api.Controllers
{
    public class InsuranceController : BaseController<Insurance, InsuranceRequestModel, InsuranceResponseModel>
    {
        public InsuranceController(IMapper mapper,
                                   IInsuranceService service) : base(mapper, service)
        {
        }
    }
}
