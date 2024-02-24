
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GOP16APP.Entities.Information1
{
    public class EntityInformation:Entity<Guid>
    {
        [MaxLength(100)]
        public string EntityClassification { get; set; }

        [MaxLength(100)]
        public string EntityName { get; set; }

        [MaxLength(100)]
        public string HeadQuarterCity { get; set; }

        [MaxLength(100)]
        public string Sector { get; set; }

        [MaxLength(100)]
        public string Numberbranches { get; set; }
        [MaxLength(100)]
        public string Numberemployees { get; set; }

        [Required]
        public string Logos { get; set; }

    }
}
