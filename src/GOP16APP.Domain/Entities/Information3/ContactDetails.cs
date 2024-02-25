using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GOP16APP.Entities.Information3
{
    public class ContactDetails:Entity<Guid>
    {
        [MaxLength(100)]
        public string? LinkedIn { get; set; }
        [MaxLength(100)]
        public string? Twitter { get; set; }
        [MaxLength(100)]
        public string? Facebook { get; set; }
        [MaxLength(100)]
        public string? Instagram { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address")]
        [MaxLength(100, ErrorMessage = "Email must be less than 100 characters.")]
        public string OfficialEmail { get; set; }

        [Required(ErrorMessage = "Please enter a website URL.")]
        [Url(ErrorMessage = "Please enter a valid website URL.")]
        [MaxLength(300, ErrorMessage = "Official website must be less than 100 characters.")]
        public string OfficialWebsite { get; set; }
        [Required]
        [MaxLength(100)]
        public string FocalPointName { get; set; }
        [Required]
        [MaxLength(100)]
        public string FocalPointTitle { get; set; }
        [Required]
        [MaxLength(100)]
        public string FocalPointMobile { get; set; }
        [Required]
        [MaxLength(100)]
        public string FocalPointEmail { get; set; }

        [MaxLength(500)]
        public string? SpecificRequests { get; set; }

    }
}
