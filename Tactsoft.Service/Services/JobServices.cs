using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.ViewModel;
using Tactsoft.Service.DbDependencies;

namespace Tactsoft.Service.Services
{
    public class JobServices : IJobServices
    {
        private readonly AppDbContext _appDbContext;
        public JobServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<JobViewModel> GetJobByCategory()
        {
            var jobViewModel=(from a in _appDbContext.PostingJobs
                              join b in _appDbContext.JobCategories on a.JobCategoryeId equals b.Id
                              select new{b.Id,b.JobCategoryeName }
                              ).GroupBy(x => new  { x.Id, x.JobCategoryeName }).Select(g => new JobViewModel {Id= g.Key.Id, JobCategoryName=g.Key.JobCategoryeName, TotalJob=g.Count()}).ToList();

            return jobViewModel;
        }
    }
}
