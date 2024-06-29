using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sln.Shared.Data.Abstractions;

namespace Sln.Shared.Data.Models
{
    public abstract class DataModelBase<TID> : IDataModel<TID> where TID : struct
    {
        public TID Id { get; set; }
    }
}
