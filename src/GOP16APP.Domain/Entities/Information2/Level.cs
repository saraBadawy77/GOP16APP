using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;


namespace GOP16APP.Entities.Information2
{
    public class Level:Entity<Guid>
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
