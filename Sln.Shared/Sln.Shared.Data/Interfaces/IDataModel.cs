using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln.Shared.Data.Interfaces
{
    public interface IDataModel
    {
        
    }

    public interface IDataModel<TID> : IDataModel where TID : struct
    {
        TID Id { get; set; }
    }
}