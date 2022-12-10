using System.Security.Cryptography;
using System.Text;

namespace SchoolSystem
{
    public static class StringExtensions
    {
        public static string ToMD5(this string str)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        //random string generator
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //translate string from cyrillic to latin
        public static string ToLatin(this string str)
        {
            var sb = new StringBuilder();
            bool isStart = true;
            foreach (var c in str)
            {
                if (((int)c >= 41 && (int)c <= 90) || ((int)c >= 97 && (int)c <= 122))
                {
                    sb.Append(c);
                }
                else
                {
                    if (c.ToString().ToLower() == c.ToString())
                    {
                        sb.Append(Translate.FromUA(c, isStart));
                    }
                    else
                    {
                        var data = Translate.FromUA(c, isStart);
                        var res = data[0].ToString().ToUpper().ToCharArray()[0];
                        if (data.Length > 1)
                        {
                            res += data[1];
                        }
                        sb.Append(res);
                    }
                }
                isStart = false;
            }
            return sb.ToString();
        }

        public class Translate
        {
            public static string FromUA(char c, bool isStart)
            {
                switch (c.ToString().ToLower().ToCharArray()[0])
                {
                    case 'a':
                        return "a";
                    case 'б':
                        return "b";
                    case 'в':
                        return "v";
                    case 'г':
                        return "h";
                    case 'ґ':
                        return "g";
                    case 'д':
                        return "d";
                    case 'е':
                        return "e";
                    case 'є':
                        return isStart ? "Ye" : "ie";
                    case 'ж':
                        return "zh";
                    case 'з':
                        return "z";
                    case 'и':
                        return "y";
                    case 'і':
                        return "i";
                    case 'ї':
                        return isStart ? "Yi" : "i";
                    case 'й':
                        return isStart ? "Y" : "i";
                    case 'к':
                        return "k";
                    case 'л':
                        return "l";
                    case 'м':
                        return "m";
                    case 'н':
                        return "n";
                    case 'о':
                        return "o";
                    case 'п':
                        return "p";
                    case 'р':
                        return "r";
                    case 'с':
                        return "s";
                    case 'т':
                        return "t";
                    case 'у':
                        return "u";
                    case 'ф':
                        return "f";
                    case 'х':
                        return "kh";
                    case 'ц':
                        return "ts";
                    case 'ч':
                        return "ch";
                    case 'ш':
                        return "sh";
                    case 'щ':
                        return "shch";
                    case 'ь':
                        return "";
                    case 'ю':
                        return isStart ? "Yu" : "iu";
                    case 'я':
                        return isStart ? "Ya" : "ia";
                    default:
                        return c.ToString();
                }
            }
        }
    }
}
