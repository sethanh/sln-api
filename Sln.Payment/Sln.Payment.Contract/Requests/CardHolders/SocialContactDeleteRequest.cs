using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.CardHolders;

public class SocialContactDeleteRequest : IRequest
{
    public Guid Id { get; set; }
}