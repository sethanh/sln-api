using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ConversationAccountGetDetailRequest : IRequest<ConversationAccountGetDetailResponse>
{
    public required Guid Id { get; set; }
}

public class ConversationAccountGetDetailResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}
