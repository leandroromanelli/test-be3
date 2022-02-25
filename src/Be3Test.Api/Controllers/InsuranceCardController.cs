using AutoMapper;
using Be3Test.Api.Controllers.Base;
using Be3Test.Api.Models;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;

namespace Be3Test.Api.Controllers
{
    public class InsuranceCardController : BaseController<InsuranceCard, InsuranceCardRequestModel, InsuranceCardResponseModel>
    {
        public InsuranceCardController(IMapper mapper,
                                       IInsuranceCardService service) : base(mapper, service)
        {
        }
    }
}
