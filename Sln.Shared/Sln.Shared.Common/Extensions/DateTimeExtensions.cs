using NodaTime;

namespace Sln.Shared.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime LocalTime(this DateTime utcDateTime, string timeZoneId)
        {
            var tzdb = DateTimeZoneProviders.Tzdb;
            var timeZone = tzdb.GetZoneOrNull(timeZoneId);

            if (timeZone == null)
            {
                throw new Exception($"Không tìm thấy múi giờ: {timeZoneId}");
            }

            if (utcDateTime.Kind == DateTimeKind.Unspecified)
            {
                utcDateTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);
            }
            else if (utcDateTime.Kind == DateTimeKind.Local)
            {
                utcDateTime = utcDateTime.ToUniversalTime();
            }

            Instant instant = Instant.FromDateTimeUtc(utcDateTime);
            ZonedDateTime zonedDateTime = instant.InZone(timeZone);

            return zonedDateTime.ToDateTimeUnspecified();
        }

    }
}