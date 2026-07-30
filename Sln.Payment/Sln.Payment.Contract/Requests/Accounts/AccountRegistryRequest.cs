using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts
{
    public class AccountRegistryRequest : IRequest<AccountRegistryResponse>
    {
        public required string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class AccountRegistryResponse :  AccountLoginResponse
    {
    }
}