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
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //translate string from cyrillic to latin
        public static string ToLatin(this string str)
        {
            var sb = new StringBuilder();
            foreach (var c in str)
            {
                if (c >= 'А' && c <= 'я')
                {
                    sb.Append((char)(c + 0x20));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
