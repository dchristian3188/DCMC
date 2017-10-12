using System.Text;

namespace dcmc.shared
{
    public class Utility
    {
        public static string MD5Hash(string input)
        {
            var hash = new StringBuilder();
            var md5provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
