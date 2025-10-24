using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Messages;

public class ChatMessageUpdateRequest : IRequest<ChatMessageUpdateResponse>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}

public class ChatMessageUpdateResponse :ChatMessageGetDetailResponse
{
}
