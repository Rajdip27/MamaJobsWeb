using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class OtherBenfitsService : BaseService<OtherBenfits>, IOtherBenfitsService
    {
        private readonly AppDbContext appDb;
        public OtherBenfitsService(AppDbContext context) : base(context)
        {
            appDb = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.BenfitName, Value = x.Id.ToString() });
        }
    }
}
