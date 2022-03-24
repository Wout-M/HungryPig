using HungryPig.Shared;
using System.Text;

namespace HungryPig.Helpers
{
    public static class ImageHelper
    {
        public static string GetImageURL(this string name, Mode mode, bool left)
        {
            if (string.IsNullOrEmpty(name)) return "images/empty.png";

            var url = new StringBuilder("images/");

            switch (mode)
            {
                case Mode.Pig:
                    url.Append("pig/");
                    break;
                case Mode.Numbers:
                    url.Append("numbers/");
                    break;
            }

            url.Append(name);
            url.Append(left ? "-A.png" : "-B.png");
            return url.ToString();
        }
    }
}
