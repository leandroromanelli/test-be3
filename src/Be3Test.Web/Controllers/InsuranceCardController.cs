using AutoMapper;
using Be3Test.Api.Models;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Web.Controllers
{
    public class InsuranceCardController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IInsuranceCardService _service;
        private readonly IInsuranceService _insuranceService;
        private readonly IPatientService _patientService;

        public InsuranceCardController(IMapper mapper,
                                       IInsuranceCardService service,
                                       IInsuranceService insuranceService,
                                       IPatientService patientService)
        {
            _mapper = mapper;
            _service = service;
            _insuranceService = insuranceService;
            _patientService = patientService;
        }

        public async Task<ActionResult> Create([FromQuery(Name = "patientId")]Guid patientId, CancellationToken cancellationToken)
        {
            ViewBag.Insurances = _mapper.Map<IEnumerable<InsuranceRequestModel>>(await _insuranceService.Get(cancellationToken));
            
            return View(new InsuranceCardRequestModel() { PatientId = patientId });
        }

        [HttpPost]
        public async Task<ActionResult> Create(InsuranceCardRequestModel insuranceCardRequest, CancellationToken cancellationToken)
        {
            await _service.Add(_mapper.Map<InsuranceCard>(insuranceCardRequest), cancellationToken);

            return RedirectToRoute(new {controller = "Patient", action = "Edit", id = insuranceCardRequest.PatientId });
        }
    }
}
