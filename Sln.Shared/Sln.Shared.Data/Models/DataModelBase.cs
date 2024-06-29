using Sln.Shared.Data.Abstractions;

namespace Sln.Shared.Data.Models
{
    public abstract class DataModelBase<TID> : IDataModel<TID> where TID : struct
    {
        public required TID Id { get; set; }
    }
}
