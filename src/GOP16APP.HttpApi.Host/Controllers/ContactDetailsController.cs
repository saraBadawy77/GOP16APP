using AutoMapper;
using GOP16APP.Dtos.Information3Dto;
using GOP16APP.Entities.Information1;
using GOP16APP.Entities.Information3;
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
    public class ContactDetailsController : ControllerBase
    {
        private readonly IRepository<ContactDetails, Guid> _contactDetailsrepository;
        private readonly IMapper _mapper;
        public ContactDetailsController(IRepository<ContactDetails, Guid> contactDetailsrepository, IMapper mapper)
        {
            _contactDetailsrepository = contactDetailsrepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDetails>>> GetAllContactDetails()
        {

            var Details = await _contactDetailsrepository.GetListAsync();
            var result = _mapper.Map<List<ContactDetailsDto>>(Details);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDetails>> GetContactDetail(Guid id)
        {
            var Detail = await _contactDetailsrepository.FindAsync(id);

            if (Detail == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            var result = _mapper.Map<ContactDetailsDto>(Detail);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ContactDetailsDto>> CreateContactDetails(ContactDetailsDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Detail = _mapper.Map<ContactDetails>(input);
            Detail = await _contactDetailsrepository.InsertAsync(Detail);
            var result = _mapper.Map<ContactDetailsDto>(Detail);
            return CreatedAtAction(nameof(GetContactDetail), new { id = result.Id }, result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateContactDetails(ContactDetailsDto input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var Detail = await _contactDetailsrepository.GetAsync(input.Id);
            if (Detail == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            _mapper.Map(input, Detail);

            var result = await _contactDetailsrepository.UpdateAsync(Detail);

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(Guid id)
        {
            var Detail = await _contactDetailsrepository.FindAsync(id);
            if (Detail == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            await _contactDetailsrepository.DeleteAsync(id);
            return NoContent();
        }



    }
}
