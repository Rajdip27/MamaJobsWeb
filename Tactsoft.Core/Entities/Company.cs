using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Company:BaseEntity
    {
        [Display(Name = "Company Name English")]
        public string CompanyNameEnglishName { get; set; }
        [Display(Name = "কোম্পানি নাম বাংলা")]
        public string CompanyNameBanglaName { get; set; }

        
        public Boolean Yes { get; set; }
        
        public Boolean No { get; set; }
        [Display(Name = "Company Size")]
        public long CompanySizeId { get; set; }
        public CompanySize CompanySize { get; set; }
        [Display(Name = "Company Country")]
        public long CountryId { get; set; }
        public Country Country { get; set; }
        [Display(Name = "District")]
        public long DistrictId { get; set; }
        public District District { get; set; }
        [Display(Name = "Thana")]
        public long ThanaId { get; set; }
        public Thana Thana { get; set; }
        [Display(Name = "Company Address(Bn) ")]
        public string CompanyAddressBangla { get; set; }
        [Display(Name = "Company Address(En) ")]
        public string CompanyAddressEnglish { get; set; }
        [Display(Name = "Industrial Type ")]
        public long IndustialTypeId { get; set; }
        public IndustryType IndustialType { get; set; }
        [Display(Name = "Business Description")]
        public string BusinessDescription { get; set; }
        [Display(Name = " Business Trade Licience No")]
        public string BusinessTradeLicienceNo { get; set; }
        [Display(Name = "RL NO ")]
        public string RLNO { get; set; }
        [Display(Name = "Website URL ")]
        public string WebsiteUrl { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPersonName { get; set; }
        [Display(Name = "Contact Person Designation ")]
        public string ContactPersonDesignation { get; set; }
        [Display(Name = "Contact Person Email ")]
        public string ContactPersonEmail { get; set; }
        [Display(Name = "Contact Person Mobile ")]
        public string ContactPersonMobile { get; set; }
         
       
    }
}
