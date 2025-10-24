namespace Sln.Shared.Contract.Models
{
    public class ScrollPaginationRequest
    {
        public Guid? BeforeId { get; set; }
        public int PageSize { get; set; } = 10;
        public bool UseCountTotal { get; set; } = false;
    }
}