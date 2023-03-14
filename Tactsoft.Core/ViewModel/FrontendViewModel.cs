using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tactsoft.Core.ViewModel
{
    public class FrontendViewModel
    {
        public IEnumerable<JobViewModel> JobViewModels { get; set; }
        public IEnumerable<HotJobsView>  HotJobsViews { get; set; }

        public double NumberOfVacancies { get; set; }
        public double NumberOfJobs { get; set; }
        public double NumberOfCompanies { get; set; }
    }
}
