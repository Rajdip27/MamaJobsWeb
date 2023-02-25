﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Reading:BaseEntity
    {
        [Display(Name = "Reading")]
        public string ReadingName { get; set; }
        public IList<Employment> Employments { get; set; }
    }
}
