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
    }
}
