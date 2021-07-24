using System.Text.Json;

namespace BlazorMUD.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJsonLog(this object @this)
        {
            return JsonSerializer.Serialize(@this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
