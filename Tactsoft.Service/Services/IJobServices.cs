using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Service.Services.Base;
using Tactsoft.Core.ViewModel;

namespace Tactsoft.Service.Services
{
    public interface IJobServices
    {
        IEnumerable<JobViewModel> GetJobByCategory();
        double NumberOfVacancies();
        double NumberOfJobs();
        double NumberOfCompanies();
        IEnumerable<HotJobsView> HotJobsViews();
    }
}
