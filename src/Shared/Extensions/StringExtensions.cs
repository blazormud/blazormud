using System;

namespace BlazorMUD.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveColorCodes(this string @this)
        {
            // TODO: Remove all color codes after color system is in place.
            return @this;
        }
    }
}
