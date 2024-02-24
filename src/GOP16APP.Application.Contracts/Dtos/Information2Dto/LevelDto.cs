using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GOP16APP.Dtos.Information2Dto
{
    public class LevelDto:EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
