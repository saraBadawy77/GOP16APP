using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace GOP16APP.Dtos
{
    public class QualificationDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
