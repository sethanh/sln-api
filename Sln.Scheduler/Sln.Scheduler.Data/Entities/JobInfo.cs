
using Sln.Payment.Data.Enums;
using Sln.Shared.Data.Abstractions;
using Sln.Shared.Data.Models;
using Microsoft.EntityFrameworkCore;
using Sln.Shared.Common.Enums.Jobs;

namespace Sln.Payment.Data.Entities;

[Index(nameof(TransactionId))]
[Index(nameof(ObjectId))]
public class JobInfo : DataModelBase<Guid>, IRelationEntityModel
{
    public string? JobId { get; set; }
    public JobEvent JobEvent { get; set; }
    public string? JobType { get; set; }
    public Guid? ObjectId { get; set; }
    public Guid? TransactionId { get; set; }
    public JobStatus? JobStatus { get; set; }
    public string? Data { get; set; }
    public DateTime? SendTime { get; set; }
}
