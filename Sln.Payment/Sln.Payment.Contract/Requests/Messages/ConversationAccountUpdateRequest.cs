using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ConversationAccountUpdateRequest : IRequest<ConversationAccountUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class ConversationAccountUpdateResponse : ConversationAccountGetDetailResponse
{
}
