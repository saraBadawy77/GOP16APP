using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GOP16APP.Entities.Information2
{
    public class RequestedPavilion:Entity<Guid>
    {
        [Required]
        public bool IsVisitorSpace { get; set; }


        [Required]
        [MaxLength(100)]
        public string Area { get; set; }


        public string? BriefPavilion { get; set; }


        [Required]
        public bool IsSigning { get; set; }

        [Required]
        public bool IsPrizes { get; set; }

        [Required]
        [MaxLength(100)]
        public string CEOName { get; set; }

        [Required]
        [MaxLength(100)]
        public string NumberStandingPavilion { get; set; }

        [Required]
        [MaxLength(100)]
        public string LevelRepresentation { get; set; }
       

    }
}
