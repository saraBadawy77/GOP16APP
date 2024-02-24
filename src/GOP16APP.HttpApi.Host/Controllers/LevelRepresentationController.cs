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
    public class LevelRepresentationController : ControllerBase
    {
        private readonly IRepository<Level, Guid> _levelrepository;
        private readonly IMapper _mapper;
        public LevelRepresentationController(IRepository<Level, Guid> levelrepository, IMapper mapper)
        {
            _levelrepository = levelrepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Level>>> GetAllLevel()
        {

            var Levels = await _levelrepository.GetListAsync();
            var result = _mapper.Map<List<LevelDto>>(Levels);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Level>> GetLevel(Guid id)
        {
            var Level = await _levelrepository.FindAsync(id);

            if (Level == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            var result = _mapper.Map<LevelDto>(Level);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<LevelDto>> CreateLevel(LevelDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Level = _mapper.Map<Level>(input);
            Level = await _levelrepository.InsertAsync(Level);
            var result = _mapper.Map<LevelDto>(Level);
            return CreatedAtAction(nameof(GetLevel), new { id = result.Id }, result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateLeve(LevelDto input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var Leve = await _levelrepository.GetAsync(input.Id);
            if (Leve == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            _mapper.Map(input, Leve);

            var result = await _levelrepository.UpdateAsync(Leve);

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeve(Guid id)
        {
            var Leve = await _levelrepository.FindAsync(id);
            if (Leve == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            await _levelrepository.DeleteAsync(id);
            return NoContent();
        }






    }
}
