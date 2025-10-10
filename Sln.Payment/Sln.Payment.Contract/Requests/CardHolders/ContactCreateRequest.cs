using Sln.Shared.Contract.Models;
using MediatR;
using Sln.Payment.Contract.Requests.Uploads;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class ContactCreateRequest : IRequest<ContactCreateResponse>
{
    public required string Name { get; set; }
    public string? Job { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public long? PhotoId { get; set; }
    public List<SocialContactCreateRequest>? SocialContacts { get; set; }
}

public class ContactCreateResponse : ContactGetDetailResponse
{
}
