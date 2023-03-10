using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.Entities.ViewModel
{
    public class JobViewModel: MasterEntity
    {
        public string JobCategoryeName { get; set; }
        public int Id { get; set; }
        public int TotalJob { get; set; }

    }
}
