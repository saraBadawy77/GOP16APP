using AutoMapper;
using GOP16APP.Dtos;
using GOP16APP.Entities;
using GOP16APP.Errors;
using GOP16APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using static Volo.Abp.Identity.IdentityPermissions;

namespace GOP16APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventUserController : ControllerBase
    {
        private readonly IRepository<EventUser, Guid> _eventUserrepository;
        private readonly IMapper _mapper;
        public EventUserController(IRepository<EventUser, Guid> eventUserrepository, IMapper mapper)
        {
            _eventUserrepository = eventUserrepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventUser>>> GetAllEventUsers()
        {

            var Users = await _eventUserrepository.GetListAsync();
            var result = _mapper.Map<List<EventUserDto>>(Users);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventUser>> GetEventUser(Guid id)
        {
            var User = await _eventUserrepository.FindAsync(id);

            if (User == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }
                var result = _mapper.Map<EventUserDto>(User);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<EventUserModel>> CreateEventUser(EventUserModel input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var User = _mapper.Map<EventUser>(input);
            User = await _eventUserrepository.InsertAsync(User);
            var result = _mapper.Map<EventUserModel>(User);
           
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEventUser([FromQuery] EventUserDto input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var User = await _eventUserrepository.GetAsync(input.Id);
            if (User == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            _mapper.Map(input, User);

            var result = await _eventUserrepository.UpdateAsync(User);

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventUser(Guid id)
        {
            var category = await _eventUserrepository.FindAsync(id);
            if (category == null)
            {
                NotFound(new ApiErrorsResponse(404));
            }

            await _eventUserrepository.DeleteAsync(id);
            return NoContent();
        }



    }
}
