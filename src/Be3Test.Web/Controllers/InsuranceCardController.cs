using AutoMapper;
using Be3Test.Api.Models;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        public ActionResult Create([FromQuery(Name = "patientId")]Guid patientId)
        {
            ViewBag.Insurances = _mapper.Map<IEnumerable<InsuranceRequestModel>>(_insuranceService.List());
            
            return View(new InsuranceCardRequestModel() { PatientId = patientId });
        }

        [HttpPost]
        public ActionResult Create(InsuranceCardRequestModel insuranceCardRequest)
        {
            _service.Add(_mapper.Map<InsuranceCard>(insuranceCardRequest));

            return RedirectToRoute(new {controller = "Patient", action = "Edit", id = insuranceCardRequest.PatientId });
        }
    }
}
