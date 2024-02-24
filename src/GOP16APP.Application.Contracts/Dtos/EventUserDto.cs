using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GOP16APP.Dtos
{
    public class EventUserDto :EntityDto<Guid>
    {
    
        public string FullName { get; set; }
       
        public string Title { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
       
        public string Position { get; set; }
       
        public string Qualification { get; set; }
       
        public string Residence { get; set; }
        
        public string Nationality { get; set; }
       
        public string OrganizationName { get; set; }
      
        public string OrganizationCategory { get; set; }
    }
}
