using AutoMapper;
using Be3Test.Api.Controllers.Base;
using Be3Test.Api.Models;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Be3Test.Api.Controllers
{
    public class PatientController : BaseController<Patient, PatientRequestModel, PatientResponseModel>
    {
        private readonly IPatientService _service;
        private readonly IMapper _mapper;

        public PatientController(IMapper mapper,
                                 IPatientService service) : base(mapper, service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPatch("{id:guid}")]
        public ActionResult Update(Guid id, [FromBody] PatientRequestModel patient)
        {
            try
            {
                _service.Update(_mapper.Map<Patient>(patient), id, patient.InsuranceCards.FirstOrDefault().InsuranceId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex?.InnerException.Message ?? ex.Message);
            }
        }
    }
}
