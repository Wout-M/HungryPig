using System.ComponentModel;

namespace HungryPig.Helpers
{
    public static class EnumHelper
    {
        public static string Description(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            var fieldAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return fieldAttribute != null
                 ? fieldAttribute.Description
                 : value.ToString();
        }
    }
}
