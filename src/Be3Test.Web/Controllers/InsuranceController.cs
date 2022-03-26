using AutoMapper;
using Be3Test.Api.Models;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public ActionResult Create()
        {
            return View(new InsuranceRequestModel());
        }

        [HttpPost]
        public ActionResult Create(InsuranceRequestModel insuranceRequest)
        {
            _service.Add(_mapper.Map<Insurance>(insuranceRequest));

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<InsuranceResponseModel>>(_service.List()));
        }

    }
}
