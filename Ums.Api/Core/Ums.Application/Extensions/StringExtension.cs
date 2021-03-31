using System;

namespace Ums.Application.Extensions
{
    public static class StringExtension
    {
        public static Guid TryParseGuid(this string value)
        {
            Guid.TryParse(value, out Guid result);
            return result;
        }
    }
}