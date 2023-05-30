using System.Collections;

namespace FacioRatio.Whereby.Api
{
    public interface IDto<TResult>
    {
    }

    public static class IDtoExtensions
    {
        public static string ToFirstCharLowerCase(this string str)
        {
            return char.IsUpper(str[0])
                ? (str.Length == 1 ? str.ToLower() : char.ToLower(str[0]) + str[1..])
                : str;
        }

        //modified from https://ole.michelsen.dk/blog/serialize-object-into-a-query-string-with-reflection.html
        public static string ToQueryString<TResult>(this IDto<TResult> dto, string separator = ",")
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            // Get all properties on the object
            var properties = dto.GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(dto, null) != null)
                .Where(x => !x.GetGetMethod(true).IsFinal) //to exclude properties that IDto inherits from other interfaces
                .ToDictionary(x => x.Name.ToFirstCharLowerCase(), x => x.GetValue(dto, null));

            // Get names for all IEnumerable properties (excl. string)
            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            // Concat all IEnumerable properties into a comma separated string
            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType ? valueType.GetGenericArguments()[0] : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            // Concat all key/value pairs into a string separated by ampersand
            return string.Join("&", properties.Select(x => string.Concat(Uri.EscapeDataString(x.Key), "=", Uri.EscapeDataString(x.Value.ToString()))));
        }
    }
}
