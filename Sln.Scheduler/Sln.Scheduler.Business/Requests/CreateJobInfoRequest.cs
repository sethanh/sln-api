

using Sln.Shared.Common.Enums.Jobs;

namespace Sln.Payment.Business.Requests
{
    public class CreateJobInfoRequest
    {
        public Guid? Id { get; set; }
        public Guid? TransactionId { get; set; }
        public JobEvent? JobEvent { get; set; }
        public string? JobType { get; set; }
        public Guid? ObjectId { get; set; }
        public string? JobStatus { get; set; }
        public string? JobId { get; set; }
        public string? JobData { get; set; }
        public DateTime? SendTime { get; set; }
    }

    public class CreateJobInfoResponse
    {
        public Guid Id { get; set; }
        public Guid? TransactionId { get; set; }
        public string? JobId { get; set; }
        public string? JobEvent { get; set; }
        public string? JobType { get; set; }
        public string? JobStatus { get; set; }
    }
}
