using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GOP16APP.Models
{
    public class EntityInformationModel
    {
        public string EntityClassification { get; set; }

        public string EntityName { get; set; }


        public string HeadQuarterCity { get; set; }

        public string Sector { get; set; }

        public string Numberbranches { get; set; }

        public string Numberemployees { get; set; }

        public List<IFormFile> Logos { get; set; }
    }
}
