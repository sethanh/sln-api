using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln.Shared.Contract.Models
{
    public class PaginationRequest
    {
        public string? Search { get; set; }
        public string? Filter { get; set; }
        public bool UseCountTotal { get; set; } = false;

        public string? OrderBy { get; set; }
        public string? OrderDirection { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [Required]
        [Range(1, 1000)]
        public int PageSize { get; set; } = 20;
    }
}
