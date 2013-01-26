using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using YiHe.Model.Library;


namespace YiHe.Web.Helpers
{
    public static class TextHelper
    {
        public static string Cut(string s, int length)
        {
            s = s.Trim();
            if (s.Length == 0 || length <= 0) return "";

            var regex = new Regex("[\u2e80-\ufffd]+", RegexOptions.Compiled);

            var sb = new StringBuilder();
            for (int n = 0, i = 0; i < s.Length; i++)
            {
                if (n >= length - 4)
                {
                    if (i < s.Length) sb.Append("...");
                    break;
                }

                sb.Append(s[i]);

                if (!char.IsControl(s, i))
                {
                    if (regex.IsMatch(s[i].ToString()))
                        n += 2;
                    else
                        n++;
                }
            }

            return sb.ToString();
        }

    }
}