using AutoMapper;
using GOP16APP.Dtos.Information1Dto;
using GOP16APP.Entities.Information1;
using GOP16APP.Errors;
using GOP16APP.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace GOP16APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityInformationController : ControllerBase
    {
        private readonly IRepository<EntityInformation, Guid> _entityinformationrepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EntityInformationController(IRepository<EntityInformation, Guid> entityinformationrepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _entityinformationrepository = entityinformationrepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityInformationDto>>> GetAllEntitysInformation()
        {

            var entitys = await _entityinformationrepository.GetListAsync();
              var result = _mapper.Map<IEnumerable<EntityInformationDto>>(entitys);
            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<EntityInformation>> GetEntityInformation(Guid id)
        {
            var entity = await _entityinformationrepository.FindAsync(id);

            if (entity == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }
            var result = _mapper.Map<EntityInformationDto>(entity);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntityInformation(EntityInformationModel input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logos = UploadFiles(input.Logos);


            var serializedLogos = JsonSerializer.Serialize(input.Logos);

            var entity = _mapper.Map<EntityInformation>(input);


            entity.Logos = serializedLogos;
            entity = await _entityinformationrepository.InsertAsync(entity);


            return Ok();

        }
        

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityInformation(Guid id)
        {
            var entity = await _entityinformationrepository.FindAsync(id);
            if (entity == null)
            {
                return NotFound(new ApiErrorsResponse(404));
            }

            await _entityinformationrepository.DeleteAsync(id);
            return NoContent();
        }

       

        private List<string> UploadFiles(IEnumerable<IFormFile> files)
        {
            List<string> fileNames = new List<string>();
            foreach (var file in files)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UploadFiles");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                fileNames.Add(uniqueFileName);
            }

            return fileNames;
        }

       





    }
}
