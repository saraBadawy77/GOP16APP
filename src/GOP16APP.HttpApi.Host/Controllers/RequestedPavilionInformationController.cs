using AutoMapper;
using GOP16APP.Dtos.Information2Dto;
using GOP16APP.Entities.Information1;
using GOP16APP.Entities.Information2;
using GOP16APP.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GOP16APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestedPavilionInformationController : ControllerBase
    {
        private readonly IRepository<RequestedPavilion, Guid> _requestedPavilionrepository;
        private readonly IMapper _mapper;
        public RequestedPavilionInformationController(IRepository<RequestedPavilion, Guid> requestedPavilionrepository, IMapper mapper)
        {
            _requestedPavilionrepository = requestedPavilionrepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestedPavilion>>> GetAllRequestedPavilions()
        {

            var Requestes = await _requestedPavilionrepository.GetListAsync();
            var result = _mapper.Map<List<RequestedPavilionDto>>(Requestes);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RequestedPavilion>> GetRequestedPavilions(Guid id)
        {
            var Request = await _requestedPavilionrepository.FindAsync(id);

            if (Request == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            var result = _mapper.Map<RequestedPavilionDto>(Request);
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<RequestedPavilionDto>> CreateRequestedPavilion(RequestedPavilionDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Request = _mapper.Map<RequestedPavilion>(input);
            Request = await _requestedPavilionrepository.InsertAsync(Request);
            var result = _mapper.Map<RequestedPavilionDto>(Request);
            return CreatedAtAction(nameof(GetRequestedPavilions), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRequestedPavilion(RequestedPavilionDto input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var Request = await _requestedPavilionrepository.GetAsync(input.Id);
            if (Request == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            _mapper.Map(input, Request);

            var result = await _requestedPavilionrepository.UpdateAsync(Request);

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestedPavilion(Guid id)
        {
            var Request = await _requestedPavilionrepository.FindAsync(id);
            if (Request == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            await _requestedPavilionrepository.DeleteAsync(id);
            return NoContent();
        }



    }
}
