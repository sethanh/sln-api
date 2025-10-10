using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Requests.Uploads;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class ContactGetDetailRequest : IRequest<ContactGetDetailResponse>
{
    public required long Id { get; set; }
}

public class ContactGetDetailResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public string? Job { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public long? PhotoId { get; set; }
    public string? ProfileName { get; set; }
    public List<SocialContactGetDetailResponse>? SocialContacts { get; set; }
    public PhotoGetDetailResponse? Photo { get; set;}
}
