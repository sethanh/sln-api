using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XLColumnFormatAttribute: Attribute
    {
        public string Format { get; set; }
        
        public XLColumnFormatAttribute()
        {
        }
    }
}