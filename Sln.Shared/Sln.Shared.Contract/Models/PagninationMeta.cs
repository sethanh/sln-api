﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln.Shared.Contract.Models
{
    public class PaginationMeta
    {
        public int? TotalItems { get; set; }
        public int? PageCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
