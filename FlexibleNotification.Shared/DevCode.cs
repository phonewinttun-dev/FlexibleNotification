using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlexibleNotification.Shared
{
    public static class DevCode
    {
        public static void AddStringEnumConverter(this JsonSerializerOptions options)
        {
            options.Converters.Add(new JsonStringEnumConverter());
        }
    }
}
