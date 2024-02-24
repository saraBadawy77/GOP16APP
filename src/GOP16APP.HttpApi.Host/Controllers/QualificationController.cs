using AutoMapper;
using GOP16APP.Dtos;
using GOP16APP.Entities;
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
    public class QualificationController : ControllerBase
    {
        private readonly IRepository<Qualification, Guid> _qualificationrepository;
        private readonly IMapper _mapper;
        public QualificationController(IRepository<Qualification, Guid> qualificationrepository, IMapper mapper)
        {
            _qualificationrepository = qualificationrepository;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qualification>>> GetAllQualifications()
        {

            var Qualifications = await _qualificationrepository.GetListAsync();
            var result = _mapper.Map<List<QualificationDto>>(Qualifications);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Qualification>> GetQualification(Guid id)
        {
            var Qualification = await _qualificationrepository.FindAsync(id);

            if (Qualification == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            var result = _mapper.Map<QualificationDto>(Qualification);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<QualificationDto>> CreateQualification(QualificationDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Qualification = _mapper.Map<Qualification>(input);
            Qualification = await _qualificationrepository.InsertAsync(Qualification);
            var result = _mapper.Map<QualificationDto>(Qualification);
            return CreatedAtAction(nameof(GetQualification), new { id = result.Id }, result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateQualification( QualificationDto input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var qualification = await _qualificationrepository.GetAsync(input.Id);
            if (qualification == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            _mapper.Map(input, qualification);

            var result = await _qualificationrepository.UpdateAsync(qualification);

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQualification(Guid id)
        {
            var qualification = await _qualificationrepository.FindAsync(id);
            if (qualification == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            await _qualificationrepository.DeleteAsync(id);
            return NoContent();
        }


    }
}
