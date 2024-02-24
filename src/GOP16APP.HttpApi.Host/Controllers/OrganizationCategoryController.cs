using AutoMapper;
using AutoMapper.Internal.Mappers;
using GOP16APP.Dtos;
using GOP16APP.Entities;
using GOP16APP.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace GOP16APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationCategoryController : ControllerBase
    {
        private readonly IRepository<OrganizationCategory, Guid> _categoryrepository;
        private readonly IMapper _mapper;
        public OrganizationCategoryController(IRepository<OrganizationCategory, Guid> categoryrepository, IMapper mapper)
        {
            _categoryrepository = categoryrepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationCategory>>> GetAllCategorys()
        {

            var Categorys = await _categoryrepository.GetListAsync();
            var result = _mapper.Map<List<OrganizationCategoryDto>>(Categorys);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationCategory>> GetCategory(Guid id)
        {
            var Category = await _categoryrepository.FindAsync(id);

            if (Category == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            var result = _mapper.Map<OrganizationCategoryDto>(Category);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OrganizationCategoryDto>> CreateCategory(OrganizationCategoryDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = _mapper.Map<OrganizationCategory>(input);
            category = await _categoryrepository.InsertAsync(category);
            var result = _mapper.Map<OrganizationCategoryDto>(category);
            return CreatedAtAction(nameof(GetCategory), new { id = result.Id }, result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategory(OrganizationCategoryDto input)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryrepository.GetAsync(input.Id);
            if (category == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            _mapper.Map(input, category); 

            var result = await _categoryrepository.UpdateAsync(category);

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _categoryrepository.FindAsync(id);
            if (category == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            await _categoryrepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
