using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Shop.Framework
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            var attribute = (DisplayAttribute)field.GetCustomAttribute(typeof(DisplayAttribute));
            return attribute?.Name ?? value.ToString();
        }
    }
}