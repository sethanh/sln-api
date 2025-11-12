using MediatR;

namespace Sln.Payment.Contract.Requests.Accounts
{
    public class AccountLoginRequest : IRequest<AccountLoginResponse>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class AccountGoogleVerifyRequest : IRequest<AccountLoginResponse>
    {
        public required string IdToken { get; set; }
    }

    public class AccountLoginResponse
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }

    public class AccountGoogleLoginRequest : IRequest<AccountLoginResponse>
    {
        public required string AccessToken { get; set; }
    }

    public class AccountGoogleInfo
    {
        public string? name { get; set; }
        public string? picture { get; set; }
        public string? email { get; set; }
        public string? sub { get; set; }
    }
}