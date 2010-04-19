using System.Security.Cryptography;
using System.Text;

namespace LeanPlanner.Web.Infrastructure.Avatar
{
    public class GravatarGenerator : IAvatarGenerator
    {
        public string GenerateUrl(string email)
        {
            var hasher = MD5.Create();
            var data = hasher.ComputeHash(Encoding.Default.GetBytes(email));
            var builder = new StringBuilder();
            builder.Append("http://www.gravatar.com/avatar/");
            for (var i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            builder.Append("?d=identicon&s=48");
            return builder.ToString();
        }
    }
}