using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Security
{
    public class SigningConfigurations
    {
        public SigningConfigurations()
        {
            using (var paramets = new RSACryptoServiceProvider(2048))
            {
                this.Key = new RsaSecurityKey(paramets.ExportParameters(true));
            }

            this.SigningCredentials = new SigningCredentials(this.Key, SecurityAlgorithms.RsaSha256Signature);
        }

        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}