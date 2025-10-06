namespace Sln.Shared.Common.Utils;

public class DateTimeUtils
{
    public static bool CheckOverlap(
        DateTime startLandmark,
        DateTime endLandmark,
        DateTime startTime,
        DateTime endTime
    )
    {
        return endTime > startLandmark && startTime < endLandmark;
    }

}