using AutoMapper;
using Be3Test.Api.Models;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Web.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInsuranceService _service;

        public InsuranceController(IMapper mapper,
                                   IInsuranceService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<ActionResult> Create(CancellationToken cancellationToken)
        {
            return View(new InsuranceRequestModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(InsuranceRequestModel insuranceRequest, CancellationToken cancellationToken)
        {
            await _service.Add(_mapper.Map<Insurance>(insuranceRequest), cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            return View(_mapper.Map<IEnumerable<InsuranceResponseModel>>(await _service.Get(cancellationToken)));
        }

    }
}
