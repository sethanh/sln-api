using Sln.Shared.Data.Abstractions;

namespace Sln.Shared.Data.Models
{
    public abstract class DataModelBase : IDataModel<long>
    {
        public long Id { get; set; }
    }
}
