using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.ViewModel;
using Tactsoft.Service.DbDependencies;

namespace Tactsoft.Service.Services
{
    public  class JobServices : IJobServices
    {
        private readonly AppDbContext _dbContext;
        public JobServices(AppDbContext context)
        {
            this._dbContext = context;
        }
        public IEnumerable GetJobCount()
        {
            List<JobViewModel> result = (from a in _dbContext.PostingJobs
                                         join b in _dbContext.JobCategories on a.JobCategoryeId equals b.Id

                                         select new
                                         {
                                             b.Id,
                                             b.JobCategoryeName
                                         }
                         ).GroupBy(x => new { x.Id, x.JobCategoryeName })
                   .Select(g => new JobViewModel() { Id = (int)g.Key.Id, JobCategoryeName = g.Key.JobCategoryeName, TotalJob = g.Count() }).ToList();

            //using var cmd = _dbContext.Database.GetDbConnection().CreateCommand();


            //List<JobViewModel> value = new List<JobViewModel>();

            //if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();

            //cmd.CommandText = "Select c.id ,c.JobCategoryeName, count (*) as total  from PostingJobs p inner join JobCategories c on p.JobCategoryeId=c.Id Group by c.id, c.JobCategoryeName";
            //SqlDataReader dr = (SqlDataReader)cmd.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    while (dr.Read())
            //    {
            //        JobViewModel aJobViewModel = new JobViewModel()
            //        {
            //            Id = 0,
            //            JobCategoryeName = dr["JobCategoryeName"].ToString(),
            //            TotalJob = (int)dr["total"]
            //        };
            //        value.Add(aJobViewModel);

            //    }
            //}

            return result;
         }
        } }