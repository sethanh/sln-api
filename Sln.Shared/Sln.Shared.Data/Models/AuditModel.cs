using Sln.Shared.Data.Abstractions;

namespace Sln.Shared.Data.Models
{
    public abstract class AuditModel : DataModelBase, IFullAuditedModel
    {
        public DateTime CreationTime { get; set; }
        public long? CreatedId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModificationId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeletedId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
