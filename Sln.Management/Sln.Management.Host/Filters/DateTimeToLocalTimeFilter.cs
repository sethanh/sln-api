using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sln.Management.Host.Filters
{
    public class DateTimeToLocalTimeFilter : ResultFilterAttribute
    {
        private readonly TimeZoneInfo _timeZoneInfo;

        public DateTimeToLocalTimeFilter()
        {
            _timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"); // Múi giờ +7
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var result = objectResult.Value;
                if (result != null)
                {
                    var value = ConvertToPrimitive(result);
                    objectResult.Value = value;
                }
            }

            base.OnResultExecuting(context);
        }

        private object? ConvertToPrimitive(object? obj)
        {
            if (obj is null)
            {
                return null;
            }

            Type objType = obj.GetType();

            if (objType == typeof(DateTime))
            {
                var dateTimeObject  = TimeZoneInfo.ConvertTimeFromUtc((DateTime)obj, _timeZoneInfo);
                return $"{dateTimeObject.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")}";
            }

            if (objType.IsEnum)
            {
                return obj;
            }

            if (objType.IsPrimitive || objType == typeof(string) || objType == typeof(decimal) || objType == typeof(Guid))
            {
                return obj;
            }

            if (obj is IList list)
            {
                List<object?> convertedList = [];
                foreach (var item in list)
                {
                    convertedList.Add(ConvertToPrimitive(item));
                }
                return convertedList;
            }

            if (obj is IDictionary dictionary)
            {
                Dictionary<string, object?> convertedDictionary = [];
                foreach (var key in dictionary.Keys)
                {
                    var keyName = key.ToString();

                    if (keyName != null)
                    {
                        convertedDictionary[keyName] = ConvertToPrimitive(dictionary[key]);
                    }

                }

                return convertedDictionary;
            }
            
            Dictionary<string, object> result = [];
            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(obj);
                result[property.Name] = ConvertToPrimitive(value) ?? "";
            }

            return result;
        }
    }
}