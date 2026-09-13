using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;

namespace Digital_Services_BD.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly IDataProtector dataProtector;
        private readonly IConfiguration configuration;

        public EncryptionService(IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider)
        {
            this.configuration = configuration;
            this.dataProtector = dataProtectionProvider.CreateProtector(configuration["Encryption:Key"] ?? "Uhv3vdSsez1$g5p*");
        }
        public string Decrypt(string data)
        {
            try
            {
                var decryptedData = dataProtector.Unprotect(data);
                return decryptedData;
            }
            catch
            {
                return null;
            }

        }

        public string Encrypt(string data)
        {
            return dataProtector.Protect(data);
        }
    }
}
