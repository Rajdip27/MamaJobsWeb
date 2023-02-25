using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Relative:BaseEntity
    {
        public string RelativeName { get; set; }
        public IList<Employment> Employments { get; set; }
    }
}
