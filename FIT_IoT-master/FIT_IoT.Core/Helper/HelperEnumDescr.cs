using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FIT_IoT.Core.Helper
{
    public static class HelperEnumDescr
    {
        public static string MyDescription(this Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description;
        }
    }
}
