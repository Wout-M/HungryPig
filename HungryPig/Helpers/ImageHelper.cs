using HungryPig.Shared;
using System.Text;

namespace HungryPig.Helpers
{
    public static class ImageHelper
    {
        public static string GetImageURL(this string name, SymbMode mode, bool left)
        {
            if (string.IsNullOrEmpty(name)) return "images/empty.png";

            var url = new StringBuilder("images/");

            switch (mode)
            {
                case SymbMode.Pig:
                    url.Append("pig/");
                    break;
                case SymbMode.Numbers:
                    url.Append("numbers/");
                    break;
            }

            url.Append(name);
            url.Append(left ? "-A.png" : "-B.png");
            return url.ToString();
        }
    }
}
