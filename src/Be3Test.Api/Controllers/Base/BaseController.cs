using AutoMapper;
using Be3Test.Api.Models;
using Be3Test.Api.Models.Base;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Be3Test.Api.Controllers.Base
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/[Controller]")]
    public class BaseController<E, Req, Resp> : Controller where E : BaseEntity where Req : BaseRequestModel where Resp : BaseResponseModel
    {
        private readonly IService<E> _service;
        private readonly IMapper _mapper;

        public BaseController(IMapper mapper,
                              IService<E> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Resp>> Get()
        {
            try
            {
                return Ok(_mapper.Map<List<Resp>>(_service.List()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ??  ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public ActionResult<Resp> Get(Guid id)
        {
            try
            {
                return Ok(_mapper.Map<Resp>(_service.Find(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }


        [HttpPost]
        public ActionResult Add([FromBody] Req obj)
        {
            try
            {
                _service.Add(_mapper.Map<E>(obj));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public ActionResult Update([FromBody] Req obj, Guid id)
        {
            try
            {
                _service.Update(_mapper.Map<E>(obj), id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
