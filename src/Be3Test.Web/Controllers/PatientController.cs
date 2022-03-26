using AutoMapper;
using Be3Test.Api.Models;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Be3Test.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Be3Test.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;
        private readonly IMapper _mapper;

        public PatientController(IMapper mapper,
                                 IPatientService service,
                                 Be3TestContext context)
        {
            _mapper = mapper;
            _service = service;


            //if (context.Patients.Any())
            //    return;

            //var insurance = new Insurance()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Test",
            //    Description = "Test"
            //};

            //var patient = new Patient()
            //{
            //    Id = Guid.NewGuid(),
            //    BirthDate = new DateTime(1988, 6, 22),
            //    CellPhone = "11 96642-3232",
            //    CPF = "358.806.018-97",
            //    Email = "romanellileandro@gmail.com",
            //    FirstName = "Leandro",
            //    LastName = "Romanelli",
            //    Genre = "Masculino",
            //    MedicalRecord = "ABC123456",
            //    RG = "42.459.422-5",
            //    UfRG = "SP"
            //};

            //var insuranceCard = new InsuranceCard()
            //{
            //    Id = Guid.NewGuid(),
            //    Number = "123456",
            //    Validity = DateTime.Now.AddDays(1500),
            //    InsuranceId = insurance.Id,
            //    IsActive = true,
            //    PatientId = patient.Id
            //};


            //context.Patients.Add(patient);
            //context.Insurances.Add(insurance);
            //context.InsuranceCards.Add(insuranceCard);

            //context.SaveChanges();
        }

        public ActionResult Index()
        {
            var result = _mapper.Map<IEnumerable<PatientResponseModel>>(_service.List());
            return View(result);
        }

        public ActionResult Details(Guid id)
        {
            var result = _mapper.Map<PatientResponseModel>(_service.Find(id));
            return View(result);
        }

        public ActionResult Create()
        {
            return View(new PatientRequestModel());
        }

        [HttpPost]
        public ActionResult Create(PatientRequestModel req)
        {
            _service.Add(_mapper.Map<Patient>(req));

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(Guid id)
        {
            return View(_mapper.Map<PatientRequestModel>(_service.Find(id)));
        }

        [HttpPost]
        public ActionResult Edit(Guid id, PatientRequestModel req)
        {
            _service.Update(_mapper.Map<Patient>(req), id);

            return RedirectToAction(nameof(Index));
        }
    }
}
