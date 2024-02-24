using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GOP16APP.Dtos.Information1Dto
{
    public class EntityInformationDto:EntityDto<Guid>
    {
        public string EntityClassification { get; set; }

        public string EntityName { get; set; }

      
        public string HeadQuarterCity { get; set; }

        public string Sector { get; set; }

        public string Numberbranches { get; set; }
        
        public string Numberemployees { get; set; }

        public string Logos { get; set; }



    }
}
