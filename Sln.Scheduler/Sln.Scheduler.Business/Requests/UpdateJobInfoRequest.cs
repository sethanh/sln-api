
namespace Sln.Scheduler.Business.Requests
{
    public class UpdateJobInfoRequest
    {
        public Guid Id { get; set; }
        public required string JobId { get; set; }
        public string? JobEvent { get; set; }
        public string? JobType { get; set; }
        public string? JobStatus { get; set; }
    }

    public class UpdateJobInfoResponse
    {
        public Guid Id { get; set; }
        public required string JobId { get; set; }
        public string? JobEvent { get; set; }
        public string? JobType { get; set; }
        public string? JobStatus { get; set; }
    }
}
