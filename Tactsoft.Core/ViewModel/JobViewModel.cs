using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Core.ViewModel
{
    public class JobViewModel:MasterEntity
    {
        public string JobCategoryName { get; set; }
        public int TotalJob { get; set; }
    }
}
