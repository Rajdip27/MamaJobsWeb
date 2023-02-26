using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;
using Tactsoft.Core.DataType;

namespace Tactsoft.Core.Entities
{
    public class Employment:BaseEntity
    {
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Business")]
        public string CompanyBusiness { get; set; }
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [Display(Name = "Department")]
        public string Department { get; set; }

        [Display(Name ="Employment Period(From Date)")]
        
        
        public DateTime FromDate { get; set; }
        [Display(Name = "Employment Period (To Date)")]
       
        public DateTime ToDate { get; set; }
        [Display(Name = "Currently Working")]
        public Boolean CurrentlyWorking { get; set; }

        public string Responsibilites { get; set; }
        [Display(Name = "Area of Expertise")]
        public string AreaofExpertise { get; set; }
        [Display(Name = "Company Location")]
        public string CompanyLocation { get; set; }
        [Display(Name = "Skill")]
        public string Skill { get; set; }

        public Boolean Self { get; set; }

        public Boolean job { get; set; }
        public Boolean Educational { get; set; }
        public Boolean professionalTraining { get; set; }
        public Boolean NTVQF { get; set; }

        [Display(Name = "Skill Description")]
        public string SkillDescription { get; set; }
        [Display(Name = "Language")]
        public string Language { get; set; }
        [Display(Name = "Reading")]
        public long ReadingId { get; set; }
        public Reading Readings { get; set; }
        [Display(Name = "Writing")]
        public long WritingId { get; set; }
        public Writing Writings { get; set; }
        [Display(Name = "Speaking")]
        public long SpeakingId { get; set; }
        public Speaking Speakings { get; set; }


        public string Name { get;set; }
        [Display(Name = "Designation")]
        public string DesignationRef { get; set; }
        [Display(Name = "Organization")]
        public string Organization { get; set; }
        [Display(Name = "Organization")]
        public string Email { get; set; }
        [Display(Name = "Relative")]
        public long RelativeId { get; set; }

        public Relative Relatives { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Display(Name = "Phone(Off)")]
        public string PhoneOffice { get; set; }
        [Display(Name = "Phone(Res)")]
        public string PhoneRes{ get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Photos")]
        public string Photos { get; set; }
    }
}
