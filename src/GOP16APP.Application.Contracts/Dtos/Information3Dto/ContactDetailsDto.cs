using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GOP16APP.Dtos.Information3Dto
{
    public class ContactDetailsDto:EntityDto<Guid>
    {
        public string? LinkedIn { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string OfficialWebsite { get; set; }
        public string OfficialEmail { get; set; }
        public string FocalPointName { get; set; }
        public string FocalPointTitle { get; set; }
        public string FocalPointMobile { get; set; }
        public string FocalPointEmail { get; set; }
        public string? SpecificRequests { get; set; }
    }
}
