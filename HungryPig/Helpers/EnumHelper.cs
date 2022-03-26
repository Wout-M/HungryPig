using HungryPig.Shared;
using MudBlazor;
using System.ComponentModel;

namespace HungryPig.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            var fieldAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return fieldAttribute != null
                 ? fieldAttribute.Description
                 : value.ToString();
        }

        public static string GetMudColor(this DotColor color) => color switch
        {
            DotColor.Black => Colors.Shades.Black,
            DotColor.Purple => Colors.Purple.Default,
            DotColor.Blue => Colors.Blue.Default,
            DotColor.Green => Colors.Green.Default,
            DotColor.Yellow => Colors.Yellow.Default,
            DotColor.Orange => Colors.Orange.Default,
            DotColor.Red => Colors.Red.Accent4,
        };
    }
}
