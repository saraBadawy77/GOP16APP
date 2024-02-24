using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GOP16APP.Dtos.Information2Dto
{
    public class RequestedPavilionDto:EntityDto<Guid>
    {
        public bool IsVisitorSpace { get; set; }
        public string Area { get; set; }
        public string? BriefPavilion { get; set; }
        public bool IsSigning { get; set; }
        public bool IsPrizes { get; set; }
        public string CEOName { get; set; }
        public string NumberStandingPavilion { get; set; }
        public string LevelRepresentation { get; set; }
    }
}
