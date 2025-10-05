using Sln.Shared.Data.Abstractions;
using Sln.Shared.Data.Interfaces;

namespace Sln.Publisher.Data.Models;

public abstract class PublisherEntityModel<T>: MongoAuditEntityModel, IDataModel<T> where T : struct
{
    public T Id { get; set; }
}