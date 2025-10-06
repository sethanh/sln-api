using System.Web;

namespace Sln.Shared.Common.Utils;
public class StringUtils
{
    public static string StringToHtml(string text)
    {
        text = HttpUtility.HtmlEncode(text);
        text = text.Replace("\r\n", "\r");
        text = text.Replace("\n", "\r");
        text = text.Replace("\r", "<br>\r\n");
        text = text.Replace("  ", " &nbsp;");
        return text;
    }
}