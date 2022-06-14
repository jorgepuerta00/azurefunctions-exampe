namespace IkeaAssignmentCore.Application.Common.ExtensionMethods
{
    using System;

    public static class ExtensionMethods
    {
        public static void ThrowIfArgumentIsNull<T>(this T value, string argument) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(argument);
            }
        }

        public static string ConcatUrl(this string url, string param) 
        {
            return string.IsNullOrEmpty(param) ? url : string.Concat(url, "&quantity=" + param);
        }
    }
}
