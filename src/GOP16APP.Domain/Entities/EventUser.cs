using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GOP16APP.Entities
{
    public class EventUser : Entity<Guid>
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required]
        
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Position { get; set; }

        [Required]
        [MaxLength(100)]
        public string Qualification { get; set; }

        [Required]
        [MaxLength(100)]
        public string Residence { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nationality { get; set; }

        [Required]
        [MaxLength(100)]
        public string OrganizationName { get; set; }


        [Required]
        [MaxLength(100)]
        public string OrganizationCategory { get; set; }

    }
}
