using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ConversationUpdateRequest : IRequest<ConversationUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class ConversationUpdateResponse :ConversationGetDetailResponse
{
}
