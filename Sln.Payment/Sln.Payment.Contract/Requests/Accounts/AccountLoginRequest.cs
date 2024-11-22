using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts
{
    public class AccountLoginRequest : IRequest<AccountLoginResponse>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class AccountGoogleLoginRequest: IRequest<AccountLoginResponse>
    {
        public string IdToken { get; set; } = string.Empty;
    }

    public class AccountLoginResponse
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
        
}