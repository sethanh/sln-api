using System.Text.Json.Serialization;
using Sln.Shared.Data.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ThirdParty.Json.LitJson;

namespace Sln.Publisher.Data.Models;

public abstract class MongoAuditEntityModel: IMongoEntityModel
{
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;
    public DateTime? ModificationTime { get; set; }
    public DateTime? DeletionTime { get; set; }
}