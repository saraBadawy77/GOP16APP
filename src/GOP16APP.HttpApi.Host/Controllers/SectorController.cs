using AutoMapper;
using GOP16APP.Dtos.Information1Dto;
using GOP16APP.Entities;
using GOP16APP.Entities.Information1;
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
    public class SectorController : ControllerBase
    {
        private readonly IRepository<Sector, Guid> _sectorrepository;
        private readonly IMapper _mapper;
        public SectorController(IRepository<Sector, Guid> sectorrepository, IMapper mapper)
        {
            _sectorrepository = sectorrepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> GetAllSectors()
        {

            var Sectors = await _sectorrepository.GetListAsync();
            var result = _mapper.Map<List<SectorDto>>(Sectors);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetSector(Guid id)
        {
            var Sector = await _sectorrepository.FindAsync(id);

            if (Sector == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            var result = _mapper.Map<SectorDto>(Sector);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<SectorDto>> CreateSector(SectorDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Sector = _mapper.Map<Sector>(input);
            Sector = await _sectorrepository.InsertAsync(Sector);
            var result = _mapper.Map<SectorDto>(Sector);
            return CreatedAtAction(nameof(GetSector), new { id = result.Id }, result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateSector(SectorDto input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var Sector = await _sectorrepository.GetAsync(input.Id);
            if (Sector == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            _mapper.Map(input, Sector);

            var result = await _sectorrepository.UpdateAsync(Sector);

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(Guid id)
        {
            var Sector = await _sectorrepository.FindAsync(id);
            if (Sector == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            await _sectorrepository.DeleteAsync(id);
            return NoContent();
        }










    }
}
