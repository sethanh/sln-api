using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Abstractions
{
    public interface IDataModel
    {
        
    }

    public interface IDataModel<TID> : IDataModel
    {
        TID Id { get; set; }
    }
}