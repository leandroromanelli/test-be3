using AutoMapper;
using Be3Test.Api.Models;
using Be3Test.Api.Models.Base;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task<ActionResult<List<Resp>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(_mapper.Map<List<Resp>>(await _service.Get(cancellationToken)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ??  ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Resp>> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(_mapper.Map<Resp>(await _service.Get(id, cancellationToken)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Req obj, CancellationToken cancellationToken)
        {
            try
            {
                await _service.Add(_mapper.Map<E>(obj), cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _service.Delete(id, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update([FromBody] Req obj, Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _service.Update(_mapper.Map<E>(obj), id, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
