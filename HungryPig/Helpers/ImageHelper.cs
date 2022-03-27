using HungryPig.Shared;
using System.Text;

namespace HungryPig.Helpers
{
    public static class ImageHelper
    {
        public static string GetSymbImageURL(this string name, SymbMode mode, int amount, bool left)
        {
            if (string.IsNullOrEmpty(name)) return "images/empty.png";

            var url = new StringBuilder("images/");

            switch (mode)
            {
                case SymbMode.Pig:
                    url.Append("pig/");
                    url.Append(name);
                    url.Append(left ? "-A.png" : "-B.png");
                    break;
                case SymbMode.Numbers:
                    url.Append("numbers/");
                    url.Append(amount);
                    url.Append(".png");
                    break;
            }


            
            return url.ToString();
        }

        public static string GetDotImageURL(this string name) => string.IsNullOrEmpty(name) ? "images/empty.png" : $"images/dot/{name}.png";
    }
}
