namespace Sln.Shared.Common.Utils;

public class RealTimeUtils
{
    public static string GetKey(string job, object? suffix)
    {
        return $"{job}-{suffix}";
    }
}