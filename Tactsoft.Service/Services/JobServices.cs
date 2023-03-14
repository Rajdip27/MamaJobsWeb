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

        public IEnumerable<HotJobsView> HotJobsViews()
        {
            var data = (from a in _appDbContext.PostingJobs select new { a.Id, a.CompanyLogo, a.CompanyName, a.JobTittle }).Select(c => new HotJobsView { Id = c.Id, CompanyName = c.CompanyName, ComapnyLogo = c.CompanyLogo, Jobtitle = c.JobTittle }).ToList();
            return data;
        }

        public double NumberOfCompanies()
        {
           return _appDbContext.Companies.ToList().Count();
        }

        public double NumberOfJobs()
        {
            return _appDbContext.PostingJobs.ToList().Count();
        }

        public double NumberOfVacancies()
        {
            return _appDbContext.PostingJobs.Sum(x => x.Vacancy);
        }
    }
}
