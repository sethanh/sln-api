using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class ContactUpdateRequest : IRequest<ContactUpdateResponse>
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public string? Job { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public long? PhotoId { get; set; }
    public string? ProfileName { get; set; }
    public List<SocialContactCreateRequest>? SocialContacts { get; set; }
}

public class ContactUpdateResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
}
