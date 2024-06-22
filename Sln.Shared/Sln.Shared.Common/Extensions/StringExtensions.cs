using System.Security.Cryptography;
using System.Text;

namespace Sln.Shared.Common.Extensions;

public static class StringExtensions
{
    public static string GetMD5Hash(this string input)
    {
        using (var md5 = MD5.Create())
        {
            var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            return Encoding.ASCII.GetString(result);
        }
    }
    public static string BuildSqlLikeCondition(this string keyword, bool isSearchWildCard = true)
    {
        keyword = keyword.Replace("[", "[[]").Replace("%", "[%]");
        return isSearchWildCard ? "%" + keyword + "%" : keyword;
    }
}
