using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Tactsoft.Core.Entities
{
    public class District:BaseEntity
    {
        [Display(Name = "District Name")]
        [Required]
        public string DistrictName { get; set; }


        public long CountryId { get; set; }
        public Country Countrys { get; set; }

        public IList<Thana> Thanas { get; set; }

        ///public IList<Company> Companys { get; set; }
    }
}
