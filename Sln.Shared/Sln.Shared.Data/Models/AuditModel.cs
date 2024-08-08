using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data.Models
{
    public abstract class AuditModel<TID> : DataModelBase<TID>, IFullAuditedModel<TID> where TID : struct
    {
        public DateTime CreationTime { get; set; }
        public TID? CreatedId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public TID? LastModificationId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public TID? DeletedId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
