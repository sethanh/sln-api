using MediatR;
using Sln.Payment.Contract.Requests.Accounts;
using Sln.Payment.Contract.Requests.Uploads;

namespace Sln.Payment.Contract.Requests.Messages;

public class ConversationGetDetailRequest : IRequest<ConversationGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class ConversationGetDetailResponse
{
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public List<ConversationAccountGetDetailResponse>? Accounts { get; set; }
    public string? Background { get; set; }
    public string? Icon { get; set; }
}

public class AccountResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public Guid? PhotoId { get; set; }
    public PhotoGetDetailResponse? Photo { get; set; }
    public List<GoogleAccountGetDetailResponse>? GoogleAccounts { get; set; }
}
