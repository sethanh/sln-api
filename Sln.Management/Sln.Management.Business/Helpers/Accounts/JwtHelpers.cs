using System.Security.Claims;
using Sln.Management.Data.DataModels.Accounts;
using Sln.Management.Data.Entities;
using Sln.Shared.Common.Constants.Envs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Sln.Management.Business.Helpers.Accounts
{
    public class JwtHelpers
    {
        public static AccountToken GenerateJWTTokens(Account Account)
        {
            try
            {
                var refreshToken = GenerateRefreshToken(Account.Id);
                return new AccountToken { AccessToken = GenerateJWTToken(Account), RefreshToken = refreshToken };
            }
            catch
            {
                throw;
            }
        }

        public static string GenerateJWTToken(Account Account)
        {
            var claims = new List<Claim> {
                new(ClaimTypes.NameIdentifier, Account.Id.ToString()),
                new(ClaimTypes.Email, Account.Email),
                new(ClaimTypes.Name, Account.Name),
                // new(AccountTypeClaims.OrganizationId.ToString(), Account.OrganizationId.ToString()),
                // new(ClaimTypes.Role, Account.RootAccount ? AccountRoleClaims.Management.ToString() : AccountRoleClaims.Member.ToString())
            };

            var jwtSecret = Environment.GetEnvironmentVariable(EnvConstants.JWT_SECRET);
            if (jwtSecret == null || jwtSecret == "") { throw new Exception($"{EnvConstants.JWT_SECRET} is not set"); }

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(jwtSecret!)
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        public static string GenerateRefreshToken(long AccountId)
        {
            byte[] nowValue = BitConverter.GetBytes(DateTime.Now.Ticks);
            byte[] accountIdValue = BitConverter.GetBytes(AccountId);

            string dateTimeBase64 = Convert.ToBase64String(nowValue);
            string accountIdBase64 = Convert.ToBase64String(accountIdValue);

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            string randomBase64 = Convert.ToBase64String(randomNumber);

            return accountIdBase64 + "_org%" + dateTimeBase64 + randomBase64;
        }

        public static long GetAccountIdInRefreshToken(string refreshToken)
        {
            string[] values = refreshToken.Split("_org%");

            var accountValue = values[0];
            var accountIdByte = Convert.FromBase64String(accountValue);
            long accountId = 0;
            try
            {
                accountId = BitConverter.ToInt64(accountIdByte, 0);
            }
            catch
            { }

            return accountId;
        }
    }
}