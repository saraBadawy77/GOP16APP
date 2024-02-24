using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GOP16APP.Entities
{
    public class OrganizationCategory : Entity<Guid>
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
