using Sln.Publisher.Data.Models;
using Sln.Shared.Common.Attributes;
using Sln.Shared.Data.Attributes;

namespace Sln.Publisher.Data.Entities.Realtime;

[MongoEntity]
[IgnoreDataModelConversion]
public class RealtimeItem : PublisherEntityModel<Guid>
{
    public string? ParentKey { get; set; }
    public required string Key { get; set; }
    public string? Data { get; set; }
}
